using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core;
using CRM.Core.Domain.Security;
using CRM.Services.Customers;
using CRM.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MobileAheresisAdmin.Models.Security;
using MobileAheresisAdmin.Models.UsersRole;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    public class SecurityController : BaseController
    {
        #region Fields


        private readonly IWorkContext _workContext;
        private readonly IPermissionService _permissionService;
        private readonly ICustomerService _customerService;

        #endregion

        #region Ctor

        public SecurityController(IWorkContext workContext,
            IPermissionService permissionService,
            ICustomerService customerService)
        {

            this._workContext = workContext;
            this._permissionService = permissionService;
            this._customerService = customerService;

        }

        #endregion
        public virtual IActionResult Permissions()
        {//PageSize
            //var report = SharedData.PermissionReport;
            //if (report != null)
            //{
            //    SharedData.RowCount = report.RowCount;
            //    SharedData.ReportName = "Permission";
            //}
            //else
            //{
            //    SharedData.RowCount = 10;
            //    SharedData.ReportName = "Permission";
            //}
            //Form Name
            ViewBag.FormName = "Permissions";
            //if (SharedData.isManageAclMenuAccessible == false)
            //    return AccessDeniedView();

            var model = new PermissionMappingModel();

            var permissionRecords = _permissionService.GetAllPermissionRecords();
            var customerRoles = _customerService.GetAllCustomerRoles(true);
            foreach (var pr in permissionRecords)
            {
                model.AvailablePermissions.Add(new PermissionRecordModel
                {
                    //Name = pr.Name,
                    Name = pr.Name,
                    SystemName = pr.SystemName
                });
            }
            foreach (var cr in customerRoles)
            {
                model.AvailableCustomerRoles.Add(new CustomerRoleModel
                {
                    Id = cr.Id,
                    Name = cr.Name
                });
            }
            foreach (var pr in permissionRecords)
                foreach (var cr in customerRoles)
                {
                    var allowed = pr.PermissionRecord_Role_Mapping.Count(x => x.CustomerRole.Id == cr.Id) > 0;
                    if (!model.Allowed.ContainsKey(pr.SystemName))
                        model.Allowed[pr.SystemName] = new Dictionary<int, bool>();
                    model.Allowed[pr.SystemName][cr.Id] = allowed;
                }

            return View(model);
        }

        [HttpPost, ActionName("Permissions")]
        public virtual IActionResult PermissionsSave(IFormCollection form)
        {//PageSize
            //var report = SharedData.PermissionReport;
            //if (report != null)
            //{
            //    SharedData.RowCount = report.RowCount;
            //    SharedData.ReportName = "Permission";
            //}
            //else
            //{
            //    SharedData.RowCount = 10;
            //    SharedData.ReportName = "Permission";
            //}
            //Form Name
            ViewBag.FormName = "Permissions";
            //if (SharedData.isManageAclMenuAccessible == false)
            //    return AccessDeniedView();
            try
            {
                var permissionRecords = _permissionService.GetAllPermissionRecords();
                var customerRoles = _customerService.GetAllCustomerRoles(true);

                foreach (var cr in customerRoles)
                {
                    var formKey = "allow_" + cr.Id;
                    var permissionRecordSystemNamesToRestrict = !StringValues.IsNullOrEmpty(form[formKey])
                        ? form[formKey].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                        : new List<string>();

                    foreach (var pr in permissionRecords)
                    {

                        var allow = permissionRecordSystemNamesToRestrict.Contains(pr.SystemName);
                        if (allow)
                        {
                            PermissionRecord_Role_Mapping permissionRecord_Role_Mapping = new PermissionRecord_Role_Mapping()
                            {
                                CustomerRoleId = cr.Id,
                                PermissionRecordId = pr.Id
                            };
                            if (pr.PermissionRecord_Role_Mapping.FirstOrDefault(x => x.CustomerRole.Id == cr.Id) == null)
                            {
                                pr.PermissionRecord_Role_Mapping.Add(permissionRecord_Role_Mapping);
                                _permissionService.UpdatePermissionRecord(pr);
                            }
                        }
                        else
                        {
                            if (pr.PermissionRecord_Role_Mapping.FirstOrDefault(x => x.CustomerRole.Id == cr.Id) != null)
                            {
                                pr.PermissionRecord_Role_Mapping.Remove(pr.PermissionRecord_Role_Mapping.FirstOrDefault(x => x.CustomerRole.Id == cr.Id));
                                _permissionService.UpdatePermissionRecord(pr);
                            }
                        }
                    }
                }

                AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgSavePermission, NotificationMessage.TypeSuccess);

                return RedirectToAction("Permissions");
            }
            catch (Exception e)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrormsgSavePermission, NotificationMessage.TypeError);

                return View(e);
            }
        }

        public virtual IActionResult AccessDenied(string pageUrl)
        {

            return View();
        }


    }
}