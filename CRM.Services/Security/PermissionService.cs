using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Core;
using CRM.Core.Caching;
using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Security;
using CRM.Data.Interfaces;
using CRM.Services.Customers;
using CRM.Services.Security;

namespace CRM.Services.Security
{
    /// <summary>
    /// Permission service
    /// </summary>-
    public partial class PermissionService : IPermissionService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer role ID
        /// {1} : permission system name
        /// </remarks>
        private const string PERMISSIONS_ALLOWED_KEY = "Nop.permission.allowed-{0}-{1}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string PERMISSIONS_PATTERN_KEY = "Nop.permission.";

        #endregion

        #region Fields

        private readonly IRepository<PermissionRecord> _permissionRecordRepository;
        private readonly IRepository<PermissionRecord_Role_Mapping> _permissionRecord_Role_Mapping;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;


        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="permissionRecordRepository">Permission repository</param>
        /// <param name="customerService">Customer service</param>
        /// <param name="workContext">Work context</param>
        /// <param name="localizationService">Localization service</param>
        /// <param name="languageService">Language service</param>
        /// <param name="cacheManager">Static cache manager</param>
        public PermissionService(IRepository<PermissionRecord> permissionRecordRepository,
            ICustomerService customerService,
            IWorkContext workContext)
        {
            this._permissionRecordRepository = permissionRecordRepository;
            this._customerService = customerService;
            this._workContext = workContext;


        }

        #endregion

        #region Utilities

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="customerRole">Customer role</param>
        /// <returns>true - authorized; otherwise, false</returns>
        protected virtual bool Authorize(string permissionRecordSystemName, CustomerRole customerRole)
        {
            if (string.IsNullOrEmpty(permissionRecordSystemName))
                return false;


            foreach (var permission1 in customerRole.PermissionRecord_Role_Mapping)
                if (permission1.PermissionRecord.SystemName.Equals(permissionRecordSystemName, StringComparison.InvariantCultureIgnoreCase))
                    return true;

            return false;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void DeletePermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException(nameof(permission));

            _permissionRecordRepository.Delete(permission);

        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="permissionId">Permission identifier</param>
        /// <returns>Permission</returns>
        public virtual PermissionRecord GetPermissionRecordById(int permissionId)
        {
            if (permissionId == 0)
                return null;

            return _permissionRecordRepository.GetById(permissionId);
        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="systemName">Permission system name</param>
        /// <returns>Permission</returns>
        public virtual PermissionRecord GetPermissionRecordBySystemName(string systemName)
        {
            if (string.IsNullOrWhiteSpace(systemName))
                return null;

            var query = from pr in _permissionRecordRepository.Table
                        where pr.SystemName == systemName
                        orderby pr.Id
                        select pr;

            var permissionRecord = query.FirstOrDefault();
            return permissionRecord;
        }

        /// <summary>
        /// Gets all permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public virtual IList<PermissionRecord> GetAllPermissionRecords()
        {
            var query = from pr in _permissionRecordRepository.Table
                        orderby pr.Name
                        select pr;
            var permissions = query.ToList();
            return permissions;
        }

        /// <summary>
        /// Inserts a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void InsertPermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException(nameof(permission));

            _permissionRecordRepository.Insert(permission);

        }

        /// <summary>
        /// Updates the permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void UpdatePermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException(nameof(permission));

            _permissionRecordRepository.Update(permission);

        }
        //03/10/19 aakansha
        /// Create the permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void CreatePermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException(nameof(permission));

            _permissionRecordRepository.Create(permission);

        }
        public virtual void EditPermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException(nameof(permission));

            _permissionRecordRepository.Edit(permission);

        }


        /// <summary>
        /// Install permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public virtual void InstallPermissions(IPermissionProvider permissionProvider)
        {
            //install new permissions
            var permissions = permissionProvider.GetPermissions();
            //default customer role mappings
            var defaultPermissions = permissionProvider.GetDefaultPermissions().ToList();

            foreach (var permission in permissions)
            {
                var permission1 = GetPermissionRecordBySystemName(permission.SystemName);
                if (permission1 != null)
                    continue;

                //new permission (install it)
                permission1 = new PermissionRecord
                {
                    Name = permission.Name,
                    SystemName = permission.SystemName,
                    Category = permission.Category,
                };

                foreach (var defaultPermission in defaultPermissions)
                {
                    var customerRole = _customerService.GetCustomerRoleBySystemName(defaultPermission.CustomerRoleSystemName);
                    if (customerRole == null)
                    {
                        //new role (save it)
                        customerRole = new CustomerRole
                        {
                            Name = defaultPermission.CustomerRoleSystemName,
                            Active = true,
                            SystemName = defaultPermission.CustomerRoleSystemName
                        };
                        _customerService.InsertCustomerRole(customerRole);
                    }

                    var defaultMappingProvided = (from p in defaultPermission.PermissionRecords
                                                  where p.SystemName == permission1.SystemName
                                                  select p).Any();
                    var mappingExists = (from p in customerRole.PermissionRecord_Role_Mapping
                                         where p.CustomerRole.SystemName == permission1.SystemName
                                         select p).Any();
                    if (defaultMappingProvided && !mappingExists)
                    {
                        PermissionRecord_Role_Mapping permissionRecord_Role_Mapping = new PermissionRecord_Role_Mapping()
                        {
                             PermissionRecordId = permission1.Id,
                              CustomerRoleId = customerRole.Id
                        };
                        InsertPermissionRecordRoleMapping(permissionRecord_Role_Mapping);
                    }
                }

                //save new permission
                InsertPermissionRecord(permission1);


            }
        }

        public virtual void InsertPermissionRecordRoleMapping(PermissionRecord_Role_Mapping permissionRoleMappingProvider)
        {
            if (permissionRoleMappingProvider == null)
                throw new ArgumentNullException(nameof(permissionRoleMappingProvider));

            _permissionRecord_Role_Mapping.Insert(permissionRoleMappingProvider);
        }

        /// <summary>
        /// Uninstall permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public virtual void UninstallPermissions(IPermissionProvider permissionProvider)
        {
            var permissions = permissionProvider.GetPermissions();
            foreach (var permission in permissions)
            {
                var permission1 = GetPermissionRecordBySystemName(permission.SystemName);
                if (permission1 != null)
                {
                    DeletePermissionRecord(permission1);

                }
            }
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(PermissionRecord permission)
        {
            return Authorize(permission, _workContext.CurrentCustomer);
        }

        ///// <summary>
        ///// Authorize permission
        ///// </summary>
        ///// <param name="permission">Permission record</param>
        ///// <param name="customer">Customer</param>
        ///// <returns>true - authorized; otherwise, false</returns>
        //public virtual bool Authorize(PermissionRecord permission, Customer customer)
        //{
        //    if (permission == null)
        //        return false;

        //    if (customer == null)
        //        return false;

        //    //old implementation of Authorize method
        //    var customerRoles = customer.CustomerRoles.Where(cr => cr.Active);
        //    var customerRole = _customerService.GetAllCustomerRoles().Where(a => a.Id == customer.CustomerRoleId).FirstOrDefault();
        //    var permissionRecords = GetAllPermissionRecords();

        //    foreach (var permission1 in customerRole.PermissionRecord_Role_Mapping)
        //            if (permission1.PermissionRecord.SystemName == permission.SystemName)
        //                return true;

        //    //foreach (var pr in permissionRecords)
        //    //    foreach (var cr in customerRoles)
        //    //    {
        //    //        var allowed = pr.PermissionRecord_Role_Mapping.Count(x => x.CustomerRole.Id == cr.Id) > 0;
        //    //        if (!model.Allowed.ContainsKey(pr.SystemName))
        //    //            model.Allowed[pr.SystemName] = new Dictionary<int, bool>();
        //    //        model.Allowed[pr.SystemName][cr.Id] = allowed;
        //    //    }

        //    return Authorize(permission.SystemName, customer); 

        //   // return Authorize(permission.SystemName, customer);
        //}


        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(PermissionRecord permission, Customer customer)
        {
            if (permission == null)
                return false;

            if (customer == null)
                return false;

            //old implementation of Authorize method
            //var customerRoles = customer.CustomerRoles.Where(cr => cr.Active);
            //foreach (var role in customerRoles)
            //    foreach (var permission1 in role.PermissionRecords)
            //        if (permission1.SystemName.Equals(permission.SystemName, StringComparison.InvariantCultureIgnoreCase))
            //            return true;

            //return false;

            return Authorize(permission.SystemName, customer);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(string permissionRecordSystemName)
        {
            return Authorize(permissionRecordSystemName, _workContext.CurrentCustomer);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(string permissionRecordSystemName, Customer customer)
        {
            if (string.IsNullOrEmpty(permissionRecordSystemName))
                return false;

            var customerRole = customer.CustomerRole;
           // foreach (var role in customerRoles)
                if (Authorize(permissionRecordSystemName, customerRole))
                    //yes, we have such permission
                    return true;

            //no permission found
            return false;
        }
        #endregion
    }
}