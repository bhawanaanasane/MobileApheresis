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
using MobileAheresisAPI.Utils;

namespace MobileAheresisAPI.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabValueController : ControllerBase
    {

        #region Fields

        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportService;
        #endregion

        #region CTOR

        public LabValueController(
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
        public IActionResult Create(LabValuesModel model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                if (model.Id == 0)
                {
                    var labValues = new LabValues();
                    labValues.EBV = model.EBV;
                    labValues.ECV10 = model.ECV10;
                    labValues.ECV15 = model.ECV15;
                    labValues.EPV = model.EPV;
                    labValues.Height = model.Height;
                    labValues.HGB = model.HGB;
                    labValues.HTC = model.HTC;
                    labValues.PLT = model.PLT;
                    labValues.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    labValues.WBC = model.WBC;
                    labValues.Weight = model.Weight;
                    //Mark Complete
                    labValues.MarkComplete = model.MarkComplete;
                    labValues.Deleted = false;
                    labValues.CreatedOn = DateTime.UtcNow;
                    _treatmentRecordServices.InsertLabValues(labValues);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)labValues.TreatmentRecordMasterId);
                    //Add other Lab Values
                    foreach (var otherLabValues in model.OtherLabValues)
                    {
                        var otherlabvalues = new OtherLabValues();
                        otherlabvalues.LabValuesId = labValues.Id;
                        otherlabvalues.ContentName = otherLabValues.ContentName;
                        otherlabvalues.ContentValue = otherLabValues.ContentValue;
                        labValues.OtherLabValues.Add(otherlabvalues);
                        _treatmentRecordServices.UpdateLabValues(labValues);

                    }
                    //12/10/19 aakansha
                    //model response
                    model.Id = labValues.Id;
                    model.TreatmentRecordMasterId = labValues.TreatmentRecordMasterId;
                    //16/10/19 aakansha
                    var labvalues = _treatmentRecordServices.GetLabValuesById(labValues.Id);
                    foreach (var otherlabvalue in labvalues.OtherLabValues)
                    {
                        var Otherlabvalue = new OtherLabValuesModel();
                        Otherlabvalue.Id = otherlabvalue.Id;
                        Otherlabvalue.LabValuesId = otherlabvalue.LabValuesId;
                        Otherlabvalue.ContentValue = otherlabvalue.ContentValue;
                        Otherlabvalue.ContentName = otherlabvalue.ContentName;
                        model.OtherLabValues.Clear();
                        model.OtherLabValues.Add(Otherlabvalue);

                    }
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);

                }
                else
                {

                    var labValues = _treatmentRecordServices.GetLabValuesById(model.Id);
                    labValues.Id = model.Id;
                    labValues.EBV = model.EBV;
                    labValues.ECV10 = model.ECV10;
                    labValues.ECV15 = model.ECV15;
                    labValues.EPV = model.EPV;
                    labValues.Height = model.Height;
                    labValues.HGB = model.HGB;
                    labValues.HTC = model.HTC;
                    labValues.PLT = model.PLT;
                    //Mark Complete
                    labValues.MarkComplete = model.MarkComplete;
                    labValues.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    labValues.WBC = model.WBC;
                    labValues.Weight = model.Weight;

                    labValues.LastUpdated = DateTime.UtcNow;
                    _treatmentRecordServices.UpdateLabValues(labValues);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)labValues.TreatmentRecordMasterId);

                    //Add other lab Values
                    foreach (var otherLabValues in model.OtherLabValues)
                    {
                        if (otherLabValues.Id == 0)
                        {
                            var otherlabvalues = new OtherLabValues();
                            otherlabvalues.LabValuesId = labValues.Id;
                            otherlabvalues.ContentName = otherLabValues.ContentName;
                            otherlabvalues.ContentValue = otherLabValues.ContentValue;
                            labValues.OtherLabValues.Add(otherlabvalues);
                            _treatmentRecordServices.UpdateLabValues(labValues);
                        }
                        else
                        {
                            var otherlabvalues = _treatmentRecordServices.GetOtherLabValueById(otherLabValues.Id);

                            otherlabvalues.ContentName = otherLabValues.ContentName;
                            otherlabvalues.ContentValue = otherLabValues.ContentValue;

                            _treatmentRecordServices.UpdateOtherLabValues(otherlabvalues);
                        }


                    }
                    //12/10/19 aakansha
                    //model response
                    model.Id = labValues.Id;
                    model.TreatmentRecordMasterId=labValues.TreatmentRecordMasterId;
                    //16/10/19 aakansha
                    var labvalues = _treatmentRecordServices.GetLabValuesById(labValues.Id);
                    foreach( var otherlabvalue in labvalues.OtherLabValues ){
                        var Otherlabvalue = new OtherLabValuesModel();
                        Otherlabvalue.Id = otherlabvalue.Id;
                        Otherlabvalue.LabValuesId = otherlabvalue.LabValuesId;
                        Otherlabvalue.ContentValue = otherlabvalue.ContentValue;
                        Otherlabvalue.ContentName = otherlabvalue.ContentName;
                        model.OtherLabValues.Clear();
                        model.OtherLabValues.Add(Otherlabvalue);

                    }
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
                return Ok(resultModel);
            }

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id) {
            ResultModel resultModel = new ResultModel();
            try {
                var labValueData = _treatmentRecordServices.GetLabValuesById(Id);
                var model = new LabValuesModel();
                model.Id = labValueData.Id;
                model.EBV = (decimal)labValueData.EBV;
                model.ECV10 = (decimal)labValueData.ECV10;
                model.ECV15 = (decimal)labValueData.ECV15;
                model.EPV = (decimal)labValueData.EPV;
                model.Height = (decimal)labValueData.Height;
                model.HGB = (decimal)labValueData.HGB;
                model.HTC = (decimal)labValueData.HTC;
                model.PLT = (decimal)labValueData.PLT;
                model.TreatmentRecordMasterId = labValueData.TreatmentRecordMasterId;
                model.WBC = (decimal)labValueData.WBC;
                model.Weight = (decimal)labValueData.Weight;
                var data = labValueData.OtherLabValues.Select(a =>
               new OtherLabValuesModel
               {
                   ContentName = a.ContentName,
                   ContentValue = a.ContentValue,
                   Id = a.Id,
                   LabValuesId = a.LabValuesId

               });
                model.OtherLabValues = data.ToList();
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = model;
                return Ok(resultModel);
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