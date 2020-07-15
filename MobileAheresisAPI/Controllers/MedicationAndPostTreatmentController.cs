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
    public class MedicationAndPostTreatmentController : ControllerBase
    {
        #region Fields
        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportService;
        #endregion
        #region CTOR
        public MedicationAndPostTreatmentController(ITreatmentRecordServices TreatmentRecordServices,
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
        public IActionResult Create(PostTreatmentModel model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                if (model.Id == 0)
                {
                    var postTreatment = new PostTreatment();
                    postTreatment.IsBiohazardWasteDisposed = model.IsBiohazardWasteDisposed;
                    postTreatment.IsEquipmentCleanedAndDisinfected = model.IsEquipmentCleanedAndDisinfected;
                    postTreatment.IsPostCVCCarePerPolicy = model.IsPostCVCCarePerPolicy;
                    postTreatment.IsRinseBackComplete = model.IsRinseBackComplete;
                    postTreatment.IsSideRailsUp = model.IsSideRailsUp;
                    postTreatment.TreatmentRecordId = model.TreatmentRecordId;
                    //Mark Complete
                    postTreatment.MarkComplete = model.MarkComplete;
                    _treatmentRecordServices.InsertPostTreatment(postTreatment);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)postTreatment.TreatmentRecordId);
                   

                    foreach (var medicationData in model.MedicationList)
                    {
                        var medication = new Medication();
                        medication.PostTreatmentId = postTreatment.Id;
                        medication.Dosage = medicationData.Dosage;
                        medication.Comments = medicationData.Comments;
                        medication.Route = medicationData.Route;
                        medication.Name = medicationData.Name;
                        postTreatment.Medications.Add(medication);
                        _treatmentRecordServices.UpdatePostTreatment(postTreatment);

                    }
                    //12/10/19 aakansha
                    //model response
                    model.Id = postTreatment.Id;
                    model.TreatmentRecordId = postTreatment.TreatmentRecordId;
                    var postTreatment1 = _treatmentRecordServices.GetPostTreatmentById(postTreatment.Id);
                    foreach (var Medication in postTreatment.Medications)
                    {
                        var MEdication = new MedicationModel();

                        MEdication.Id = Medication.Id;
                        MEdication.Name = Medication.Name;
                        MEdication.PostTreatmentId = Medication.PostTreatmentId;
                        MEdication.Route = Medication.Route;
                        model.MedicationList.Clear();
                        model.MedicationList.Add(MEdication);




                    }

                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);

                }
                else
                {

                    var postTreatment = _treatmentRecordServices.GetPostTreatmentById(model.Id);
                    postTreatment.IsBiohazardWasteDisposed = model.IsBiohazardWasteDisposed;
                    postTreatment.IsEquipmentCleanedAndDisinfected = model.IsEquipmentCleanedAndDisinfected;
                    postTreatment.IsPostCVCCarePerPolicy = model.IsPostCVCCarePerPolicy;
                    postTreatment.IsRinseBackComplete = model.IsRinseBackComplete;
                    postTreatment.IsSideRailsUp = model.IsSideRailsUp;
                    postTreatment.TreatmentRecordId = model.TreatmentRecordId;
                    postTreatment.Id = model.Id;
                    postTreatment.MarkComplete = model.MarkComplete;
                    _treatmentRecordServices.UpdatePostTreatment(postTreatment);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)postTreatment.TreatmentRecordId);
                    foreach (var medicationList in model.MedicationList)
                    {
                        if (medicationList.Id == 0)
                        {
                            var medication = new Medication();
                            medication.PostTreatmentId = postTreatment.Id;
                            medication.Dosage = medicationList.Dosage;
                            medication.Comments = medicationList.Comments;
                            medication.Route = medicationList.Route;
                            medication.Name = medicationList.Name;
                            postTreatment.Medications.Add(medication);
                            _treatmentRecordServices.UpdatePostTreatment(postTreatment);
                        }
                        else
                        {
                            var medication = _treatmentRecordServices.GetMedicationById(medicationList.Id);
                            medication.PostTreatmentId = postTreatment.Id;
                            medication.Dosage = medicationList.Dosage;
                            medication.Comments = medicationList.Comments;
                            medication.Route = medicationList.Route;
                            medication.Name = medicationList.Name;
                          
                            _treatmentRecordServices.UpdateMedication(medication);
                        }


                    }
                    //12/10/19 aakansha
                    //model response
                    model.Id = postTreatment.Id;
                    model.TreatmentRecordId = postTreatment.TreatmentRecordId;
                    var postTreatment1 = _treatmentRecordServices.GetPostTreatmentById(postTreatment.Id);
                    foreach(var Medication in postTreatment.Medications)
                    {
                        var MEdication = new MedicationModel();

                        MEdication.Id = Medication.Id;
                        MEdication.Name = Medication.Name;
                        MEdication.PostTreatmentId = Medication.PostTreatmentId;
                        MEdication.Route = Medication.Route;
                        model.MedicationList.Clear();
                        model.MedicationList.Add(MEdication);




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
        public IActionResult GetById(int Id)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                var postTreatment = _treatmentRecordServices.GetPostTreatmentById(Id);
                var model = new PostTreatmentModel();
                model.Id = postTreatment.Id;
                model.IsBiohazardWasteDisposed = postTreatment.IsBiohazardWasteDisposed;
                model.IsEquipmentCleanedAndDisinfected = postTreatment.IsEquipmentCleanedAndDisinfected;
                model.IsPostCVCCarePerPolicy = postTreatment.IsPostCVCCarePerPolicy;
                model.IsRinseBackComplete = postTreatment.IsRinseBackComplete;
                model.IsSideRailsUp = postTreatment.IsSideRailsUp;
                model.TreatmentRecordId = postTreatment.TreatmentRecordId;
                var data = postTreatment.Medications.Select(a =>
               new MedicationModel
               {
                  PostTreatmentId =a.PostTreatmentId,
                   Comments = a.Comments,
                   Dosage = a.Dosage,
                   Id = a.Id,
                   Name = a.Name,
                   Route =a.Route

               });
                model.MedicationList = data.ToList();
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


        //public IActionResult MedicationEdit(MedicationModel model)
        //{
        //    ResultModel resultModel = new ResultModel();
        //    try
        //    {
        //        var medicationData = new Medication();
        //        if (model.Id == 0)
        //        {
        //            medicationData.Comments = model.Comments;
        //            medicationData.Dosage = model.Dosage;
        //            medicationData.Name = model.Name;
        //            medicationData.PostTreatmentId = model.PostTreatmentId;
        //            medicationData.Route = model.Route;
        //            _treatmentRecordServices.InsertMedication(medicationData);
        //            resultModel.Message = ValidationMessages.Success;
        //            resultModel.Status = 1;
        //            resultModel.Response = medicationData;
        //            return Ok(resultModel);
        //        }
        //        else
        //        {
        //            medicationData = _treatmentRecordServices.GetMedicationById(model.Id);
        //            medicationData.Comments = model.Comments;
        //            medicationData.Dosage = model.Dosage;
        //            medicationData.Name = model.Name;
        //            medicationData.PostTreatmentId = model.PostTreatmentId;
        //            medicationData.Route = model.Route;
        //            _treatmentRecordServices.UpdateMedication(medicationData);
        //            resultModel.Message = ValidationMessages.Success;
        //            resultModel.Status = 1;
        //            resultModel.Response = medicationData;
        //            return Ok(resultModel);
        //        }

        //    }
        //    catch(Exception e) { }
        //    return Ok();
        //}


    }
}