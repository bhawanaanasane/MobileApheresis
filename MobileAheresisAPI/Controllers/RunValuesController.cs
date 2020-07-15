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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RunValuesController : ControllerBase
    {
        #region Field
        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportService;
        #endregion
        #region CTOR
        public RunValuesController(ITreatmentRecordServices TreatmentRecordServices,
            IReportService ReportService)
        {
            this._treatmentRecordServices = TreatmentRecordServices;
            this._reportService = ReportService;
        }
        #endregion
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost("Create")]
        public IActionResult Create(RunValuesListModel modelList)
      {
            ResultModel resultModel = new ResultModel();

          
            if (modelList.runValuesList.Count() != 0)
            {
                var runvalueListmodel = new List<RunValuesModel>();
                foreach (var data in modelList.runValuesList)
                {
                    try
                    {
                        var runValuesDAta = new RunValues();

                        if (data.Id == 0)
                        {
                           

                            runValuesDAta.ACFlowRate = data.ACFlowRate;

                            runValuesDAta.ACFlowVol = data.ACFlowVol;

                            runValuesDAta.BP = data.BP;


                            runValuesDAta.CollectFlowRate = data.CollectFlowRate;
                            runValuesDAta.CollectFlowVol = data.CollectFlowVol;
                            runValuesDAta.IntelFlowRate = data.IntelFlowRate;
                            runValuesDAta.IntelFlowVol = data.IntelFlowVol;
                            runValuesDAta.MarkComplete = modelList.MarkComplete;
                            runValuesDAta.LotNo = data.LotNo;

                            runValuesDAta.TreatmentRecordMasterId = data.TreatmentRecordMasterId;
                            runValuesDAta.P = data.P;

                            runValuesDAta.PlasmaFlowRate = data.PlasmaFlowRate;

                            runValuesDAta.PlasmaFlowVol = data.PlasmaFlowVol;
                            runValuesDAta.R = data.R;
                            runValuesDAta.ReplaceFluidId = data.ReplaceFluidId;
                            runValuesDAta.RunTime = data.RunTime;
                            runValuesDAta.T = data.T;
                            runValuesDAta.WarmerTemp = data.WarmerTemp;
                            runValuesDAta.CreatedOn = DateTime.UtcNow;
                            runValuesDAta.LastUpdated = DateTime.UtcNow;
                            runValuesDAta.Deleted = false;

                            _treatmentRecordServices.InsertRunValues(runValuesDAta);
                            //12/10/19 aakansha
                            //model response
                            var responceRunvalues = new RunValuesModel();
                            responceRunvalues.Id = runValuesDAta.Id;
                            responceRunvalues.TreatmentRecordMasterId = runValuesDAta.TreatmentRecordMasterId;
                            responceRunvalues.ReplaceFluidId = runValuesDAta.ReplaceFluidId;
                            runvalueListmodel.Add(responceRunvalues);



                        }
                        else
                        {
                           runValuesDAta = _treatmentRecordServices.GetRunValuesById(data.Id);

                            runValuesDAta.ACFlowRate = data.ACFlowRate;

                            runValuesDAta.ACFlowVol = data.ACFlowVol;

                            runValuesDAta.BP = data.BP;
                            runValuesDAta.MarkComplete = modelList.MarkComplete;

                            runValuesDAta.CollectFlowRate = data.CollectFlowRate;
                            runValuesDAta.CollectFlowVol = data.CollectFlowVol;
                            runValuesDAta.IntelFlowRate = data.IntelFlowRate;
                            runValuesDAta.IntelFlowVol = data.IntelFlowVol;

                            runValuesDAta.LotNo = data.LotNo;

                            runValuesDAta.TreatmentRecordMasterId = data.TreatmentRecordMasterId;
                            runValuesDAta.P = data.P;

                            runValuesDAta.PlasmaFlowRate = data.PlasmaFlowRate;

                            runValuesDAta.PlasmaFlowVol = data.PlasmaFlowVol;
                            runValuesDAta.R = data.R;
                            runValuesDAta.ReplaceFluidId = data.ReplaceFluidId;
                            runValuesDAta.RunTime = data.RunTime;
                            runValuesDAta.T = data.T;
                            runValuesDAta.WarmerTemp = data.WarmerTemp;
                            runValuesDAta.CreatedOn = DateTime.UtcNow;
                            runValuesDAta.LastUpdated = DateTime.UtcNow;
                            runValuesDAta.Deleted = false;

                            _treatmentRecordServices.UpdateRunValues(runValuesDAta);
                            //12/10/19 aakansha
                            //model response
                            var responceRunvalues = new RunValuesModel();
                            responceRunvalues.Id = runValuesDAta.Id;
                            responceRunvalues.TreatmentRecordMasterId = runValuesDAta.TreatmentRecordMasterId;
                            responceRunvalues.ReplaceFluidId = runValuesDAta.ReplaceFluidId;
                            runvalueListmodel.Add(responceRunvalues);



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
                //Bhawana(09/10/2019)
                //Change treatment Record Status
                _reportService.UpdateTreatmentStatusID((int)modelList.runValuesList[0].TreatmentRecordMasterId);
                modelList.runValuesList = runvalueListmodel;


                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = modelList;
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

        // GET: MobileAheresis/GetByTreatmentRecordId/5
        [HttpGet("GetByTreatmentRecordId")]
        public ActionResult GetByTreatmentRecordId(int TreatmentRecordId)
        {
            ResultModel resultModel = new ResultModel();
            try
            {

                var runValuesData = new RunValuesListModel();
                var runValueListData = _treatmentRecordServices.GetRunValuesByTreatmentRecordId(TreatmentRecordId);
                var data = runValueListData.Select(a =>
                new RunValuesModel
                {
                    Id= a.Id,
                    ACFlowRate = a.ACFlowRate,

                    ACFlowVol = a.ACFlowVol,

                    BP = a.BP,


                    CollectFlowRate = a.CollectFlowRate,
                    CollectFlowVol = a.CollectFlowVol,
                    IntelFlowRate = a.IntelFlowRate,
                    IntelFlowVol = a.IntelFlowVol,

                    LotNo = a.LotNo,

                    TreatmentRecordMasterId = a.TreatmentRecordMasterId,
                    P = a.P,

                    PlasmaFlowRate = a.PlasmaFlowRate,

                    PlasmaFlowVol = a.PlasmaFlowVol,
                    R = a.R,
                    ReplaceFluidId = a.ReplaceFluidId,
                    RunTime = a.RunTime,
                    T = a.T,
                    WarmerTemp = a.WarmerTemp,
                    CreatedOn = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow,
                    Deleted = false
                });

                runValuesData.runValuesList = data.ToList();

                if (runValuesData.runValuesList.Count() != 0)
                {
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = runValuesData;
                    return Ok(resultModel);
                }
                else {
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