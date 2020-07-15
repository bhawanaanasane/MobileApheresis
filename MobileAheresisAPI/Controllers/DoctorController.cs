using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Models.TreatmentRecords;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        #region Fields
       
        private readonly ITreatmentRecordServices _treatmentRecordsServices;
        private readonly IReportService _reportService;
        #endregion

        #region CTOR

        public DoctorController(
            ITreatmentRecordServices TreatmentRecordsServices,
            IReportService ReportService)
        {
            
            this._treatmentRecordsServices = TreatmentRecordsServices;
            this._reportService = ReportService;

        }
        #endregion
        // GET: Doctor
        public ActionResult Index()
        {
            return Ok();
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return Ok();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: Doctor/Create
        [HttpPost("Create")]       
        public ActionResult Create(DoctorInfoModel model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                if (model.Id == 0)
                {
                    var DoctorData = new DoctorInfo();
                    DoctorData.DoctorName = model.DoctorName;
                    DoctorData.EducatioPreTreatmentId = model.EducatioPreTreatmentId;
                    if (DoctorData.EducatioPreTreatmentId == (int)EducatioPreTreatment.Other)
                    {
                        DoctorData.Comments = model.Comments;
                    }
                    else { DoctorData.Comments = null; }
                    DoctorData.OrdersReviewed = model.OrdersReviewed;
                    DoctorData.OutPatient = model.OutPatient;
                    DoctorData.Room = model.Room;
                    DoctorData.MarkComplete = model.MarkComplete;
                    DoctorData.TreatmentRecordMasterId = model.TreatmentRecordMasterId;

                    _treatmentRecordsServices.InsertDoctorInfo(DoctorData);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status

                    _reportService.UpdateTreatmentStatusID((int)DoctorData.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = DoctorData.Id;
                    model.TreatmentRecordMasterId = DoctorData.TreatmentRecordMasterId;
                    
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
                else
                {
                    var DoctorData = _treatmentRecordsServices.GetDoctorInfoById(model.Id);
                    DoctorData.DoctorName = model.DoctorName;
                    DoctorData.EducatioPreTreatmentId = model.EducatioPreTreatmentId;
                    if (DoctorData.EducatioPreTreatmentId == (int)EducatioPreTreatment.Other)
                    {
                        DoctorData.Comments = model.Comments;
                    }
                    else { DoctorData.Comments = null; }
                    DoctorData.OrdersReviewed = model.OrdersReviewed;
                    DoctorData.OutPatient = model.OutPatient;
                    DoctorData.Room = model.Room;
                    //Mark Complete 
                    DoctorData.MarkComplete = model.MarkComplete;
                    DoctorData.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    _treatmentRecordsServices.UpdateDoctorInfo(DoctorData);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)DoctorData.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    // model response
                    model.Id = DoctorData.Id;
                    model.TreatmentRecordMasterId = DoctorData.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
            }
            catch
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null; 
                return Ok(resultModel);
            }
        }


        // GET: Doctor/GetById/5
        [HttpGet("GetById")]
        public ActionResult GetById(int Id)
        {
            try
            {
                ResultModel resultModel = new ResultModel();
                var doctorInfoData = _treatmentRecordsServices.GetDoctorInfoById(Id);
                var model = new DoctorInfoModel();
                model.DoctorName = doctorInfoData.DoctorName;
                model.EducatioPreTreatmentId = doctorInfoData.EducatioPreTreatmentId;
                model.Id = doctorInfoData.Id;
                model.OrdersReviewed = doctorInfoData.OrdersReviewed;
                model.OutPatient = doctorInfoData.OutPatient;
                model.Room = doctorInfoData.Room;
                model.TreatmentRecordMasterId = (int)doctorInfoData.TreatmentRecordMasterId;
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = model;
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }


        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return Ok();
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}