using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Common
{
    public static class SharedData
    {
   


        ////*aakansha 07/09/19*//
        #region Permissions
        public static int UserId { get; set; }
    public static string RoleName { get; set; }
    public static string FullName { get; set; }
    public static string FirstName { get; set; }
    public static string LastName { get; set; }
    public static bool? isUserRoleMenuAccessible { get; set; }
    public static bool? isManageUserMenuAccessible { get; set; }
    public static bool? isCompanyProfileMenuAccessible { get; set; }
    public static bool? isHospitalMenuAccessible { get; set; }
    public static bool? isAppointmentMenuAccessible { get; set; }
    public static bool? isNurseMenuAccessible { get; set; }
    public static bool? isDiagnosisMenuAccessible { get; set; }
    public static bool? isCommentTypeMenuAccessible { get; set; }
    public static bool? isAuto_TextMenuAccessible { get; set; }
    public static bool? isEquipmentMenuAccessible { get; set; }
        public static bool? isTreatmentRecordMenuAccessible { get; set; }
        public static bool? isTreatmentReportMenuAccessible { get; set; }
        public static bool? isPermissionMenuAccessible { get; set; }
    public static bool? isMaintenanceMenuAccessible { get; set; }
        public static bool? isMobileAdminMenuAccessible { get; set; }
        public static bool? isAccessAdminPanelMenuAccessible { get; set; }
        //aakansha 12/09/19
        public static void ClearAll()
        {
            UserId = 0;
            FullName = null;
            FirstName = null;
            LastName = null;
            RoleName = null;
            isUserRoleMenuAccessible = null;
            isManageUserMenuAccessible = null;
            isCompanyProfileMenuAccessible = null;
            isHospitalMenuAccessible = null;
            isNurseMenuAccessible = null;
            isDiagnosisMenuAccessible = null;
            isCommentTypeMenuAccessible = null;
            isAuto_TextMenuAccessible = null;
            isEquipmentMenuAccessible = null;
            isPermissionMenuAccessible = null;
            isMaintenanceMenuAccessible = null;
            isAccessAdminPanelMenuAccessible = null;
            isAppointmentMenuAccessible = null;
            isTreatmentRecordMenuAccessible = null;
            isTreatmentReportMenuAccessible = null;
            isMobileAdminMenuAccessible = null;













            #endregion

        }


    }
}
