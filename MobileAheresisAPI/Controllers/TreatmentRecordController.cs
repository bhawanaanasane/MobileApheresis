using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Core.ViewModels.TreatmentRecord;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Security;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Models.TreatmentRecords;

namespace MobileAheresisAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentRecordController : ControllerBase
    {
        #region Fields
        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportServices;
        private readonly IEncryptionService _encryptionService;
        #endregion

        #region CTOR
        public TreatmentRecordController(ITreatmentRecordServices TreatmentRecordServices,
            IReportService ReportServices, IEncryptionService encryptionService)
        {
            this._treatmentRecordServices = TreatmentRecordServices;
            this._reportServices = ReportServices;
            this._encryptionService = encryptionService;
        }
        #endregion

        #region Utilities
        public PatientModel PateintData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetPatientInfoByTreatmentRecordId(treatmentRecordid);
            var pateintData = new PatientModel();
            if (data != null)
            {
                //var patientMaster = _treatmentRecordServices.GetPatientMasterById((int)data.PatientMasterId);
                // var pateintInfoData = new PatientInfoModel
                // {
                //     Date = data.Date,

                //     Deleted = data.Deleted,
                //     DiagnosisId = data.DiagnosisId,
                //     HospitalId = data.HospitalId,
                //     Id = data.Id,
                //     LastUpdated = data.LastUpdated,
                //     MR = data.MR,
                //     NurseId = data.NurseId,
                //     ProcedureId = data.ProcedureId,
                //     TreatmentRecordMasterId = data.TreatmentRecordMasterId
                // };

                //pateintData.CreatedOn = patientMaster.CreatedOn;
                //    pateintData.PatientName = patientMaster.PatientName;
                //    pateintData.Deleted = patientMaster.Deleted;

                //    pateintData.Id = patientMaster.Id;
                //    pateintData.LastUpdated = patientMaster.LastUpdated;
                //    pateintData.PatientInfoData = pateintInfoData;

            }


            return pateintData;

        }

        public DoctorInfoModel DoctoreData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetDoctorInfoByTreatmentRecordId(treatmentRecordid);
            var DoctorsData = new DoctorInfoModel();
            if (data != null)
            {

                DoctorsData.TreatmentRecordMasterId = (int)data.TreatmentRecordMasterId;
                DoctorsData.Comments = data.Comments;
                DoctorsData.DoctorName = data.DoctorName;
                DoctorsData.OrdersReviewed = (bool)data.OrdersReviewed;
                DoctorsData.OutPatient = data.OutPatient;
                DoctorsData.Room = data.Room;

                DoctorsData.Id = data.Id;
                DoctorsData.EducatioPreTreatmentId = data.EducatioPreTreatmentId;
            }


            return DoctorsData;

        }

        public MachineModel MachineData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetMachineInfoByTreatmentRecordId(treatmentRecordid);
            var MachineData = new MachineModel();
            if (data != null)
            {

                MachineData.TreatmentRecordMasterId = (int)data.TreatmentRecordMasterId;
                MachineData.AlarmCheck = data.AlarmCheck;
                MachineData.CleanedFrontDoorSensors = data.CleanedFrontDoorSensors;
                MachineData.CleanedPressurePODSSeals = data.CleanedPressurePODSSeals;
                MachineData.CleanedSensors = data.CleanedSensors;
                MachineData.CleanedTrackDoors = data.CleanedTrackDoors;
                MachineData.CreatedOn = data.CreatedOn;
                MachineData.Deleted = data.Deleted;
                MachineData.EquipmentId = data.EquipmentId;
                MachineData.EquipSerial = data.EquipSerial;
                MachineData.ExpDate = data.ExpDate;
                MachineData.KitTypeId = (int)data.KitTypeId;
                MachineData.KitTypeMaster = (KitTypeMaster)data.KitTypeId;
                MachineData.KitTypeSerial = data.KitTypeSerial;
                MachineData.LastUpdated = data.LastUpdated;
                MachineData.MachineClean = data.MachineClean;
                MachineData.PMDate = data.PMDate;
                MachineData.PrimeSuccess = data.PrimeSuccess;
                MachineData.SafetyChkDate = data.SafetyChkDate;
                MachineData.Id = data.Id;
                MachineData.CorrectiveAction = data.CorrectiveAction;
            }


            return MachineData;

        }


        public PreTreatmentCheckModel PreTreatmentCheckData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetPreTreatmentCheckByTreatmentRecordId(treatmentRecordid);
            var preTreatmentCheckData = new PreTreatmentCheckModel();
            if (data != null)
            {

                preTreatmentCheckData.TreatmentRecordMasterId = (int)data.TreatmentRecordMasterId;
                preTreatmentCheckData.AlarmTest = data.AlarmTest;
                preTreatmentCheckData.BloodConsent = data.BloodConsent;
                preTreatmentCheckData.InformedConsent = data.InformedConsent;

                preTreatmentCheckData.MachinePrimeId = data.MachinePrimeId;

                preTreatmentCheckData.Id = data.Id;
                preTreatmentCheckData.UniversalPrecautions = data.UniversalPrecautions;
            }


            return preTreatmentCheckData;

        }

        public LabValuesModel LabValuesData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetLabValuesByTreatmentId(treatmentRecordid);
            var LabValuesData = new LabValuesModel();
            if (data != null)
            {

                LabValuesData.TreatmentRecordMasterId = (int)data.TreatmentRecordMasterId;
                LabValuesData.CreatedOn = data.CreatedOn;
                LabValuesData.Deleted = data.Deleted;
                LabValuesData.EBV = (decimal)data.EBV;
                LabValuesData.ECV10 = (decimal)data.ECV10;
                LabValuesData.ECV15 = (decimal)data.ECV15;
                LabValuesData.EPV = (decimal)data.EPV;
                LabValuesData.Height = (decimal)data.Height;
                LabValuesData.HGB = (decimal)data.HGB;
                LabValuesData.HTC = (decimal)data.HTC;
                LabValuesData.LastUpdated = data.LastUpdated;
                LabValuesData.PLT = (decimal)data.PLT;
                LabValuesData.WBC = (decimal)data.WBC;
                LabValuesData.Id = data.Id;
                LabValuesData.Weight = (decimal)data.Weight;
                if (data.OtherLabValues.Count() != 0)
                {
                    var otherData = data.OtherLabValues.Select(a =>
                    new OtherLabValues
                    {
                        ContentName = a.ContentName,
                        ContentValue = a.ContentValue,
                        Id = a.Id,
                        LabValues = a.LabValues,
                        LabValuesId = a.LabValuesId
                    });
                }




            }
            return LabValuesData;
        }

        public SuppliesAndAccessModel SuppliesAndAccessData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetSuppliesByTreatmentRecordId(treatmentRecordid);
            var suppliesAndAccessData = new SuppliesAndAccessModel();
            if (data != null)
            {

                suppliesAndAccessData.TreatmentRecordId = (int)data.TreatmentRecordId;
                suppliesAndAccessData.ACDLot = data.ACDLot;
                suppliesAndAccessData.ACDLotExpDate = data.ACDLotExpDate;
                suppliesAndAccessData.ACEInhibitors = data.ACEInhibitors;
                suppliesAndAccessData.BloodWarmer = data.BloodWarmer;
                suppliesAndAccessData.Comments = data.Comments;
                suppliesAndAccessData.CreatedOn = data.CreatedOn;
                suppliesAndAccessData.CVC = data.CVC;
                suppliesAndAccessData.DateDC = data.DateDC;
                suppliesAndAccessData.Deleted = data.Deleted;
                suppliesAndAccessData.LastDoseDate = data.LastDoseDate;
                suppliesAndAccessData.LastUpdated = data.LastUpdated;
                suppliesAndAccessData.Locations = data.Locations;
                suppliesAndAccessData.MedsReviewed = data.MedsReviewed;
                suppliesAndAccessData.NSPrimeLot = data.NSPrimeLot;
                suppliesAndAccessData.NSPrimeLotExpDate = data.NSPrimeLotExpDate;
                suppliesAndAccessData.Peripheral = data.Peripheral;
                suppliesAndAccessData.Rate = data.Rate;
                suppliesAndAccessData.Serial = data.Serial;
                suppliesAndAccessData.TEMP = data.TEMP;
                suppliesAndAccessData.Vortex = data.Vortex;
                suppliesAndAccessData.Id = data.Id;

            }


            return suppliesAndAccessData;

        }

        public PreTreatmentAssessmentModel PreTreatmentAssessmentData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetPreTreatmentAssessmentByTreatmentRercordId(treatmentRecordid);
            var pretreatmentAssessmentData = new PreTreatmentAssessmentModel();
            if (data != null)
            {

                pretreatmentAssessmentData.TreatmentRecordMasterId = (int)data.TreatmentRecordMasterId;
                pretreatmentAssessmentData.BleendAutoTextId = data.BleendAutoTextId;
                pretreatmentAssessmentData.CreatedOn = data.CreatedOn;
                pretreatmentAssessmentData.EdemaAutoTextId = data.EdemaAutoTextId;
                pretreatmentAssessmentData.IsAlert = data.IsAlert;
                pretreatmentAssessmentData.IsBleeding = data.IsBleeding;
                pretreatmentAssessmentData.IsComatose = data.IsComatose;
                pretreatmentAssessmentData.IsDeleted = data.IsDeleted;
                pretreatmentAssessmentData.IsEasy = data.IsEasy;
                pretreatmentAssessmentData.IsEdema = data.IsEdema;
                pretreatmentAssessmentData.IsFiO2 = data.IsFiO2;
                pretreatmentAssessmentData.LastUpdated = data.LastUpdated;
                pretreatmentAssessmentData.IsLabored = data.IsLabored;
                pretreatmentAssessmentData.IsLethargic = data.IsLethargic;
                pretreatmentAssessmentData.IsMask = data.IsMask;
                pretreatmentAssessmentData.IsNC = data.IsNC;
                pretreatmentAssessmentData.IsNumbness = data.IsNumbness;
                pretreatmentAssessmentData.IsRoomAir = data.IsRoomAir;
                pretreatmentAssessmentData.IsVent = data.IsVent;
                pretreatmentAssessmentData.IsWeakness = data.IsWeakness;
                pretreatmentAssessmentData.LocationAutoTextId = data.LocationAutoTextId;
                pretreatmentAssessmentData.LungSoundsAutoTextId = data.LungSoundsAutoTextId;
                pretreatmentAssessmentData.NumbnessAutoTextId = data.NumbnessAutoTextId;
                pretreatmentAssessmentData.OrientedX = data.OrientedX;
                pretreatmentAssessmentData.OSat = data.OSat;
                pretreatmentAssessmentData.PainAutoTextId = data.PainAutoTextId;
                pretreatmentAssessmentData.RythmAutoTextId = data.RythmAutoTextId;
                pretreatmentAssessmentData.SkinAutoTextId = data.SkinAutoTextId;
                pretreatmentAssessmentData.WeaknessAutoTextId = data.WeaknessAutoTextId;

                pretreatmentAssessmentData.Id = data.Id;

            }


            return pretreatmentAssessmentData;

        }


        public IList<RunValuesModel> RunValuesData(int treatmentRecordid)
        {
            var data = _reportServices.GetAllTreatmentRecordData(treatmentRecordid);

            var runvalueList = new List<RunValuesModel>();
            if (data != null)
            {
                var runvalues = data.RunValuesVM.Select(a =>
                new RunValuesModel
                {
                    ACFlowRate = a.ACFlowRate,
                    ACFlowVol = a.ACFlowVol,
                    BP = a.BP,
                    CollectFlowRate = a.CollectFlowRate,
                    CollectFlowVol = a.CollectFlowVol,
                    CreatedOn = a.CreatedOn,
                    Deleted = a.Deleted,
                    Id = a.Id,
                    IntelFlowRate = a.IntelFlowRate,
                    IntelFlowVol = a.IntelFlowVol,
                    LastUpdated = a.LastUpdated,
                    LotNo = a.LotNo,
                    P = a.P,
                    PlasmaFlowRate = a.PlasmaFlowRate,
                    PlasmaFlowVol = a.PlasmaFlowVol,
                    R = a.R,
                    ReplaceFluidId = a.ReplaceFluidId,
                    RunTime = a.RunTime,
                    T = a.T,
                    TreatmentRecordMasterId = a.TreatmentRecordMasterId,
                    WarmerTemp = a.WarmerTemp
                });
                runvalueList = runvalues.ToList();

            }

            return runvalueList;



        }

        public FinalValuesAndAccessPostAssessmentModel FinalValuesData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetFinalValuesByTreatmentRecordId(treatmentRecordid);
            var FinalValuesAndAccessData = new FinalValuesAndAccessPostAssessmentModel();
            if (data != null)
            {

                FinalValuesAndAccessData.TreatmentRecordId = (int)data.TreatmentRecordId;
                FinalValuesAndAccessData.AC = (int)data.AC;
                FinalValuesAndAccessData.BP = data.BP;
                FinalValuesAndAccessData.ChlorhexidineCapApplied = data.ChlorhexidineCapApplied;
                FinalValuesAndAccessData.Collet = (int)data.Collet;
                FinalValuesAndAccessData.Comments = data.Comments;
                FinalValuesAndAccessData.CreatedOn = data.CreatedOn;
                FinalValuesAndAccessData.Heparin = data.Heparin;
                FinalValuesAndAccessData.FluidBalance = data.FluidBalance;
                FinalValuesAndAccessData.Deleted = data.Deleted;
                FinalValuesAndAccessData.Inlet = (int)data.Inlet;
                FinalValuesAndAccessData.LastUpdated = data.LastUpdated;
                FinalValuesAndAccessData.Intact = data.Intact;
                FinalValuesAndAccessData.NewDressing = data.NewDressing;
                FinalValuesAndAccessData.P = (int)data.P;
                FinalValuesAndAccessData.Plasma = (int)data.Plasma;
                FinalValuesAndAccessData.R = (int)data.R;
                FinalValuesAndAccessData.Reinforced = data.Reinforced;
                FinalValuesAndAccessData.Saline = data.Saline;
                FinalValuesAndAccessData.T = (int)data.T;
                FinalValuesAndAccessData.Time = (int)data.Time;
                FinalValuesAndAccessData.Id = data.Id;

            }


            return FinalValuesAndAccessData;

        }

        public PostTreatmentModel PostTratmentData(int treatmentRecordid)
        {
            var data = _treatmentRecordServices.GetPostTreatmentByTreatmentRecordId(treatmentRecordid);
            var postTreatmentData = new PostTreatmentModel();
            if (data != null)
            {

                postTreatmentData.TreatmentRecordId = (int)data.TreatmentRecordId;
                postTreatmentData.IsBiohazardWasteDisposed = data.IsBiohazardWasteDisposed;
                postTreatmentData.IsEquipmentCleanedAndDisinfected = data.IsEquipmentCleanedAndDisinfected;
                postTreatmentData.IsPostCVCCarePerPolicy = data.IsPostCVCCarePerPolicy;
                postTreatmentData.IsRinseBackComplete = data.IsRinseBackComplete;
                postTreatmentData.IsSideRailsUp = data.IsSideRailsUp;
                postTreatmentData.MedicationList = data.Medications.Select(a =>
                new MedicationModel
                {
                    Comments = a.Comments,
                    Dosage = a.Dosage,
                    Id = a.Id,
                    Name = a.Name,
                    PostTreatmentId = a.PostTreatmentId,
                    Route = a.Route
                }).ToList();
                postTreatmentData.Id = data.Id;

            }


            return postTreatmentData;

        }

        #endregion

        public IActionResult Index()
        {
            return Ok();
        }

        //[HttpPost("GetAllTreatmentRecords")]
        //public IActionResult GetAllTreatmentRecords(GetTreatmentRecordListVM model)
        //{
        //    ResultModel resultModel = new ResultModel();
        //    var treatmentRecordData = _reportServices.GetAllTreatmentRecords(
        //        page_num: model.Page,
        //                page_size: model.PageSize == 0 ? 10 : model.PageSize,
        //                GetAll: true);

        //    var treatmentRecordList = treatmentRecordData.List.Select(a =>
        //    new TreatmentRecordMasterModel
        //    //19/09/19 aakansha
        //    {
        //        CreatedOn = a.CreatedOn,
        //        Deleted = a.Deleted,
        //        TreatmentStatusId = a.TreatmentStatusId,
        //        LastUpdated = a.LastUpdated,
        //        PateintName = a.PateintName,
        //        MR = a.MR,
        //        NurseName = a.NurseName,
        //        HospitalName = a.HospitalName,
        //        ContactPerson = a.ContactPerson,
        //        DoctorName = a.DoctorName,
        //        Room = a.Room,
        //        EquipSerial = a.EquipSerial,
        //        EquipmentName = a.EquipmentName,
        //        PMDate = a.PMDate,
        //        Id = a.TreatmentRecordId,
        //    });

        //    if (treatmentRecordList.Count() != 0)
        //    {
        //        resultModel.Message = ValidationMessages.Success;
        //        resultModel.Status = 1;
        //        resultModel.Response = treatmentRecordList;
        //        return Ok(resultModel);
        //    }
        //    else
        //    {
        //        resultModel.Message = ValidationMessages.Failure;
        //        resultModel.Status = 0;
        //        resultModel.Response = null;
        //        return Ok(resultModel);
        //    }
        //}


        [HttpGet("GetTreatmentRecordByAppointmenDatetId")]
        public IActionResult GetTreatmentRecordByAppointmenDatetId(int AppointmentDateId)
        {
            ResultModel resultModel = new ResultModel();
            var treatmentReocrd = _treatmentRecordServices.GetTreatmentRecordsByAppointmentDateId(AppointmentDateId);
            var treatmentRecodData = _reportServices.GetAllTreatmentRecordData(treatmentReocrd.Id);

            var treatmentRecordModel = new TreatmentRecordMasterModel();
            treatmentRecordModel.TreatmentRecordNo = treatmentReocrd.TreatmentRecordNo;
            treatmentRecordModel.Id = treatmentReocrd.Id;
            treatmentRecordModel.AppointmentDateId = treatmentReocrd.AppointmentDateId;
            //Patient Data 
           var patientdata = new PatientInfoModel();

            patientdata.DiagnosisId = treatmentRecodData.PatientVM.DiagnosisId;
            patientdata.HospitalMasterId = treatmentRecodData.PatientVM.HospitalMasterId;
            patientdata.MarkComplete = treatmentRecodData.PatientVM.MarkComplete;
            patientdata.MR = (treatmentRecodData.PatientVM.MR != null)?_encryptionService.DecryptText(treatmentRecodData.PatientVM.MR):null;
            patientdata.NurseMasterId = treatmentRecodData.PatientVM.NurseMasterId;
            patientdata.PatientInfoId = treatmentRecodData.PatientVM.Id;
            patientdata.ProcedureId = treatmentRecodData.PatientVM.ProcedureId;
            patientdata.PatientMasterId = treatmentRecodData.PatientVM.PatientMasterId;
            patientdata.TreatmentRecordMasterId = treatmentRecodData.PatientVM.TreatmentRecordMasterId;
            patientdata.PatientName = (treatmentRecodData.PatientVM.PatientName != null)?_encryptionService.DecryptText(treatmentRecodData.PatientVM.PatientName) : null;
            patientdata.ProcedureName = treatmentRecodData.PatientVM.ProcedureName;
            patientdata.DaignosisName = treatmentRecodData.PatientVM.DaignosisName;
            patientdata.HospitalName = (treatmentRecodData.PatientVM.HospitalName != null)?_encryptionService.DecryptText(treatmentRecodData.PatientVM.HospitalName) : null;
            //patientdata.NurseName = treatmentRecodData.PatientVM.NurseName;
            patientdata.NurseName = _encryptionService.DecryptText(treatmentRecodData.PatientVM.NurseFirstName) + " " + _encryptionService.DecryptText(treatmentRecodData.PatientVM.NurseLastName);
            patientdata.Date = treatmentRecodData.PatientVM.Date;
            patientdata.Deleted = treatmentRecodData.PatientVM.Deleted;
            patientdata.LastUpdated = treatmentRecodData.PatientVM.LastUpdated;
            treatmentRecordModel.PatientInfoData = patientdata;

            //Doctor Data
            treatmentRecordModel.DoctorData = new DoctorInfoModel
            {
                Comments = treatmentRecodData.DoctorsInfo.Comments,
                DoctorName = treatmentRecodData.DoctorsInfo.DoctorName,
                EducatioPreTreatmentId = treatmentRecodData.DoctorsInfo.EducatioPreTreatmentId,
                Id = treatmentRecodData.DoctorsInfo.Id,
                OrdersReviewed = treatmentRecodData.DoctorsInfo.OrdersReviewed,
                OutPatient = treatmentRecodData.DoctorsInfo.OutPatient,
                Room = treatmentRecodData.DoctorsInfo.Room,
                TreatmentRecordMasterId = treatmentRecodData.DoctorsInfo.TreatmentRecordMasterId,
                MarkComplete = treatmentRecodData.DoctorsInfo.MarkComplete
            };

            //Machine Data
            treatmentRecordModel.MachineData = new MachineModel
            {
                Id = treatmentRecodData.MachineMaster.Id,
                KitTypeSerial = treatmentRecodData.MachineMaster.KitTypeSerial,
                AlarmCheck = treatmentRecodData.MachineMaster.AlarmCheck,
                CleanedFrontDoorSensors = treatmentRecodData.MachineMaster.CleanedFrontDoorSensors,
                CleanedPressurePODSSeals = treatmentRecodData.MachineMaster.CleanedPressurePODSSeals,
                CleanedSensors = treatmentRecodData.MachineMaster.CleanedSensors,
                CleanedTrackDoors = treatmentRecodData.MachineMaster.CleanedTrackDoors,
                CorrectiveAction = treatmentRecodData.MachineMaster.CorrectiveAction,
                EquipmentId = treatmentRecodData.MachineMaster.EquipmentId,
                EquipSerial = treatmentRecodData.MachineMaster.EquipSerial,
                ExpDate = treatmentRecodData.MachineMaster.ExpDate,
                KitTypeId = (treatmentRecodData.MachineMaster.KitTypeId != null) ? treatmentRecodData.MachineMaster.KitTypeId : 0,
                MachineClean = treatmentRecodData.MachineMaster.MachineClean,
                PMDate = treatmentRecodData.MachineMaster.PMDate,
                PrimeSuccess = treatmentRecodData.MachineMaster.PrimeSuccess,
                SafetyChkDate = treatmentRecodData.MachineMaster.SafetyChkDate,
                TreatmentRecordMasterId = treatmentRecodData.MachineMaster.TreatmentRecordMasterId,
                MarkComplete = treatmentRecodData.MachineMaster.MarkComplete,
                EquipmentName = treatmentRecodData.MachineMaster.EquipmentName
            };
            //Pre treatment Check

            treatmentRecordModel.PreTreatmentCheckData = new PreTreatmentCheckModel
            {
                AlarmTest = treatmentRecodData.PreTreatmentCheck.AlarmTest,
                BloodConsent = treatmentRecodData.PreTreatmentCheck.BloodConsent,
                Id = treatmentRecodData.PreTreatmentCheck.Id,
                InformedConsent = treatmentRecodData.PreTreatmentCheck.InformedConsent,
                TreatmentRecordMasterId = treatmentRecodData.PreTreatmentCheck.TreatmentRecordMasterId,
                UniversalPrecautions = treatmentRecodData.PreTreatmentCheck.UniversalPrecautions,
                MarkComplete = treatmentRecodData.PreTreatmentCheck.MarkComplete,
                MachinePrimeId = (treatmentRecodData.PreTreatmentCheck.MachinePrimeId != null) ? treatmentRecodData.PreTreatmentCheck.MachinePrimeId : 0
            };
            //Lab Values
            treatmentRecordModel.LabValueData = new LabValuesModel
            {
                EBV = treatmentRecodData.LabValues.EBV,
                ECV10 = treatmentRecodData.LabValues.ECV10,
                ECV15 = treatmentRecodData.LabValues.ECV15,
                EPV = treatmentRecodData.LabValues.EPV,
                Height = treatmentRecodData.LabValues.Height,
                HGB = treatmentRecodData.LabValues.HGB,
                HTC = treatmentRecodData.LabValues.HTC,
                Id = treatmentRecodData.LabValues.Id,
                MarkComplete = treatmentRecodData.LabValues.MarkComplete,
                TreatmentRecordMasterId = treatmentRecodData.LabValues.TreatmentRecordMasterId
            };
            //Other Lab Values
            var otherLabValues = _treatmentRecordServices.GetOtherLabValueByLabValueId(treatmentRecodData.LabValues.Id);
            if (otherLabValues.Count() != 0)
            {
                foreach (var othervalue in otherLabValues)
                {
                    var otherValuesData = new OtherLabValuesModel
                    {
                        ContentName = othervalue.ContentName,
                        Id = othervalue.Id,
                        ContentValue = othervalue.ContentValue,
                        LabValuesId = othervalue.LabValuesId
                    };
                    treatmentRecordModel.LabValueData.OtherLabValues.Add(otherValuesData);

                }
            }
            //Supplies And Access
            treatmentRecordModel.SuppliesData = new SuppliesAndAccessModel
            {
                ACDLot = treatmentRecodData.SuppliesVM.ACDLot,
                ACDLotExpDate = treatmentRecodData.SuppliesVM.ACDLotExpDate,
                ACEInhibitors = treatmentRecodData.SuppliesVM.ACEInhibitors,
                BloodWarmer = treatmentRecodData.SuppliesVM.BloodWarmer,
                Comments = treatmentRecodData.SuppliesVM.Comments,
                CreatedOn = treatmentRecodData.SuppliesVM.CreatedOn,
                CVC = treatmentRecodData.SuppliesVM.CVC,
                DateDC = treatmentRecodData.SuppliesVM.DateDC,
                Deleted = treatmentRecodData.SuppliesVM.Deleted,
                Id = treatmentRecodData.SuppliesVM.Id,
                LastDoseDate = treatmentRecodData.SuppliesVM.LastDoseDate,
                LastUpdated = treatmentRecodData.SuppliesVM.LastUpdated,
                Locations = treatmentRecodData.SuppliesVM.Locations,
                MarkComplete = treatmentRecodData.SuppliesVM.MarkComplete,
                MedsReviewed = treatmentRecodData.SuppliesVM.MedsReviewed,
                NSPrimeLot = treatmentRecodData.SuppliesVM.NSPrimeLot,
                NSPrimeLotExpDate = treatmentRecodData.SuppliesVM.NSPrimeLotExpDate,
                Peripheral = treatmentRecodData.SuppliesVM.Peripheral,
                Rate = treatmentRecodData.SuppliesVM.Rate,
                Serial = treatmentRecodData.SuppliesVM.Serial,
                TEMP = treatmentRecodData.SuppliesVM.TEMP,
                TreatmentRecordId = treatmentRecodData.SuppliesVM.TreatmentRecordId,
                Type = treatmentRecodData.SuppliesVM.Type,
                Vortex = treatmentRecodData.SuppliesVM.Vortex

            };
            //Pre treatment Assessment
            treatmentRecordModel.PreTreatmentAssessmentData = new PreTreatmentAssessmentModel
            {
                BleendAutoTextId = treatmentRecodData.PreTreatmentAssessment.BleendAutoTextId,
                CreatedOn = treatmentRecodData.PreTreatmentAssessment.CreatedOn,
                EdemaAutoTextId = treatmentRecodData.PreTreatmentAssessment.EdemaAutoTextId,
                Id = treatmentRecodData.PreTreatmentAssessment.Id,
                IsAlert = treatmentRecodData.PreTreatmentAssessment.IsAlert,
                IsBleeding = treatmentRecodData.PreTreatmentAssessment.IsBleeding,
                IsComatose = treatmentRecodData.PreTreatmentAssessment.IsComatose,
                IsDeleted = treatmentRecodData.PreTreatmentAssessment.IsDeleted,
                IsEasy = treatmentRecodData.PreTreatmentAssessment.IsEasy,
                IsEdema = treatmentRecodData.PreTreatmentAssessment.IsEdema,
                IsFiO2 = treatmentRecodData.PreTreatmentAssessment.IsFiO2,
                IsLabored = treatmentRecodData.PreTreatmentAssessment.IsLabored,
                IsLethargic = treatmentRecodData.PreTreatmentAssessment.IsLethargic,
                IsMask = treatmentRecodData.PreTreatmentAssessment.IsMask,
                IsNC = treatmentRecodData.PreTreatmentAssessment.IsNC,
                IsNumbness = treatmentRecodData.PreTreatmentAssessment.IsNumbness,
                IsRoomAir = treatmentRecodData.PreTreatmentAssessment.IsRoomAir,
                IsVent = treatmentRecodData.PreTreatmentAssessment.IsVent,
                IsWeakness = treatmentRecodData.PreTreatmentAssessment.IsWeakness,
                LastUpdated = treatmentRecodData.PreTreatmentAssessment.LastUpdated,
                LocationAutoTextId = treatmentRecodData.PreTreatmentAssessment.LungSoundsAutoTextId,
                LungSoundsAutoTextId = treatmentRecodData.PreTreatmentAssessment.LungSoundsAutoTextId,
                MarkComplete = treatmentRecodData.PreTreatmentAssessment.MarkComplete,
                NumbnessAutoTextId = treatmentRecodData.PreTreatmentAssessment.NumbnessAutoTextId,
                OrientedX = treatmentRecodData.PreTreatmentAssessment.OrientedX,
                OSat = treatmentRecodData.PreTreatmentAssessment.OSat,
                PainAutoTextId = treatmentRecodData.PreTreatmentAssessment.PainAutoTextId,
                RythmAutoTextId = treatmentRecodData.PreTreatmentAssessment.RythmAutoTextId,
                SkinAutoTextId = treatmentRecodData.PreTreatmentAssessment.SkinAutoTextId,
                TreatmentRecordMasterId = treatmentRecodData.PreTreatmentAssessment.TreatmentRecordMasterId,
                WeaknessAutoTextId = treatmentRecodData.PreTreatmentAssessment.WeaknessAutoTextId
            };
            //Run Values
            var runvaluesData = _treatmentRecordServices.GetRunValuesByTreatmentRecordId(treatmentReocrd.Id);
            if (runvaluesData.Count() != 0)
            {
                foreach (var runvalue in runvaluesData)
                {
                    var RunValuesModel = new RunValuesModel
                    {
                        ACFlowRate = runvalue.ACFlowRate,
                        ACFlowVol = runvalue.ACFlowVol,
                        BP = runvalue.BP,
                        CollectFlowRate = runvalue.CollectFlowRate,
                        CollectFlowVol = runvalue.CollectFlowVol,
                        CreatedOn = runvalue.CreatedOn,
                        Deleted = runvalue.Deleted,
                        Id = runvalue.Id,
                        IntelFlowRate = runvalue.IntelFlowRate,
                        IntelFlowVol = runvalue.IntelFlowVol,
                        LastUpdated = runvalue.LastUpdated,
                        LotNo = runvalue.LotNo,
                        P = runvalue.P,
                        T = runvalue.T,
                        PlasmaFlowRate = runvalue.PlasmaFlowRate,
                        PlasmaFlowVol = runvalue.PlasmaFlowVol,
                        R = runvalue.R,
                        ReplaceFluidId = runvalue.ReplaceFluidId,
                        RunTime = runvalue.RunTime,
                        TreatmentRecordMasterId = runvalue.TreatmentRecordMasterId,
                        WarmerTemp = runvalue.WarmerTemp
                    };
                    treatmentRecordModel.RunValues.runValuesList.Add(RunValuesModel);

                }
                treatmentRecordModel.RunValues.MarkComplete = runvaluesData[0].MarkComplete;
            }
            //Final Values

            treatmentRecordModel.FinalValuesData = new FinalValuesAndAccessPostAssessmentModel
            {
                AC = treatmentRecodData.FinalValuesVM.AC,
                BP = treatmentRecodData.FinalValuesVM.BP,
                ChlorhexidineCapApplied = treatmentRecodData.FinalValuesVM.ChlorhexidineCapApplied,
                Collet = treatmentRecodData.FinalValuesVM.Collet,
                Comments = treatmentRecodData.FinalValuesVM.Comments,
                CreatedOn = treatmentRecodData.FinalValuesVM.CreatedOn,
                Deleted = treatmentRecodData.FinalValuesVM.Deleted,
                FluidBalance = treatmentRecodData.FinalValuesVM.FluidBalance,
                Heparin = treatmentRecodData.FinalValuesVM.Heparin,
                Id = treatmentRecodData.FinalValuesVM.Id,
                Inlet = treatmentRecodData.FinalValuesVM.Inlet,
                Intact = treatmentRecodData.FinalValuesVM.Intact,
                LastUpdated = treatmentRecodData.FinalValuesVM.LastUpdated,
                MarkComplete = treatmentRecodData.FinalValuesVM.MarkComplete,
                NewDressing = treatmentRecodData.FinalValuesVM.NewDressing,
                P = treatmentRecodData.FinalValuesVM.P,
                Plasma = treatmentRecodData.FinalValuesVM.Plasma,
                R = treatmentRecodData.FinalValuesVM.R,
                Reinforced = treatmentRecodData.FinalValuesVM.Reinforced,
                Saline = treatmentRecodData.FinalValuesVM.Saline,
                T = treatmentRecodData.FinalValuesVM.T,
                Time = treatmentRecodData.FinalValuesVM.Time,
                TreatmentRecordId = treatmentRecodData.FinalValuesVM.TreatmentRecordId
                
            };
            //post treatment
            treatmentRecordModel.PostTreatmentData = new PostTreatmentModel {
            Id = treatmentRecodData.PostTreatmentVM.Id,
            IsBiohazardWasteDisposed = treatmentRecodData.PostTreatmentVM.IsBiohazardWasteDisposed,
            IsEquipmentCleanedAndDisinfected = treatmentRecodData.PostTreatmentVM.IsEquipmentCleanedAndDisinfected,
            TreatmentRecordId = treatmentRecodData.PostTreatmentVM.TreatmentRecordId,
            IsPostCVCCarePerPolicy = treatmentRecodData.PostTreatmentVM.IsPostCVCCarePerPolicy,
            IsRinseBackComplete = treatmentRecodData.PostTreatmentVM.IsRinseBackComplete,
            IsSideRailsUp = treatmentRecodData.PostTreatmentVM.IsSideRailsUp,
            MarkComplete = treatmentRecodData.PostTreatmentVM.MarkComplete
           
            };

            var Medication = _treatmentRecordServices.GetMedicationByPostTreatmentId(treatmentRecordModel.PostTreatmentData.Id);
            if (Medication.Count() != 0)
            {
                foreach (var medicationData in Medication) {
                    var medicationdata = new MedicationModel
                    {
                        Comments = medicationData.Comments,
                        Dosage = medicationData.Dosage,
                        Id = medicationData.Id,
                        Name = medicationData.Name,
                        PostTreatmentId = medicationData.PostTreatmentId,
                        Route = medicationData.Route
                    };
                }
            }
            //Note and Report
            treatmentRecordModel.NoteAndReportData = new NoteAndReportModel
            {
                CreatedOn = treatmentRecodData.NoteAndReportVM.CreatedOn,
                Deleted = treatmentRecodData.NoteAndReportVM.Deleted,
                Id = treatmentRecodData.NoteAndReportVM.Id,
                IsTreatmentCompletedWOIncident = treatmentRecodData.NoteAndReportVM.IsTreatmentCompletedWOIncident,
                LastUpdated = treatmentRecodData.NoteAndReportVM.LastUpdated,
                MarkComplete = treatmentRecodData.NoteAndReportVM.MarkComplete,
                Note = treatmentRecodData.NoteAndReportVM.Note,
                ReportGivenTo = treatmentRecodData.NoteAndReportVM.ReportGivenTo,
                TreatmentRecordMasterId = treatmentRecodData.NoteAndReportVM.TreatmentRecordMasterId
            };

            resultModel.Message = ValidationMessages.Success;
            resultModel.Status = 1;
            resultModel.Response = treatmentRecordModel;
            return Ok(resultModel);

        }



    }
}