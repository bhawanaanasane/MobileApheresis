using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.Appointment;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Services.Appointment;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.CompanyProfiles;
using CRM.Services.Hospitals;
using CRM.Services.Nurses;
using CRM.Services.Security;
using CRM.Services.Treatements;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.CompanyProfile;
using MobileAheresisAPI.Models.Hospital;
using MobileAheresisAPI.Models.Nurse;

using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Models.Treatment;
using MobileAheresisAPI.Models.TreatmentRecords;

namespace MobileAheresisAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController : ControllerBase
    {
        #region Fields
        private readonly ICompanyProfileService _companyProfileService;
        private readonly IHospitalServices _hospitalServices;
        private readonly INurseServices _nurseServices;
        private readonly ITreatmentServices _treatmentServices;
        private readonly ITreatmentRecordServices _treatmentRecordsServices;
        private readonly IAppointmentServices _appointmentServices;
        private readonly IReportService _reportService;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region CTOR

        public PatientController(ICompanyProfileService CompanyProfileService,
            IHospitalServices HospitalServices,
            INurseServices NurseServices,
            ITreatmentServices TreatmentServices,
            ITreatmentRecordServices TreatmentRecordsServices,
            IAppointmentServices AppointmentServices,
            IReportService ReportService,
            IEncryptionService encryptionService)
        {
            this._companyProfileService = CompanyProfileService;
            this._hospitalServices = HospitalServices;
            this._nurseServices = NurseServices;
            this._treatmentServices = TreatmentServices;
            this._treatmentRecordsServices = TreatmentRecordsServices;
            this._appointmentServices = AppointmentServices;
            this._reportService = ReportService;
            this._encryptionService = encryptionService;

        }
        #endregion

        #region Utilities
        public IList<PatientInfoModel> PateintInfoData(int patientMasterId)
        {
            var patientInfoData = new List<PatientInfoModel>();
            var PatientData = _treatmentRecordsServices.GetPatientMasterById(patientMasterId);
            foreach (var data in PatientData.PatientInfo)
            {

                var patientInfo = new PatientInfoModel();
                patientInfo.Date = data.Date;
                patientInfo.Deleted = data.Deleted;
                patientInfo.DiagnosisId = data.DiagnosisId;
                patientInfo.HospitalMasterId = data.HospitalMasterId;
                patientInfo.PatientInfoId = data.Id;
                patientInfo.LastUpdated = data.LastUpdated;

                patientInfo.NurseMasterId = data.NurseMasterId;
                patientInfo.ProcedureId = data.ProcedureId;
                patientInfo.TreatmentRecordMasterId = data.TreatmentRecordMasterId;
                patientInfoData.Add(patientInfo);

            }


            return patientInfoData.ToList();

        }
        #endregion

        // GET: GetMaster for patient info drop down lists

        [HttpGet("GetMaster")]
        //[Route("GetMaster")]
        public ActionResult GetMaster()
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                var model = new PatientInfoDropDownMasterModel();

            var NurseData = _nurseServices.GetAllNurse();
            var HospitalData = _hospitalServices.GetAllHospital();
            var ProcedureData = _companyProfileService.GetAllPolicyAndProcedure().Where(a => a.IsPolicy == false);
            var DiagnosisData = _treatmentServices.GetAllDiagnosis();
            var PateintData = _treatmentRecordsServices.GetAllPatientMaster();
            var patientList = PateintData.Select(a =>
            new PatientModel
            {
                PatientMasterId = a.Id,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                LastUpdated = a.LastUpdated,
                PatientName = _encryptionService.DecryptText(a.PatientName),
                //MR = a.MR,
                PatientInfoList = PateintInfoData(a.Id)

            });
            var nurseData = NurseData.Select(a =>
            new NurseModel
            {
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                Email = _encryptionService.DecryptText(a.Email),
                FullName = _encryptionService.DecryptText(a.FirstName) + "" + _encryptionService.DecryptText(a.LastName),
                Id = a.Id,
                LastUpdated = a.LastUpdated
            });

            var hospitalData = HospitalData.Select(a =>
           new HospitalModel
           {
               CreatedOn = a.CreatedOn,
               Deleted = a.Deleted,
               ContactPerson = a.ContactPerson,
               HospitalName = _encryptionService.DecryptText(a.HospitalName),
               Id = a.Id,
               LastUpdated = a.LastUpdated
           });
            var procedureData = ProcedureData.Select(a =>
           new PoliciesAndProceduresModel
           {
               CompanyProfileId = a.CompanyProfileId,
               IsPolicy = a.IsPolicy,
               Text = a.Text,
               Id = a.Id
           });
            var diagnosisData = DiagnosisData.Select(a =>
           new DiagnosisModel
           {
               CreatedOn = a.CreatedOn,
               Deleted = a.Deleted,
               Description = a.Description,
               DiagnosisName = a.DiagnosisName,
               IsActive = a.IsActive,
               Id = a.Id,
               LastUpdated = a.LastUpdated
           });
            model.NurseList = nurseData.ToList();
            model.hospitalList = hospitalData.ToList();
            model.ProceduresList = procedureData.ToList();
            model.DiagnosisList = diagnosisData.ToList();
            model.PatientList = patientList.ToList();

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
                return Ok(e);
            }
        }

     

        

        // POST: Patient/Create
        [HttpPost("Create")]

        public ActionResult Create(PatientInfoModel model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                if (model.PatientInfoId == 0)
                {
                    //Creating New Treatment record 
                    var TreatmentRecord = new TreatmentRecordMaster();

                    TreatmentRecord.AppointmentDateId = model.AppointmentDateId;
                    TreatmentRecord.TreatmentStatusId = (int)TreatmentStatus.Started;
                    TreatmentRecord.CreatedOn = DateTime.UtcNow;
                    TreatmentRecord.Deleted = false;
                    _treatmentRecordsServices.InsertTreatmentRecords(TreatmentRecord);
                    TreatmentRecord.TreatmentRecordNo = _treatmentRecordsServices.GetTreatmentRecordNo();
                    _treatmentRecordsServices.UpdateTreatmentRecords(TreatmentRecord);
                    //Bhawana(07/10/2019)
                    //Change appointment status from Created to Treatment Started
                    var appointmentdata = _appointmentServices.GetAppointmentDateById((int)model.AppointmentDateId);
                    appointmentdata.AppointmentStatusId = (int)AppointmentStatus.TreatmentStarted;
                    _appointmentServices.UpdateAppointmentDate(appointmentdata);

                    //Inser Patient Data if patient is new
                    var PatientMaster = new PatientMaster();
                    if (model.PatientMasterId == 0)
                    {
                        PatientMaster.PatientName = _encryptionService.EncryptText(model.PatientName);
                        PatientMaster.Deleted = false;
                        PatientMaster.CreatedOn = DateTime.UtcNow;
                        _treatmentRecordsServices.InsertPatientMaster(PatientMaster);
                    }
                    else
                    {
                        PatientMaster.Id = (int)model.PatientMasterId;
                        PatientMaster.PatientName = _encryptionService.EncryptText(model.PatientName);
                        PatientMaster.Deleted = false;
                        PatientMaster.LastUpdated = DateTime.UtcNow;
                        _treatmentRecordsServices.UpdatePatientMaster(PatientMaster);
                    }
                    //Inser PatientInfo Data in Database
                    var PatientInfo = new PatientInfo();
                    PatientInfo.Date = model.Date;
                    PatientInfo.MR = _encryptionService.EncryptText(model.MR);
                    PatientInfo.Deleted = false;
                    PatientInfo.CreatedOn = DateTime.UtcNow;
                    PatientInfo.LastUpdated = DateTime.UtcNow;
                    PatientInfo.PatientMasterId = PatientMaster.Id;
                    PatientInfo.NurseMasterId = (model.NurseMasterId!=0)? model.NurseMasterId:null ;
                    PatientInfo.HospitalMasterId = (model.HospitalMasterId != 0) ? model.HospitalMasterId:null ;
                    PatientInfo.DiagnosisId = model.DiagnosisId;
                    PatientInfo.ProcedureId = model.ProcedureId;
                    PatientInfo.MarkComplete = model.MarkComplete;
                    PatientInfo.TreatmentRecordMasterId = TreatmentRecord.Id;
                    _treatmentRecordsServices.InsertPatientInfo(PatientInfo);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)PatientInfo.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.PatientInfoId = PatientInfo.Id;
                    model.PatientMasterId = PatientInfo.PatientMasterId;
                    model.TreatmentRecordMasterId = PatientInfo.TreatmentRecordMasterId;
                    model.TreatmentRecordNo = TreatmentRecord.TreatmentRecordNo;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
                else
                {
                    var patientInfoData = _treatmentRecordsServices.GetPatientInfoById(model.PatientInfoId);
                    if (patientInfoData != null)
                    {
                        patientInfoData.Date = model.Date;
                        patientInfoData.LastUpdated = DateTime.UtcNow;
                        patientInfoData.MR = _encryptionService.EncryptText(model.MR);
                        patientInfoData.NurseMasterId = model.NurseMasterId;
                        patientInfoData.HospitalMasterId = model.HospitalMasterId;
                        patientInfoData.DiagnosisId = model.DiagnosisId;
                        patientInfoData.ProcedureId = model.ProcedureId;
                        patientInfoData.MarkComplete = model.MarkComplete;
                        _treatmentRecordsServices.UpdatePatientInfo(patientInfoData);
                        //Bhawana(09/10/2019)
                        //Change treatment Record Status
                        _reportService.UpdateTreatmentStatusID((int)patientInfoData.TreatmentRecordMasterId);

                    }
                    //12/10/19 aakansha
                    //model response
                    model.PatientInfoId = patientInfoData.Id;
                    model.PatientMasterId = patientInfoData.PatientMasterId;
                    model.TreatmentRecordMasterId = patientInfoData.TreatmentRecordMasterId;
                    var treatmentdata = _treatmentRecordsServices.GetTreatmentRecordsById((int)patientInfoData.TreatmentRecordMasterId);
                    model.TreatmentRecordNo = treatmentdata.TreatmentRecordNo;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
            }
            catch (Exception ex)
            {
                resultModel.Message = ex.ToString();
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }

        }

        // GET: Patient/GetById/5
        [HttpGet("GetById")]
        public ActionResult GetById(int TreatmentRecordId)
        {
            ResultModel resultModel = new ResultModel();
            try
            {

                var patientInfoData = _treatmentRecordsServices.GetPatientInfoByTreatmentRecordId(TreatmentRecordId);
                var patientData = _treatmentRecordsServices.GetPatientMasterById((int)patientInfoData.PatientMasterId);
                var model = new PatientModel();
                model.PatientMasterId = patientData.Id;
                model.LastUpdated = patientData.LastUpdated;
                model.PatientName = _encryptionService.DecryptText(model.PatientName);
                model.CreatedOn = patientData.CreatedOn;
                model.Deleted = patientData.Deleted;
                var patientInfo = new PatientInfoModel();
                patientInfo.Date = patientInfoData.Date;
                patientInfo.Deleted = patientInfoData.Deleted;
                patientInfo.DiagnosisId = patientInfoData.DiagnosisId;
                patientInfo.HospitalMasterId =(int) patientInfoData.HospitalMasterId;
                patientInfo.PatientInfoId = patientInfoData.Id;
                patientInfo.LastUpdated = patientInfoData.LastUpdated;

                patientInfo.NurseMasterId = patientInfoData.NurseMasterId;
                patientInfo.ProcedureId = patientInfoData.ProcedureId;
                patientInfo.TreatmentRecordMasterId = patientInfoData.TreatmentRecordMasterId;
                model.PatientInfoData = patientInfo;
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
                return Ok(e);
            }
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return Ok();
            }
            catch
            {
                return Ok();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: Patient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return Ok();
            }
            catch
            {
                return Ok();
            }
        }
    }
}