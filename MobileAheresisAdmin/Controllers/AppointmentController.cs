using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.Appointment;
using CRM.Services.Appointment;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Hospitals;
using CRM.Services.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Models.Appointment;
using MobileAheresisAdmin.Models.Common;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    public class AppointmentController : BaseController
    {
        #region Fields

        private readonly IReportService _reportService;

        private readonly IHospitalServices _hospitalServices;
        private readonly IAppointmentServices _appointmentServices;
        private readonly IPermissionService _permissionService;
        private readonly IEncryptionService _encryptionService;


        #endregion

        #region ctor
        public AppointmentController(IReportService reportService,
            IHospitalServices HospitalServices,
            IAppointmentServices AppointmentServices,
            IPermissionService permissionService,
            IEncryptionService encryptionService)
        {
            this._reportService = reportService;
            this._hospitalServices = HospitalServices;
            this._appointmentServices = AppointmentServices;
            this._permissionService = permissionService;
            this._encryptionService = encryptionService;
        }


        #endregion

        #region Utilities
        //Bhawana(30/09/2019)
        //Save AppointmentDate While creating new Appoinment
        protected virtual void SaveAppointmentDates(AppointmentMaster model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var formData = this.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            String[] AppointmentDate = formData["AppointmentDates"].Split(",");

            String[] RowId = formData["RowId"].Split(",");



            for (int i = 0; i < AppointmentDate.Count(); i++)

            {

                var appointmentDates = new AppointmentDates();

                appointmentDates.AppointmentDate = Convert.ToDateTime(AppointmentDate[i]);
                appointmentDates.AppointmentMasterId = model.Id;
                appointmentDates.AppointmentStatusId = (int)AppointmentStatus.Created;
                model.AppointmentDates.Add(appointmentDates);
            }

            _appointmentServices.UpdateAppointment(model);


        }
        //Bhawana (4/10/2019)
        //Save Appointdate While Editing Appointment
        [HttpPost]
        public virtual IActionResult PostAddAppointmentDates(AppointmentDates model)
        {
            ResponceModel responceModel = new ResponceModel();
            var appointmentData = _appointmentServices.GetAppointmentById(model.AppointmentMasterId);
            var appointmentDate = new AppointmentDates();
            appointmentDate.AppointmentDate = model.AppointmentDate;
            appointmentDate.AppointmentMasterId = model.AppointmentMasterId;
            appointmentDate.AppointmentStatusId = (int)AppointmentStatus.Created;
            appointmentData.AppointmentDates.Add(appointmentDate);
            _appointmentServices.UpdateAppointment(appointmentData);
            responceModel.Success = true;
            responceModel.Message = "Create";
            responceModel.AppointmentDateId = appointmentDate.Id;
            return Json(responceModel);
        }


        #endregion
        //Get List Of Appointment Using Pagination in Stored Procedure
        public IActionResult Index(DataSourceRequest command)
        {
            ViewBag.FormName = "Appointments";
            var model = new AppointmentListModel();
            try
            {
                ViewBag.PageSizeDropdown = SelectListHelper.GetPageSizeDropdown(command.PageSize.ToString());
                var PagedList = _reportService.GetAllAppointment(
                                keywords: "",
                                page_num: command.Page,
                                page_size: command.PageSize == 0 ? 10 : command.PageSize,
                                GetAll: command.PageSize == 0 ? true : false);

                //pratiksha get hospital name in Decrypt format 28/nov/2019
                PagedList = PagedList.Select(a => { a.HospitalName = _encryptionService.DecryptText(a.HospitalName); return a; }).ToList();
                model.List = PagedList.GetPaged(command.Page, command.PageSize, ((PagedList.Count()!= 0)?PagedList[0].TotalRecords:0));
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }
        //Get model for Create New Appointment
        public IActionResult Create()
        {

            ViewBag.FormName = "Appointment";
            if (!(bool)SharedData.isAppointmentMenuAccessible)
                return AccessDeniedView();
            var model = new AppointmentModel();
            model.AppointmentDate = DateTime.UtcNow;

            //23/09/19 aakansha
            model.AvailableHospitals.Add(new SelectListItem { Text = "Select Hospitals", Value = "0" });

            foreach (var c in _hospitalServices.GetAllHospital())
            {
                model.AvailableHospitals.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.HospitalName),
                    Value = c.Id.ToString(),
                    Selected = c.Id == model.HospitalId
                });
            }
            return View(model);
        }

        //Bhawana (24/09/2019)
        //Save New Appointment Data and Edited AppointmentData
        [HttpPost]
        public IActionResult Create(AppointmentModel model)
        {
            if (!(bool)SharedData.isAppointmentMenuAccessible)
                return AccessDeniedView();
            var appointmentId = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    var AppointmentData = new AppointmentMaster();
                    //Insert Appointment
                    if (model.Id == 0)
                    {
                        AppointmentData.HospitalId = model.HospitalId;
                        AppointmentData.PatientName = model.PatientName;
                        AppointmentData.MR = model.MR;
                        AppointmentData.CreatedOn = DateTime.UtcNow;
                        AppointmentData.Deleted = false;

                        _appointmentServices.InsertAppointment(AppointmentData);

                        appointmentId = AppointmentData.Id;
                        SaveAppointmentDates(AppointmentData);
                        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddAppointment, NotificationMessage.TypeSuccess);
                        return RedirectToAction("Index", "Appointment");
                    }

                    //EditAppointment
                    else
                    {
                        AppointmentData.Id = model.Id;
                        AppointmentData.HospitalId = model.HospitalId;
                        AppointmentData.PatientName = model.PatientName;
                        AppointmentData.MR = model.MR;
                        _appointmentServices.UpdateAppointment(AppointmentData);
                        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgEditAppointment, NotificationMessage.TypeSuccess);

                        return RedirectToAction("Index", "Appointment");
                    }
                }
                else
                {
                    model.AvailableHospitals.Add(new SelectListItem { Text = "Select Hospitals", Value = "0" });
                    foreach (var c in _hospitalServices.GetAllHospital())
                        model.AvailableHospitals.Add(new SelectListItem
                        {
                            Text = _encryptionService.DecryptText(c.HospitalName),
                            Value = c.Id.ToString(),
                            Selected = c.Id == model.HospitalId
                        });
                    if (model.Id != 0)
                    {
                        var appointment = _appointmentServices.GetAppointmentById(model.Id);
                        foreach (var ApointmentDate in appointment.AppointmentDates)
                        {
                            var appointmentDate = new AppointmentDatesModel
                            {
                                AppointmentDates = ApointmentDate.AppointmentDate,
                                AppointmentMasterId = ApointmentDate.AppointmentMasterId,
                                Id = ApointmentDate.Id
                            };
                            model._appointmentDates.Add(appointmentDate);
                        }
                    }

                    return View(model);
                }
            }
            catch (Exception e)
            {
                var AppointmentData = _appointmentServices.GetAppointmentById(appointmentId);
                _appointmentServices.DeleteAppointment(AppointmentData);
                model.AvailableHospitals.Add(new SelectListItem { Text = "Select Hospitals", Value = "0" });
                foreach (var c in _hospitalServices.GetAllHospital())
                    model.AvailableHospitals.Add(new SelectListItem
                    {
                        Text = _encryptionService.DecryptText(c.HospitalName),
                        Value = c.Id.ToString(),
                        Selected = c.Id == model.HospitalId
                    });
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);

                return View(model);
            }

        }
        //GetData for Appointment edit
        //27/09/19 aakansha
        // GET: Appointment/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.FormName = "Appointment :#" + id;
            if (!(bool)SharedData.isAppointmentMenuAccessible)
                return AccessDeniedView();
            var appointment = _appointmentServices.GetAppointmentById(id);

            var model = new AppointmentModel
            {
                PatientName = appointment.PatientName,
                MR = appointment.MR,
                Id = appointment.Id,
                HospitalId = appointment.HospitalId,
                AppointmentDate = DateTime.UtcNow
            };

            foreach (var ApointmentDate in appointment.AppointmentDates)
            {
                var appointmentDate = new AppointmentDatesModel
                {
                    AppointmentDates = ApointmentDate.AppointmentDate,
                    AppointmentMasterId = ApointmentDate.AppointmentMasterId,
                    Id = ApointmentDate.Id
                };
                model._appointmentDates.Add(appointmentDate);
            }

            model.AvailableHospitals.Add(new SelectListItem { Text = "Select Hospitals", Value = "0" });
            foreach (var c in _hospitalServices.GetAllHospital())
            {
                model.AvailableHospitals.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.HospitalName),
                    Value = c.Id.ToString(),
                    Selected = c.Id == model.HospitalId
                });
            }
            return View(model);
        }

        //1/10/19 aakansha
        //delete Appointment
        //public virtual IActionResult Delete(int id)
        //{

        //    try
        //    {

        //        var appointment = _appointmentServices.GetAppointmentById(id);

        //        if (appointment == null)
        //            //No product found with the specified id
        //            return RedirectToAction("List");
        //        if (appointment != null)
        //        {
        //            _appointmentServices.DeleteAppointment(appointment);

        //            AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAppointmentDeleted, NotificationMessage.TypeSuccess);
        //            return RedirectToAction("List");
        //        }

        //        AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrormsgAppointmentDeleted, NotificationMessage.TypeError);

        //        return RedirectToAction("List");
        //    }
        //    catch (Exception e)
        //    {

        //        return View(e);
        //    }
        //}

        [HttpPost]
        public virtual IActionResult CancelAppointment(AppointmentDatesModel model)
        {
            //permissions
            if (SharedData.isAppointmentMenuAccessible == false)
                return AccessDeniedView();
            ResponceModel responceModel = new ResponceModel();
            try
            {
                //Get AppointmentDate By Ussing AppointmentId and AppointmentDate
                var appointmentDateData = _appointmentServices.GetAppointmentDateByAppointmentIdAndAppointmentDateId(AppointmentDateId: model.Id, AppointmentId: model.AppointmentMasterId);
                if (appointmentDateData != null)
                {
                    appointmentDateData.AppointmentStatusId = (int)AppointmentStatus.Cancelled;
                    _appointmentServices.UpdateAppointmentDate(appointmentDateData);
                    responceModel.Success = true;
                    responceModel.Message = "Deleted.";
                    return Json(responceModel);
                }
                else
                {
                    responceModel.Success = false;
                    responceModel.Message = "NotDelete";
                    return Json(responceModel);
                }
            }
            catch (Exception e) { }
            responceModel.Success = false;
            responceModel.Message = "NotDelete";
            return Json(responceModel);
        }

        //Bhawana(3/10/2019)
        // Post: Treatment/AppointmentDateDelete/5
        [HttpPost]
        public virtual IActionResult AppointmentDateDelete(int id, int AppointmentId)
        {
            //permissions
            if (SharedData.isAppointmentMenuAccessible == false)
                return AccessDeniedView();
            ResponceModel responceModel = new ResponceModel();
            try
            {
                var appointment = _appointmentServices.GetAppointmentById(AppointmentId);
                var appointmentDate = appointment.AppointmentDates.Where(a => a.Id == id).FirstOrDefault();
                if (appointment == null)
                    //No product found with the specified id
                    return RedirectToAction("List");

                if (appointment != null)
                {
                    _appointmentServices.DeleteAppointmentDate(appointmentDate);
                    responceModel.Success = true;
                    responceModel.Message = "Deleted.";
                    return Json(responceModel);
                }
                else
                {
                    responceModel.Success = false;
                    responceModel.Message = "NotDelete";
                    return Json(responceModel);
                }
            }
            catch (Exception e)
            {
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";
                return Json(responceModel);
            }
        }
    }
}






















