using System.Collections.Generic;
using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Security;

namespace CRM.Services.Security
{
    /// <summary>
    /// Standard permission provider
    /// </summary>
    public partial class StandardPermissionProvider : IPermissionProvider
    {
        //admin area permissions
        public static readonly PermissionRecord AccessAdminPanel = new PermissionRecord { Name = "Access Admin Area", SystemName = "AccessAdminPanel", Category = "Standard" };
        public static readonly PermissionRecord Maintenance = new PermissionRecord { Name = "Manage Maintenance", SystemName = "ManageMaintenance", Category = "Configuration" };
        public static readonly PermissionRecord ManageAppointment = new PermissionRecord { Name = "Manage Appointment", SystemName = "ManageAppointment", Category = "Appointment" };
        public static readonly PermissionRecord ManageUserRoles = new PermissionRecord { Name = "Manage User Roles", SystemName = "ManageUserRoles", Category = "User" };
        public static readonly PermissionRecord ManageUsers = new PermissionRecord { Name = "Manage Users", SystemName = "ManageUsers", Category = "User" };
        public static readonly PermissionRecord ManageCompanyProfile = new PermissionRecord { Name = "Manage CompanyProfile", SystemName = "ManageCompanyProfile", Category = "Company" };
        public static readonly PermissionRecord ManageHospital = new PermissionRecord { Name = "Manage Hospital", SystemName = "ManageHospital", Category = "Hospital" };
        public static readonly PermissionRecord ManageNurse = new PermissionRecord { Name = "Manage Nurse", SystemName = "ManageNurse", Category = "User" };
        public static readonly PermissionRecord ManageDiagnosis = new PermissionRecord { Name = "Manage Diagnosis", SystemName = "ManageDiagnosis", Category = "Treatment" };
        public static readonly PermissionRecord ManageCommentType = new PermissionRecord { Name = "Manage CommentType", SystemName = "ManageCommentType", Category = "Treatment" };
        public static readonly PermissionRecord ManageAuto_Text = new PermissionRecord { Name = "Manage Auto-Text", SystemName = "ManageAuto-Text", Category = "Treatment" };
        public static readonly PermissionRecord ManageEquipment = new PermissionRecord { Name = "Manage Equipment", SystemName = "ManageEquipment", Category = "Treatment" };
        public static readonly PermissionRecord ManagePermission = new PermissionRecord { Name = "Manage Permission", SystemName = "ManagePermission", Category = "Permission" };
        public static readonly PermissionRecord ManageTreatmentRecord = new PermissionRecord { Name = "Manage TreatmentRecord", SystemName = "ManageTreatmentRecord", Category = "TreatmentRecord" };
        public static readonly PermissionRecord ManageTreatmentReport = new PermissionRecord { Name = "Manage TreatmentReport", SystemName = "ManageTreatmentReport", Category = "TreatmentRecord" };
        public static readonly PermissionRecord ManageMobileAdmin = new PermissionRecord { Name = "Manage MobileAdmin", SystemName = "ManageMobileAdmin", Category = "MobileAdmin" };


        //public store permissions
        public static readonly PermissionRecord DisplayPrices = new PermissionRecord { Name = "Public store. Display Prices", SystemName = "DisplayPrices", Category = "PublicStore" };
        public static readonly PermissionRecord EnableShoppingCart = new PermissionRecord { Name = "Public store. Enable shopping cart", SystemName = "EnableShoppingCart", Category = "PublicStore" };
        public static readonly PermissionRecord EnableWishlist = new PermissionRecord { Name = "Public store. Enable wishlist", SystemName = "EnableWishlist", Category = "PublicStore" };
        public static readonly PermissionRecord PublicStoreAllowNavigation = new PermissionRecord { Name = "Public store. Allow navigation", SystemName = "PublicStoreAllowNavigation", Category = "PublicStore" };
        public static readonly PermissionRecord AccessClosedStore = new PermissionRecord { Name = "Public store. Access a closed store", SystemName = "AccessClosedStore", Category = "PublicStore" };

        /// <summary>
        /// Get permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public virtual IEnumerable<PermissionRecord> GetPermissions()
        {
            return new[]
            {
                AccessAdminPanel,
              DisplayPrices,
                EnableShoppingCart,
                EnableWishlist,
                PublicStoreAllowNavigation,
                AccessClosedStore,
                ManageUserRoles,
               ManageUsers,
               ManageCompanyProfile,
               ManageHospital,
              ManageNurse,
               ManageDiagnosis,
                ManageCommentType,
                 ManageAuto_Text,
                  ManageEquipment,
                  ManagePermission,
                  ManageAppointment,
                  ManageTreatmentRecord,
                  ManageTreatmentReport,
                  ManageMobileAdmin





            };
        }

        /// <summary>
        /// Get default permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public virtual IEnumerable<DefaultPermissionRecord> GetDefaultPermissions()
        {
            return new[]
            {
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Admin,
                    PermissionRecords = new[]
                    {
                        AccessAdminPanel,
              DisplayPrices,
                EnableShoppingCart,
                EnableWishlist,
                PublicStoreAllowNavigation,
                AccessClosedStore,
                ManageUserRoles,
               ManageUsers,
               ManageCompanyProfile,
               ManageHospital,
              ManageNurse,
               ManageDiagnosis,
                ManageCommentType,
                 ManageAuto_Text,
                  ManageEquipment,
                  ManagePermission,
                  ManageAppointment,
                  ManageTreatmentRecord,
                  ManageTreatmentReport,
                  ManageMobileAdmin


                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Customer,
                    PermissionRecords = new[]
                    {
                        DisplayPrices,
                        EnableShoppingCart,
                        EnableWishlist,
                        PublicStoreAllowNavigation
                    }
                },
                 new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Guests,
                    PermissionRecords = new[]
                    {
                        DisplayPrices,
                        EnableShoppingCart,
                        EnableWishlist,
                        PublicStoreAllowNavigation
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Registered,
                    PermissionRecords = new[]
                    {
                        DisplayPrices,
                        EnableShoppingCart,
                        EnableWishlist,
                        PublicStoreAllowNavigation
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Vendors,
                    PermissionRecords = new[]
                    {
                        AccessAdminPanel,
                        
                    }
                }

            };
        }
    }
}