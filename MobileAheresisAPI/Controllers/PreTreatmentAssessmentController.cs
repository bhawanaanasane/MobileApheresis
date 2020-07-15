using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Treatements;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Models.Treatment;
using MobileAheresisAPI.Models.TreatmentRecords;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreTreatmentAssessmentController : ControllerBase
    {
        #region Fields
        private readonly ITreatmentServices _treatmentServices;
        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportService;
        #endregion
        #region CTOR
        public PreTreatmentAssessmentController(ITreatmentServices TreatmentServices,
            ITreatmentRecordServices TreatmentRecordServices,
            IReportService ReportService)
        {
            this._treatmentRecordServices = TreatmentRecordServices;
            this._treatmentServices = TreatmentServices;
            this._reportService = ReportService;
        }
        #endregion

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("GetAllAutoText")]
        public IActionResult GetAllAutoText()
        {
            ResultModel resultModel = new ResultModel();
            var model = new PreTreatmentAssessmentMasterModel();
            var WeaknessAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Weakness" && a.IsActive == true && a.Deleted == false);
            var NumbnessAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Numbness/Tingling" && a.IsActive == true && a.Deleted == false);
            var PainAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "pain Level" && a.IsActive == true && a.Deleted == false);
            var LocationAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Location on Body" && a.IsActive == true && a.Deleted == false);
            var LungSoundsAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Lung Sounds" && a.IsActive == true && a.Deleted == false);
            var RhythmAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Cardiac Rhythm" && a.IsActive == true && a.Deleted == false);
            var EdemaAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Edema" && a.IsActive == true && a.Deleted == false);
            var BleedingAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Bleeding" && a.IsActive == true && a.Deleted == false);
            var SkinAutoTextData = _treatmentServices.GetAllAutoText().Where(a => a.CommentType.CommentTypeName == "Skin" && a.IsActive == true && a.Deleted == false);

            var weaknesstextData = WeaknessAutoTextData.Select(a =>
            new AutoTextModel {
            Id=a.Id,
            AutoTextName =a.AutoTextName,
            Comment =a.Comment,
            CommentTypeId = a.CommentTypeId,
            CommentTypeName = a.CommentType.CommentTypeName,
            CreatedOn =a.CreatedOn,
            Deleted =a.Deleted,
            IsActive =a.IsActive,
            LastUpdated= a.LastUpdated});
            var numbnessAutoTextData = NumbnessAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });
            var painAutoTextData = PainAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });
            var locationAutoTextData = LocationAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });
            var lungSoundsAutoTextData = LungSoundsAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });
            var rhythmAutoTextData = RhythmAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });
            var edemaAutoTextData = EdemaAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });
            var bleedingAutoTextData = BleedingAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });
            var skinAutoTextData = SkinAutoTextData.Select(a =>
            new AutoTextModel {
                Id = a.Id,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = a.CommentType.CommentTypeName,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                IsActive = a.IsActive,
                LastUpdated = a.LastUpdated
            });

            model.WeaknessAutoTexts = weaknesstextData.ToList();
            model.NumbnessAutoTexts = numbnessAutoTextData.ToList();
            model.PainAutoTexts = painAutoTextData.ToList();
            model.LocationAutoTexts = locationAutoTextData.ToList();
            model.LungSoundsAutoTexts = lungSoundsAutoTextData.ToList();
            model.RhythmAutoTexts = rhythmAutoTextData.ToList();
            model.EdemaAutoTexts = edemaAutoTextData.ToList();
            model.BleedingAutoTexts = bleedingAutoTextData.ToList();
            model.SkinAutoTexts = skinAutoTextData.ToList();

            if (model != null)
            {
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = model;
                return Ok(resultModel);
            }
            else
            {
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = model;
                return Ok(resultModel);
            }           
        }

        [HttpPost("Create")]
        public IActionResult Create(PreTreatmentAssessmentModel model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                if (model.Id == 0)
                {
                    var preTreatmentAssessment = new PreTreatmentAssessment();

                    preTreatmentAssessment.BleendAutoTextId = model.BleendAutoTextId;

                    preTreatmentAssessment.EdemaAutoTextId = model.EdemaAutoTextId;

                    preTreatmentAssessment.IsAlert = model.IsAlert;


                    preTreatmentAssessment.IsBleeding = model.IsBleeding;
                    preTreatmentAssessment.IsComatose = model.IsComatose;
                    preTreatmentAssessment.IsEasy = model.IsEasy;
                    preTreatmentAssessment.IsEdema = model.IsEdema;

                    preTreatmentAssessment.IsFiO2 = model.IsFiO2;

                    preTreatmentAssessment.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    preTreatmentAssessment.IsLabored = model.IsLabored;

                    preTreatmentAssessment.IsLethargic = model.IsLethargic;

                    preTreatmentAssessment.IsMask = model.IsMask;
                    preTreatmentAssessment.IsNC = model.IsNC;
                    preTreatmentAssessment.IsNumbness = model.IsNumbness;
                    preTreatmentAssessment.IsRoomAir = model.IsRoomAir;
                    preTreatmentAssessment.IsVent = model.IsVent;
                    preTreatmentAssessment.IsWeakness = model.IsWeakness;
                    preTreatmentAssessment.LocationAutoTextId = model.LocationAutoTextId;
                    preTreatmentAssessment.LungSoundsAutoTextId = model.LungSoundsAutoTextId;
                    preTreatmentAssessment.NumbnessAutoTextId = model.NumbnessAutoTextId;
                    preTreatmentAssessment.OrientedX = model.OrientedX;
                    preTreatmentAssessment.OSat = model.OSat;
                    preTreatmentAssessment.PainAutoTextId = model.PainAutoTextId;
                    preTreatmentAssessment.RythmAutoTextId = model.RythmAutoTextId;
                    preTreatmentAssessment.SkinAutoTextId = model.SkinAutoTextId;
                    preTreatmentAssessment.WeaknessAutoTextId = model.WeaknessAutoTextId;
                    preTreatmentAssessment.MarkComplete = model.MarkComplete;
                    preTreatmentAssessment.CreatedOn = DateTime.UtcNow;
                    
                    preTreatmentAssessment.IsDeleted = false;

                    _treatmentRecordServices.InsertPreTreatmentAssessment(preTreatmentAssessment);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)preTreatmentAssessment.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = preTreatmentAssessment.Id;
                    model.TreatmentRecordMasterId = preTreatmentAssessment.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
                else
                {
                    var preTreatmentAssessment = _treatmentRecordServices.GetPreTreatmentAssessmentById(model.Id);
                    preTreatmentAssessment.Id = model.Id;
                    preTreatmentAssessment.BleendAutoTextId = model.BleendAutoTextId;

                    preTreatmentAssessment.EdemaAutoTextId = model.EdemaAutoTextId;

                    preTreatmentAssessment.IsAlert = model.IsAlert;


                    preTreatmentAssessment.IsBleeding = model.IsBleeding;
                    preTreatmentAssessment.IsComatose = model.IsComatose;
                    preTreatmentAssessment.IsEasy = model.IsEasy;
                    preTreatmentAssessment.IsEdema = model.IsEdema;

                    preTreatmentAssessment.IsFiO2 = model.IsFiO2;

                    preTreatmentAssessment.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    preTreatmentAssessment.IsLabored = model.IsLabored;

                    preTreatmentAssessment.IsLethargic = model.IsLethargic;

                    preTreatmentAssessment.IsMask = model.IsMask;
                    preTreatmentAssessment.IsNC = model.IsNC;
                    preTreatmentAssessment.IsNumbness = model.IsNumbness;
                    preTreatmentAssessment.IsRoomAir = model.IsRoomAir;
                    preTreatmentAssessment.IsVent = model.IsVent;
                    preTreatmentAssessment.IsWeakness = model.IsWeakness;
                    preTreatmentAssessment.LocationAutoTextId = model.LocationAutoTextId;
                    preTreatmentAssessment.LungSoundsAutoTextId = model.LungSoundsAutoTextId;
                    preTreatmentAssessment.NumbnessAutoTextId = model.NumbnessAutoTextId;
                    preTreatmentAssessment.OrientedX = model.OrientedX;
                    preTreatmentAssessment.OSat = model.OSat;
                    preTreatmentAssessment.PainAutoTextId = model.PainAutoTextId;
                    preTreatmentAssessment.RythmAutoTextId = model.RythmAutoTextId;
                    preTreatmentAssessment.SkinAutoTextId = model.SkinAutoTextId;
                    preTreatmentAssessment.WeaknessAutoTextId = model.WeaknessAutoTextId;
                    preTreatmentAssessment.MarkComplete = model.MarkComplete;
            
                    preTreatmentAssessment.LastUpdated = DateTime.UtcNow;
                  

                    _treatmentRecordServices.UpdatePreTreatmentAssessment(preTreatmentAssessment);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)preTreatmentAssessment.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = preTreatmentAssessment.Id;
                    model.TreatmentRecordMasterId = preTreatmentAssessment.TreatmentRecordMasterId;
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


        // GET: PreTreatmentAssessment/GetById/5
        [HttpGet("GetById")]
        public ActionResult GetById(int Id)
        {
            ResultModel resultModel = new ResultModel();
            try
            {

                var preTreatmentAssessment = new PreTreatmentAssessmentModel();
                var preTreatment = _treatmentRecordServices.GetPreTreatmentAssessmentById(Id);
                preTreatmentAssessment.Id = preTreatment.Id;
                preTreatmentAssessment.BleendAutoTextId = preTreatment.BleendAutoTextId;

                preTreatmentAssessment.EdemaAutoTextId = preTreatment.EdemaAutoTextId;

                preTreatmentAssessment.IsAlert = preTreatment.IsAlert;


                preTreatmentAssessment.IsBleeding = preTreatment.IsBleeding;
                preTreatmentAssessment.IsComatose = preTreatment.IsComatose;
                preTreatmentAssessment.IsEasy = preTreatment.IsEasy;
                preTreatmentAssessment.IsEdema = preTreatment.IsEdema;

                preTreatmentAssessment.IsFiO2 = preTreatment.IsFiO2;

                preTreatmentAssessment.TreatmentRecordMasterId = preTreatment.TreatmentRecordMasterId;
                preTreatmentAssessment.IsLabored = preTreatment.IsLabored;

                preTreatmentAssessment.IsLethargic = preTreatment.IsLethargic;

                preTreatmentAssessment.IsMask = preTreatment.IsMask;
                preTreatmentAssessment.IsNC = preTreatment.IsNC;
                preTreatmentAssessment.IsNumbness = preTreatment.IsNumbness;
                preTreatmentAssessment.IsRoomAir = preTreatment.IsRoomAir;
                preTreatmentAssessment.IsVent = preTreatment.IsVent;
                preTreatmentAssessment.IsWeakness = preTreatment.IsWeakness;
                preTreatmentAssessment.LocationAutoTextId = preTreatment.LocationAutoTextId;
                preTreatmentAssessment.LungSoundsAutoTextId = preTreatment.LungSoundsAutoTextId;
                preTreatmentAssessment.NumbnessAutoTextId = preTreatment.NumbnessAutoTextId;
                preTreatmentAssessment.OrientedX = preTreatment.OrientedX;
                preTreatmentAssessment.OSat = preTreatment.OSat;
                preTreatmentAssessment.PainAutoTextId = preTreatment.PainAutoTextId;
                preTreatmentAssessment.RythmAutoTextId = preTreatment.RythmAutoTextId;
                preTreatmentAssessment.SkinAutoTextId = preTreatment.SkinAutoTextId;
                preTreatmentAssessment.WeaknessAutoTextId = preTreatment.WeaknessAutoTextId;
                preTreatmentAssessment.IsDeleted = preTreatment.IsDeleted;
                preTreatmentAssessment.CreatedOn = preTreatment.CreatedOn;
                preTreatmentAssessment.LastUpdated = preTreatment.LastUpdated;
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = preTreatmentAssessment;
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