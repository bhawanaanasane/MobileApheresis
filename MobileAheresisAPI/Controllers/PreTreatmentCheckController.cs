using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Models.TreatmentRecords;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreTreatmentCheckController : ControllerBase
    {
        #region Fields
        private readonly ITreatmentRecordServices _treatmentRecordsServices;
        private readonly IReportService _reportService;
        #endregion

        #region CTOR
        public PreTreatmentCheckController(ITreatmentRecordServices TreatmentRecordsServices,
            IReportService ReportService)
        {
            this._treatmentRecordsServices = TreatmentRecordsServices;
            this._reportService = ReportService;
        }
        #endregion
        public IActionResult Index()
        {
            return Ok();
        }
       [HttpPost("Create")] 
        public IActionResult Create(PreTreatmentCheckModel model)
        {
            ResultModel resultModel = new ResultModel();
            try {
                if (model.Id == 0)
                {
                    var preTreatment = new PreTreatmentCheck();

                    preTreatment.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    preTreatment.UniversalPrecautions = model.UniversalPrecautions;
                    preTreatment.MachinePrimeId = model.MachinePrimeId;
                    preTreatment.InformedConsent = model.InformedConsent;
                    preTreatment.BloodConsent = model.BloodConsent;
                    preTreatment.AlarmTest = model.AlarmTest;
                    preTreatment.MarkComplete = model.MarkComplete;
                    _treatmentRecordsServices.InsertPreTreatmentCheck(preTreatment);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)preTreatment.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = preTreatment.Id;
                    model.MachinePrimeId = preTreatment.MachinePrimeId;
                    model.TreatmentRecordMasterId = preTreatment.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response =model;
                    return Ok(resultModel);
                }
                else
                {
                    var preTreatment = _treatmentRecordsServices.GetPreTreatmentCheckById(model.Id);
                    preTreatment.Id = model.Id;
                    preTreatment.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    preTreatment.UniversalPrecautions = model.UniversalPrecautions;
                    preTreatment.MachinePrimeId = model.MachinePrimeId;
                    preTreatment.InformedConsent = model.InformedConsent;
                    preTreatment.BloodConsent = model.BloodConsent;
                    preTreatment.AlarmTest = model.AlarmTest;
                    preTreatment.MarkComplete = model.MarkComplete;
                    _treatmentRecordsServices.UpdatePreTreatmentCheck(preTreatment);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)preTreatment.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = preTreatment.Id;
                    model.MachinePrimeId = preTreatment.MachinePrimeId;
                    model.TreatmentRecordMasterId = preTreatment.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
            }
            catch (Exception e)
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok();
            }
           
        }

        // GET: PreTreatmentCheck/GetById/5
        [HttpGet("GetById")]
        public ActionResult GetById(int Id)
        {
            try
            {
                ResultModel resultModel = new ResultModel();
                var pretreatmentData = new PreTreatmentCheckModel();
                var preTreatmentData = _treatmentRecordsServices.GetPreTreatmentCheckById(Id);
                pretreatmentData.Id = preTreatmentData.Id;
                pretreatmentData.TreatmentRecordMasterId = preTreatmentData.TreatmentRecordMasterId;
                pretreatmentData.BloodConsent = preTreatmentData.BloodConsent;
                pretreatmentData.AlarmTest = preTreatmentData.AlarmTest;
                pretreatmentData.MachinePrimeId = preTreatmentData.MachinePrimeId;
                pretreatmentData.InformedConsent = preTreatmentData.InformedConsent;

                pretreatmentData.UniversalPrecautions = preTreatmentData.UniversalPrecautions;
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = pretreatmentData;
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
    }
}