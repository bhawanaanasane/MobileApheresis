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
    public class SuppliesAndAccessController : ControllerBase
    {
        #region Fields
        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportService;
        #endregion
        #region CTOR
        public SuppliesAndAccessController(ITreatmentRecordServices TreatmentRecordServices,
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
        public IActionResult Create(SuppliesAndAccessModel model)
        {
            ResultModel resultModel = new ResultModel();
            try {
                if (model.Id == 0)
                {

                    
                       
                       
                  
                    var supplies = new SuppliesAndAccess();
                    supplies.ACDLot = model.ACDLot;
                    supplies.ACDLotExpDate = model.ACDLotExpDate;
                    supplies.ACEInhibitors = model.ACEInhibitors;
                    supplies.BloodWarmer = model.BloodWarmer;
                    supplies.CreatedOn = DateTime.UtcNow;
                    supplies.DateDC = model.DateDC;
                    supplies.Comments = model.Comments;
                    supplies.CVC = model.CVC;
                    supplies.Locations = model.Locations;
                    supplies.Peripheral = model.Peripheral;
                    supplies.Type = model.Type;
                    supplies.Vortex = model.Vortex;
                    supplies.Deleted = false;                    

                    supplies.LastDoseDate = model.LastDoseDate;
                    supplies.MedsReviewed = model.MedsReviewed;
                    supplies.NSPrimeLot = model.NSPrimeLot;
                    supplies.NSPrimeLotExpDate = model.NSPrimeLotExpDate;
                    supplies.Rate = model.Rate;
                    supplies.Serial = model.Serial;
                    supplies.MarkComplete = model.MarkComplete;
                   
                    supplies.TEMP = model.TEMP;
                    supplies.TreatmentRecordId = model.TreatmentRecordId;
                    _treatmentRecordServices.InsertSupplies(supplies);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)supplies.TreatmentRecordId);

                    //12/10/19 aakansha
                    //model response
                    model.Id = supplies.Id;
                    model.TreatmentRecordId = supplies.TreatmentRecordId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response =model;
                    return Ok(resultModel);
                }
                else
                {
                    var supplies = _treatmentRecordServices.GetSuppliesById(model.Id);
                    supplies.Id = model.Id;
                    supplies.ACDLot = model.ACDLot;
                    supplies.ACDLotExpDate = model.ACDLotExpDate;
                    supplies.ACEInhibitors = model.ACEInhibitors;
                    supplies.BloodWarmer = model.BloodWarmer;
                    supplies.LastUpdated = DateTime.UtcNow;

                    supplies.DateDC = model.DateDC;
                    supplies.Comments = model.Comments;
                    supplies.CVC = model.CVC;
                    supplies.Locations = model.Locations;
                    supplies.Peripheral = model.Peripheral;
                    supplies.Type = model.Type;
                    supplies.Vortex = model.Vortex;
                    supplies.LastDoseDate = model.LastDoseDate;
                    supplies.MedsReviewed = model.MedsReviewed;
                    supplies.NSPrimeLot = model.NSPrimeLot;
                    supplies.NSPrimeLotExpDate = model.NSPrimeLotExpDate;
                    supplies.Rate = model.Rate;
                    supplies.Serial = model.Serial;
                    supplies.TEMP = model.TEMP;
                    supplies.MarkComplete = model.MarkComplete;
                   
                    supplies.TreatmentRecordId = model.TreatmentRecordId;
                    _treatmentRecordServices.UpdateSupplies(supplies);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)supplies.TreatmentRecordId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = supplies.Id;
                    model.TreatmentRecordId = supplies.TreatmentRecordId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
            }
            catch (Exception e)
            {
                resultModel.Message = ValidationMessages.Failure;
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
                var SuppliesData = _treatmentRecordServices.GetSuppliesById(Id);
                var model = new SuppliesAndAccessModel();
                model.Id = SuppliesData.Id;
                model.ACDLot = SuppliesData.ACDLot;

              

                model.ACDLotExpDate = SuppliesData.ACDLotExpDate;
                model.ACEInhibitors = SuppliesData.ACEInhibitors;
                model.BloodWarmer = SuppliesData.BloodWarmer;
                model.CreatedOn = SuppliesData.CreatedOn;
                model.DateDC = SuppliesData.DateDC;

                model.Deleted = SuppliesData.Deleted;              

                model.LastDoseDate = SuppliesData.LastDoseDate;
                model.MedsReviewed = SuppliesData.MedsReviewed;
                model.NSPrimeLot = SuppliesData.NSPrimeLot;
                model.NSPrimeLotExpDate = SuppliesData.NSPrimeLotExpDate;
                model.Rate = SuppliesData.Rate;
                model.Serial = SuppliesData.Serial;
                model.TEMP = SuppliesData.TEMP;

                model.TreatmentRecordId = SuppliesData.TreatmentRecordId;

                model.Comments = SuppliesData.Comments;
               model.CVC = SuppliesData.CVC;
                model.Locations = SuppliesData.Locations;
               model.Peripheral = SuppliesData.Peripheral;            
               model.Type = SuppliesData.Type;
                model.Vortex = SuppliesData.Vortex;
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