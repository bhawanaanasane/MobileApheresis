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
    public class FinalValuesAndAccessPostTreatmentController : ControllerBase
    {
        #region Fields

        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportService;
        #endregion

        #region CTOR

        public FinalValuesAndAccessPostTreatmentController(
            ITreatmentRecordServices TreatmentRecordsServices,
            IReportService ReportService)
        {

            this._treatmentRecordServices = TreatmentRecordsServices;
            this._reportService = ReportService;

        }
        #endregion
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("Create")]
        public IActionResult Create(FinalValuesAndAccessPostAssessmentModel model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                if (model.Id == 0)
                {                         


                    var finalValues = new FinalValuesAndAccessPostAssessment();
                    finalValues.AC = model.AC;
                    
                    finalValues.BP = model.BP;
                    finalValues.Collet = model.Collet;
                    finalValues.FluidBalance = model.FluidBalance;
                    finalValues.Inlet = model.Inlet;

                    finalValues.P = model.P;

                    finalValues.Plasma = model.Plasma;
                    finalValues.R = model.R;
                    finalValues.T = model.T;
                    finalValues.Time = model.Time;
                    finalValues.TreatmentRecordId = model.TreatmentRecordId;
                    finalValues.ChlorhexidineCapApplied = model.ChlorhexidineCapApplied;
                    finalValues.Comments = model.Comments;
                    finalValues.Heparin = model.Heparin;
                    finalValues.Intact = model.Intact;
                    finalValues.NewDressing = model.NewDressing;
                    finalValues.Reinforced = model.Reinforced;
                    finalValues.Saline = model.Saline;
                    //Mark Complete 
                    finalValues.MarkComplete = model.MarkComplete;
                    finalValues.CreatedOn = DateTime.UtcNow;
                    finalValues.Deleted = false;
                   
                    _treatmentRecordServices.InsertFinalValues(finalValues);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)finalValues.TreatmentRecordId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = finalValues.Id;
                    model.TreatmentRecordId = finalValues.TreatmentRecordId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
                else
                {                   
                    var finalValues = _treatmentRecordServices.GetFinalValuesById(model.Id);
                    finalValues.AC = model.AC;
                    
                    finalValues.BP = model.BP;
                    finalValues.Collet = model.Collet;
                    finalValues.FluidBalance = model.FluidBalance;
                    finalValues.Inlet = model.Inlet;

                    finalValues.P = model.P;

                    finalValues.Plasma = model.Plasma;
                    finalValues.R = model.R;
                    finalValues.T = model.T;
                    finalValues.Time = model.Time;
                    finalValues.TreatmentRecordId = model.TreatmentRecordId;
                    finalValues.ChlorhexidineCapApplied = model.ChlorhexidineCapApplied;
                    finalValues.Comments = model.Comments;
                    finalValues.Heparin = model.Heparin;
                    finalValues.Intact = model.Intact;
                    finalValues.NewDressing = model.NewDressing;
                    //Mark Complete 
                    finalValues.MarkComplete = model.MarkComplete;
                    finalValues.Reinforced = model.Reinforced;
                    finalValues.Saline = model.Saline;
                    finalValues.LastUpdated = DateTime.UtcNow;
               
                    _treatmentRecordServices.UpdateFinalValues(finalValues);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)finalValues.TreatmentRecordId);



                    // 12/10/19 aakansha
                    //model response
                    model.Id = finalValues.Id;
                    model.TreatmentRecordId = finalValues.TreatmentRecordId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
            }
            catch (Exception e)
            {
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = null;
                return Ok(resultModel);
            }

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                var finalValue = _treatmentRecordServices.GetFinalValuesById(Id);
                var model = new FinalValuesAndAccessPostAssessmentModel();
                model.Id = finalValue.Id;
                model.AC = (int)finalValue.AC;
               
                model.BP = finalValue.BP;
                model.Collet = (int)finalValue.Collet;
                model.FluidBalance = finalValue.FluidBalance;
                model.Inlet = (int)finalValue.Inlet;

                model.P = (int)finalValue.P;

                model.Plasma = (int)finalValue.Plasma;
                model.R = (int)finalValue.R;
                model.T = (int)finalValue.T;
                model.Time = (int)finalValue.Time;
                model.TreatmentRecordId = finalValue.TreatmentRecordId;
                model.ChlorhexidineCapApplied = finalValue.ChlorhexidineCapApplied;
                    model.Comments = finalValue.Comments;
                    model.Heparin = finalValue.Heparin;
                    model.Intact = finalValue.Intact;
                    model.NewDressing = finalValue.NewDressing;
                    model.Reinforced = finalValue.Reinforced;
                model.Saline = finalValue.Saline;

                if (model != null)
                {
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
                else
                {
                    resultModel.Message = ValidationMessages.Failure;
                    resultModel.Status = 0;
                    resultModel.Response = null;
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
    }
}