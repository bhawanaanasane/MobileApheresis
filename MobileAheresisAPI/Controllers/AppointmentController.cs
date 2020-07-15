using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.Appointment;
using CRM.Services.Appointment;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Appointment;
using MobileAheresisAPI.Models.Result;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        #region Fields
        private readonly IReportService _reportService;
        private readonly IAppointmentServices _appointmentServices;
        private readonly IEncryptionService _encryptionService;
        #endregion
        #region ctor
        public AppointmentController(IReportService reportService, IAppointmentServices AppointmentServices,
                IEncryptionService encryptionService)
        {
            this._reportService = reportService;
            this._appointmentServices = AppointmentServices;
            this._encryptionService = encryptionService;
        }

        #endregion
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost("Create")]
        public IActionResult Create(AppointmentModel model)
        {
            ResultModel resultModel = new ResultModel();
            var AppointmentData = new AppointmentMaster();
            try
            {
                if (ModelState.IsValid)
                {

                    if (model.ID == 0)
                    {
                        AppointmentData.HospitalId = model.HospitalId;
                        AppointmentData.PatientName = model.PatientName;
                        AppointmentData.MR = model.MR;
                        _appointmentServices.InsertAppointment(AppointmentData);
                        SaveAppointmentDates(AppointmentData, model._appointmentDates);
                        resultModel.Message = ValidationMessages.Success;
                        resultModel.Status = 1;
                        resultModel.Response = "Appointment Created";
                        return Ok(resultModel);
                    }
                    else
                    {
                        var appointmentData = _appointmentServices.GetAppointmentById(model.ID);
                        appointmentData.Id = model.ID;
                        appointmentData.HospitalId = model.HospitalId;
                        appointmentData.PatientName = model.PatientName;
                        appointmentData.MR = model.MR;                        
                        _appointmentServices.UpdateAppointment(appointmentData);
                        SaveAppointmentDates(appointmentData, model._appointmentDates);
                        resultModel.Message = ValidationMessages.Success;
                        resultModel.Status = 1;
                        resultModel.Response = "Appointment Edited";
                        return Ok(resultModel);

                    }
                }
                else
                {
                    resultModel.Message = ValidationMessages.Failure;
                    resultModel.Status = 0;
                    resultModel.Response = "Appointment not created";
                    return Ok(resultModel);
                }
               
            }
            catch (Exception e)
            {
              
                _appointmentServices.DeleteAppointment(AppointmentData);
                return Ok(model);
            }

        }
        protected virtual void SaveAppointmentDates(AppointmentMaster model,List<AppointmentDatesModel> appointmentDatesModels)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));           
            foreach (var item in appointmentDatesModels)
            {
                if (item.ID == 0)
                {          
                  var appointmentDates = new AppointmentDates();
                    appointmentDates.AppointmentDate = Convert.ToDateTime(item.AppointmentDate);
                    appointmentDates.AppointmentStatusId = (int)AppointmentStatus.Created;
                    appointmentDates.AppointmentMasterId = model.Id;
                    model.AppointmentDates.Add(appointmentDates);

                    
                }
            }
            _appointmentServices.UpdateAppointment(model);
        }

        [HttpPost("GetAllAppointments")]
        public IActionResult GetAllAppointments(GetAppointmentPaginationVM model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                var _AppointmentList = _reportService.GetAllAppointment(page_num: model.Page,
                        page_size: model.PageSize == 0 ? 10 : model.PageSize,
                        GetAll: true,
                        keywords: model.Keyword);
                _AppointmentList = _AppointmentList.Select(a => { a.HospitalName = _encryptionService.DecryptText(a.HospitalName); return a; }).ToList();

                foreach (var item in _AppointmentList)
                {
                    item._appointmentDates = _reportService.GetAppointmentDates(item.Id);
                }

                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = _AppointmentList;
                return Ok(resultModel);
            }
            catch(Exception ex)
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }

        }

        [HttpGet("GetAppointmentDate")]
        public IActionResult GetAppointmentDate(int AppointmentDateId)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                var _AppointmentDates = _reportService.GetAppointmentDates(AppointmentDateId);               
               

                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = _AppointmentDates;
                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }

        }

        [HttpPost("CancelAppointment")]
        public IActionResult CancelAppointment(AppointmentDatesModel model)
        {
            //permissions
            //if (SharedData.isAppointmentMenuAccessible == false)
            //    return AccessDeniedView();
            ResultModel resultModel = new ResultModel();
            try
            {
                //Get AppointmentDate By Ussing AppointmentId and AppointmentDate
                var appointmentDateData = _appointmentServices.GetAppointmentDateByAppointmentIdAndAppointmentDateId(AppointmentDateId: model.ID, AppointmentId: model.AppointmentMasterId);
                if (appointmentDateData != null)
                {
                    appointmentDateData.AppointmentStatusId = (int)AppointmentStatus.Cancelled;
                    _appointmentServices.UpdateAppointmentDate(appointmentDateData);
                    resultModel.Status = 1;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Response = "Appointmnet Cancelled ";
                    return Ok(resultModel);
                }
                else
                {
                    resultModel.Message = ValidationMessages.Failure;
                    resultModel.Status = 0;
                    resultModel.Response = "Appointment NotCancelled";
                    return Ok(resultModel);

                }
            }
            catch (Exception e)
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }

        }
        [HttpGet("DeleteAppointmentDate")]
        public IActionResult DeleteAppointmentDate(int Id)
        {
            ResultModel resultModel = new ResultModel();
            if (Id != 0) {
                var appointmentDateData = _appointmentServices.GetAppointmentDateById(Id);
                _appointmentServices.DeleteAppointmentDate(appointmentDateData);
                resultModel.Status = 1;
                resultModel.Message = ValidationMessages.Success;
                resultModel.Response = "Appointmnet Date Deleted ";
                return Ok(resultModel); }
            else
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = "Appointment Date not found";
                return Ok(resultModel);
            }
           
        }

    }
}