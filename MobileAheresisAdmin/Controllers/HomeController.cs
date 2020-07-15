using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core;
using CRM.Services.Appointment;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.CompanyProfiles;
using CRM.Services.Customers;
using CRM.Services.Hospitals;
using CRM.Services.Nurses;
using CRM.Services.Security;
using CRM.Services.Treatements;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Filters;
using MobileAheresisAdmin.Models;
using MobileAheresisAdmin.Utils;
using Newtonsoft.Json;

namespace MobileAheresisAdmin.Controllers
{
   [AuthorizeAdmin]
    public class HomeController : BaseController
    {
        #region Fields


        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;
        private readonly IReportService _reportService;
		private readonly ITreatmentRecordServices _treatmentRecordServices;
		private readonly ITreatmentServices _treatmentServices;
        private readonly IEncryptionService _encryptionService;
        private readonly INurseServices _nurseServices;
        private readonly IHospitalServices _hospitalServices;
        private readonly IAppointmentServices _appointmentServices;
        private readonly ICompanyProfileService _companyProfileService;
        private readonly IExcelService excelService;
       

        #endregion

        #region Ctor

        public HomeController(
            IPermissionService permissionService,
            IWorkContext workContext,
			ITreatmentRecordServices TreatmentRecordServices,
			ITreatmentServices TreatmentServices,
		   IReportService ReportService,
           IEncryptionService encryptionService,
            INurseServices NurseServices,
            IHospitalServices HospitalServices,
             ICompanyProfileService CompanyProfileService,
              IAppointmentServices AppointmentServices,
              IExcelService excelService

            )
        {
           
            this._permissionService = permissionService;
			this._treatmentRecordServices = TreatmentRecordServices;
			this._treatmentServices = TreatmentServices;
			this._workContext = workContext;
            this._reportService = ReportService;
            this._encryptionService = encryptionService;
            this._nurseServices = NurseServices;
            this._hospitalServices = HospitalServices;
            this._appointmentServices = AppointmentServices;
            this._companyProfileService = CompanyProfileService;
            this.excelService = excelService;
        }

        #endregion
        public IActionResult Index()
        {
            ViewBag.FormName = "Dashboard";
            //permission

            if (SharedData.isManageUserMenuAccessible == null) 
            {
                SharedData.FirstName = _workContext.CurrentCustomer.BillingAddress.FirstName;
                SharedData.LastName = _workContext.CurrentCustomer.BillingAddress.LastName;
                SharedData.isManageUserMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageUsers);
                SharedData.isAccessAdminPanelMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel);
                SharedData.isMaintenanceMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.Maintenance);
                SharedData.isUserRoleMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageUserRoles);
                SharedData.isCompanyProfileMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageCompanyProfile);
                SharedData.isHospitalMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageHospital);
                SharedData.isNurseMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageNurse);
                SharedData.isDiagnosisMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageDiagnosis);
                SharedData.isCommentTypeMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageCommentType);
                SharedData.isAuto_TextMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageAuto_Text);
                SharedData.isEquipmentMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageEquipment);
                SharedData.isAppointmentMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageAppointment);
                SharedData.isPermissionMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManagePermission);
                SharedData.isTreatmentRecordMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageTreatmentRecord);
                SharedData.isTreatmentReportMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageTreatmentReport);
                SharedData.isMobileAdminMenuAccessible = _permissionService.Authorize(StandardPermissionProvider.ManageMobileAdmin);

            }

            var d = _permissionService.Authorize(StandardPermissionProvider.Maintenance);
            if (!_permissionService.Authorize(StandardPermissionProvider.Maintenance))
            {
            }

            string[] SelectedDate = (DateTime.UtcNow.ToString().Contains("/") == true) ? DateTime.UtcNow.ToString("MM/dd/yyyy").Split('/') : DateTime.UtcNow.ToString("MM-dd-yyyy").Split('-');
            int Month = Convert.ToInt32(SelectedDate[0]);
            int Day = Convert.ToInt32(SelectedDate[1]);
            int Year = Convert.ToInt32(SelectedDate[2]);
            var TodayDate = new DateTime(Year, Month, Day).ToString("MM/dd/yyyy");
            DateTime ss = new DateTime(Year, Month, 1);
            var date = ss.AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy");

            //Today's Data
            var result = _reportService.GetDashboardDetails(Convert.ToString(DateTime.Now.Year) + "-1-1", Convert.ToString(DateTime.Now.Year) + "-12-31", ss.ToString("MM/dd/yyyy"), date,TodaysDate: TodayDate);

            //Week's Data
            DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = DateTime.UtcNow.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            var StartDate = firstDayInWeek.AddDays(1);
            var EndDate = StartDate.AddDays(6);
            //var WeekData = _reportService.GetDashboardDetails(StartDate: Convert.ToString(StartDate), EndDate: Convert.ToString(EndDate), ss.ToString("MM/dd/yyyy"), date);
            //SharedData.DeliveryRequests = WeekData.WeekDeliveryRequests;
            //SharedData.ShippingRequests = WeekData.WeekShippingRequests;
            //SharedData.ReceivingLogs = WeekData.WeekReceivingLogs;
            //SharedData.PickupLists = WeekData.WeekPickupLists;
            //SharedData.CurrentUserId = _workContext.CurrentCustomer.Id;           
            ViewBag.WRDeliveryRequests = JsonConvert.SerializeObject(result.CalendarDatas);
           

            return View(result);
           
        }
        //28/08/19 aakansha
        //string Date
        public string GetEvents(string Date)
        {
            string[] SelectedDate = Date.Split('/');
            int Month = Convert.ToInt32(SelectedDate[0]);
            //int Day = Convert.ToInt32(SelectedDate[1]);
            int Year = Convert.ToInt32(SelectedDate[2]);

            DateTime ss = new DateTime(Year, Month, 1);
            var date = ss.AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy");
            var result = _reportService.GetDastboardCalendarData(ss.ToString("MM/dd/yyyy"), date);
            return JsonConvert.SerializeObject(result);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		#region Dropdowns
		private IList<SelectListItem> PrepareSortByDropdown(string SelectedText = "", int Id = 0)
		{
			List<SelectListItem> items = new List<SelectListItem>();
			items.Add(new SelectListItem { Text = "All", Value = "All", Selected = (SelectedText == "All") });
			items.Add(new SelectListItem { Text = "By Patient", Value = "By Patient", Selected = (SelectedText == "By Patient") });
			items.Add(new SelectListItem { Text = "By Hospital", Value = "By Hospital", Selected = (SelectedText == "By Hospital") });

			items.Add(new SelectListItem { Text = "By Nurse", Value = "By Nurse", Selected = (SelectedText == "By Nurse") });
			items.Add(new SelectListItem { Text = "By Diagnosis", Value = "By Diagnosis", Selected = (SelectedText == "By Diagnosis") });

			items.Add(new SelectListItem { Text = "By Procedure", Value = "By Procedure", Selected = (SelectedText == "By Procedure") });
			items.Add(new SelectListItem { Text = "By Date", Value = "By Date", Selected = (SelectedText == "By Date") });

			items.Add(new SelectListItem { Text = "Machine QA", Value = "Machine QA", Selected = (SelectedText == "Machine QA") });


			return items;
		}
		#endregion
	

	#region Reports Dropdown
	private IList<SelectListItem> PreparePatientDropdown(string SelectedText = "Select Patient", int Id = 0)
		{
			var PatientList = _treatmentRecordServices.GetAllPatientMaster().Where(a => a.Deleted != true);
			List<SelectListItem> items = new List<SelectListItem>();
            foreach(var patientdata in PatientList)
               { items.Add(new SelectListItem {
                Text = _encryptionService.DecryptText(patientdata.PatientName), Value = patientdata.Id.ToString() });
               }
			
			

			return items;
		}
        private IList<SelectListItem> PrepareNurseDropdown(string SelectedText = "Select Nurse", int Id = 0)
        {
            var PatientList = _nurseServices.GetAllNurse().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Nursedata in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(Nursedata.FirstName) + " " + _encryptionService.DecryptText(Nursedata.LastName),
                    Value = Nursedata.Id.ToString()
                });
            }



            return items;
        }

        private IList<SelectListItem> PrepareHospitalDropdown(string SelectedText = "Select Hospital", int Id = 0)
        {
            var PatientList = _hospitalServices.GetAllHospital().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Hospitaldata in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(Hospitaldata.HospitalName) ,
                    Value = Hospitaldata.Id.ToString()
                });
            }



            return items;
        }


        private IList<SelectListItem> PrepareDiagnosisDropdown(string SelectedText = "Select Diagnosis", int Id = 0)
        {
            var PatientList = _treatmentServices.GetAllDiagnosis().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Diagnosisdata in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = Diagnosisdata.DiagnosisName,
                    Value = Diagnosisdata.Id.ToString()
                });
            }



            return items;
        }
        private IList<SelectListItem> PrepareMRDropdown(string SelectedText = "Select MR", int Id = 0)
        {
            var PatientList = _appointmentServices.GetAllAppointment().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var MRData in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = MRData.MR,
                    Value = MRData.Id.ToString()
                });
            }



            return items;
        }

        private IList<SelectListItem> PrepareProcedureDropdown(string SelectedText = "Select Procedure", int Id = 0)
        {
            var PatientList =  _companyProfileService.GetAllCompanyProfile().PoliciesAndProcedures.Where(a => a.IsPolicy == false);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var MRData in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = MRData.Text,
                    Value = MRData.Id.ToString()
                });
            }



            return items;
        }



        //private IList<SelectListItem> PrepareProDropdown(string SelectedText = "Select Procedure", int Id = 0)
        //{
        //    var PatientList = _companyProfileService.GetAllCompanyProfile().PoliciesAndProcedures.Where(a => a.IsPolicy == false);
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    foreach (var MRData in PatientList)
        //    {
        //        items.Add(new SelectListItem
        //        {
        //            Text = MRData.Text,
        //            Value = MRData.Id.ToString()
        //        });
        //    }



        //    return items;
        //}




        #endregion

    }
}
