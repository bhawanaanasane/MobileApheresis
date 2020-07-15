using CRM.Core.Domain.TreatmentRecords;
using CRM.Data.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.TreatmentRecords
{
   public partial class TreatmentRecordServices: ITreatmentRecordServices
    {
        #region Fields
        private readonly IRepository<PatientInfo> _patientInforepository;
        private readonly IRepository<PatientMaster> _patientMasterRepository;
        private readonly IRepository<TreatmentRecordMaster> _treatmentRecordMasterRepository;
        private readonly IRepository<DoctorInfo> _doctorInfoRepository;
        private readonly IRepository<MachineMaster> _machineRepository;
        private readonly IRepository<PreTreatmentCheck> _preTreatmentCheckRepository;
        private readonly IRepository<LabValues> _labValuesRepository;
        private readonly IRepository<OtherLabValues> _otherlabValuesRepository;
        private readonly IRepository<SuppliesAndAccess> _suppliesRepository;
      

        private readonly IRepository<PreTreatmentAssessment> _preTreatmentAssessmentRepository;
        private readonly IRepository<RunValues> _runVluesRepository;
        private readonly IRepository<FinalValuesAndAccessPostAssessment> _finalVluesRepository;
       
        private readonly IRepository<PostTreatment> _postTreatmentRepository;
        private readonly IRepository<Medication> _medicationRepository;
        private readonly IRepository<NoteAndReportMaster> _noteAndReportMasterRepository;

        #endregion
        #region CTOR
        public TreatmentRecordServices(IRepository<PatientInfo> PatientInforepository,
            IRepository<PatientMaster> PatientMasterRepository,
            IRepository<TreatmentRecordMaster> TreatmentRecordMasterRepository,
            IRepository<DoctorInfo> DoctorInfoRepository,
            IRepository<MachineMaster> MachineRepository,
            IRepository<PreTreatmentCheck> PreTreatmentCheckRepository,
            IRepository<LabValues> LabValuesRepository,
            IRepository<OtherLabValues> OtherlabValuesRepository,
            IRepository<SuppliesAndAccess> SuppliesRepository,

           
            IRepository<PreTreatmentAssessment> PreTreatmentAssessmentRepository,
            IRepository<RunValues> RunVluesRepository,
            IRepository<FinalValuesAndAccessPostAssessment> FinalVluesRepository,
           
            IRepository<PostTreatment> PostTreatmentRepository,
        IRepository<Medication> MedicationRepository,
        IRepository<NoteAndReportMaster> NoteAndReportMasterRepository) {

            this._patientInforepository = PatientInforepository;
            this._patientMasterRepository = PatientMasterRepository;
            this._treatmentRecordMasterRepository = TreatmentRecordMasterRepository;
            this._doctorInfoRepository = DoctorInfoRepository;
            this._machineRepository = MachineRepository;
            this._preTreatmentCheckRepository = PreTreatmentCheckRepository;
            this._labValuesRepository = LabValuesRepository;
            this._otherlabValuesRepository = OtherlabValuesRepository;
            this._suppliesRepository = SuppliesRepository;
           

            this._preTreatmentAssessmentRepository = PreTreatmentAssessmentRepository;
            this._runVluesRepository = RunVluesRepository;
            this._finalVluesRepository = FinalVluesRepository;
           
            this._medicationRepository = MedicationRepository;
            this._postTreatmentRepository = PostTreatmentRepository;
            this._noteAndReportMasterRepository = NoteAndReportMasterRepository;


        }
        #endregion


        #region PatientMaster
        /// <summary>
        /// Insert a PatientMaster
        /// </summary>
        /// <param name="PatientMaster">PatientMaster</param>
      public  void InsertPatientMaster(PatientMaster patientMaster)
        {
            if (patientMaster == null)
                throw new ArgumentNullException(nameof(patientMaster));

            _patientMasterRepository.Insert(patientMaster);
        }

        /// <summary>
        /// Updates the PatientMaster
        /// </summary>
        /// <param name="PatientInfo">PatientInfo</param>
        public void UpdatePatientMaster(PatientMaster patientMaster)
        {
            if (patientMaster == null)
                throw new ArgumentNullException(nameof(patientMaster));

            _patientMasterRepository.Update(patientMaster);
        }

        /// <summary>
        /// Gets a PatientMaster
        /// </summary>
        /// <param name="PatientInfoId">PatientMaster identifier</param>
        /// <returns>A PatientMaster</returns>
        public PatientMaster GetPatientMasterById(int PatientMasterId)
        {
            var query = from h in _patientMasterRepository.Table
                        where h.Id == PatientMasterId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all PatientMaster
        /// </summary>

        /// <returns>A PatientMaster</returns>
        public IList<PatientMaster> GetAllPatientMaster()
        {
            var query = from h in _patientMasterRepository.Table
                       
                        select h;
            return query.ToList();
        }
        #endregion




        #region PatientInfo
        /// <summary>
        /// Insert a PatientInfo
        /// </summary>
        /// <param name="Nurse">Nurse</param>
        public void InsertPatientInfo(PatientInfo patientInfo) {
            if (patientInfo == null)
                throw new ArgumentNullException(nameof(patientInfo));

            _patientInforepository.Insert(patientInfo);
        }

        /// <summary>
        /// Updates the PatientInfo
        /// </summary>
        /// <param name="PatientInfo">PatientInfo</param>
        public void UpdatePatientInfo(PatientInfo patientInfo) {
            if (patientInfo == null)
                throw new ArgumentNullException(nameof(patientInfo));

            _patientInforepository.Update(patientInfo);
        }

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="PatientInfoId">PatientInfo identifier</param>
        /// <returns>A Nurse</returns>
        public PatientInfo GetPatientInfoById(int PatientInfoId) {
            var query = from h in _patientInforepository.Table
                        where h.Id == PatientInfoId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="HospitalId">Hospital identifier</param>
        /// <returns>A Nurse</returns>
       public IList<PatientInfo> GetPatientInfoByHospitalId(int HospitalId)
        {
            var query = from h in _patientInforepository.Table
                        where h.HospitalMasterId == HospitalId
                        select h;
            return query.ToList();
        }
        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="NurseId">Nurse identifier</param>
        /// <returns>A List</returns>
        public  IList<PatientInfo> GetPatientInfoByNurseId(int NurseId)
        {
            var query = from h in _patientInforepository.Table
                        where h.NurseMasterId == NurseId
                        select h;
            return query.ToList();
        }
        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="ProcedureId">Procedure identifier</param>
        /// <returns>A List</returns>
        public IList<PatientInfo> GetPatientInfoByProcedureId(int ProcedureId)
        {
            var query = from h in _patientInforepository.Table
                        where h.ProcedureId == ProcedureId
                        select h;
            return query.ToList();
        }

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A PatientInfo</returns>
        public PatientInfo GetPatientInfoByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _patientInforepository.Table
                        where h.TreatmentRecordMasterId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        ///// <summary>
        ///// Gets a PatientInfo List
        ///// </summary>
        ///// <param name="PatientMasterId">PatientMaster identifier</param>
        ///// <returns>A Nurse</returns>
        //public IList<PatientInfo> GetPatientInfoByPatientMasterId(int PatientMasterId)
        //{
        //    var query = from h in _patientInforepository.Table
        //                where h.PatientMasterId == PatientMasterId
        //                select h;
        //    return query.ToList();
        //}

        /// <summary>
        /// Gets all PatientInfo
        /// </summary>

        /// <returns>A Nurse</returns>
        public IList<PatientInfo> GetAllPatientInfo() {
            var query = from h in _patientInforepository.Table                                             
                        select h;
            return query.ToList();
        }
        #endregion


        #region TreatmentRecords
        /// <summary>
        /// Insert a TreatmentRecords
        /// </summary>
        /// <param name="TreatmentRecords">TreatmentRecords</param>
        public void InsertTreatmentRecords(TreatmentRecordMaster treatmentRecordMaster)
        {
            if (treatmentRecordMaster == null)
                throw new ArgumentNullException(nameof(treatmentRecordMaster));

            _treatmentRecordMasterRepository.Insert(treatmentRecordMaster);
        }

        /// <summary>
        /// Updates the TreatmentRecords
        /// </summary>
        /// <param name="TreatmentRecords">TreatmentRecords</param>
        public void UpdateTreatmentRecords(TreatmentRecordMaster treatmentRecordMaster)
        {
            if (treatmentRecordMaster == null)
                throw new ArgumentNullException(nameof(treatmentRecordMaster));

            _treatmentRecordMasterRepository.Update(treatmentRecordMaster);
        }

        /// <summary>
        /// Gets a TreatmentRecords
        /// </summary>
        /// <param name="TreatmentRecordsId">TreatmentRecords identifier</param>
        /// <returns>A TreatmentRecords</returns>
        public TreatmentRecordMaster GetTreatmentRecordsById(int TreatmentRecordsId)
        {
            var query = from h in _treatmentRecordMasterRepository.Table
                        where h.Id == TreatmentRecordsId
                        select h;
            return query.FirstOrDefault();
        }


        public TreatmentRecordMaster GetTreatmentRecordsByAppointmentDateId(int AppointmentDateId)
        {
            var query = from h in _treatmentRecordMasterRepository.Table
                        where h.AppointmentDateId == AppointmentDateId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all TreatmentRecords
        /// </summary>

        /// <returns>A Nurse</returns>
        public IList<TreatmentRecordMaster> GetAllTreatmentRecords()
        {
            var query = from h in _treatmentRecordMasterRepository.Table
                        select h;
            return query.ToList();
        }



        /// <summary>
        /// Auto Increase Lot No
        /// </summary>
        /// <param name="LotNo">LotNo</param>
        public string GetTreatmentRecordNo()
        {
            var query = from p in _treatmentRecordMasterRepository.Table

                        select p;

            string TreatmentRecordNo = "";
            TreatmentRecordNo = (1).ToString().PadLeft(4, '0');
            if (query.Any())
            {
                var treatmentRecordCount = query.Count();
                
                int count = 0;
                int length = 0;
                query = query.Where(v => !v.Deleted);
                if (treatmentRecordCount != 1)
                {

                    TreatmentRecordNo = (query.Max(a => Convert.ToInt32(a.TreatmentRecordNo) + 1)).ToString();
                }

                count = (Convert.ToInt32(TreatmentRecordNo)).ToString().Length;
                if (count < 4)
                {
                    length = 4 - count;

                    TreatmentRecordNo = (Convert.ToInt32(TreatmentRecordNo)).ToString().PadLeft(length + count, '0');

                }


            }
            return TreatmentRecordNo;
        }

        #endregion

        #region DoctorInfo
        /// <summary>
        /// Insert a DoctorInfo
        /// </summary>
        /// <param name="DoctorInfo">DoctorInfo</param>
        public void InsertDoctorInfo(DoctorInfo doctorInfo)
        {
            if (doctorInfo == null)
                throw new ArgumentNullException(nameof(doctorInfo));

            _doctorInfoRepository.Insert(doctorInfo);
        }

        /// <summary>
        /// Updates the DoctorInfo
        /// </summary>
        /// <param name="DoctorInfo">DoctorInfo</param>
        public void UpdateDoctorInfo(DoctorInfo doctorInfo)
        {
            if (doctorInfo == null)
                throw new ArgumentNullException(nameof(doctorInfo));

            _doctorInfoRepository.Update(doctorInfo);
        }

        /// <summary>
        /// Gets a DoctorInfo
        /// </summary>
        /// <param name="DoctorInfoId">DoctorInfo identifier</param>
        /// <returns>A DoctorInfo</returns>
        public DoctorInfo GetDoctorInfoById(int DoctorInfoId)
        {
            var query = from h in _doctorInfoRepository.Table
                        where h.Id == DoctorInfoId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a DoctorInfo
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A DoctorInfo</returns>
       public DoctorInfo GetDoctorInfoByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _doctorInfoRepository.Table
                        where h.TreatmentRecordMasterId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all DoctorInfo
        /// </summary>

        /// <returns>A DoctorInfo</returns>
        public IList<DoctorInfo> GetAllDoctorInfo()
        {
            var query = from h in _doctorInfoRepository.Table
                       
                        select h;
            return query.ToList();
        }
        #endregion

        #region MachineInfo
        /// <summary>
        /// Insert a MachineInfo
        /// </summary>
        /// <param name="MachineInfo">MachineInfo</param>
       public void InsertMachineInfo(MachineMaster machineMaster)
        {
            if (machineMaster == null)
                throw new ArgumentNullException(nameof(machineMaster));

            _machineRepository.Insert(machineMaster);
        }

        /// <summary>
        /// Updates the MachineInfo
        /// </summary>
        /// <param name="MachineInfo">MachineInfo</param>
        public void UpdateMachineInfo(MachineMaster machineMaster)
        {
            if (machineMaster == null)
                throw new ArgumentNullException(nameof(machineMaster));

            _machineRepository.Update(machineMaster);
        }

        /// <summary>
        /// Gets a MachineInfo
        /// </summary>
        /// <param name="MachineInfoId">MachineInfo identifier</param>
        /// <returns>A MachineInfo</returns>
        public MachineMaster GetMachineInfoById(int MachineInfoId)
        {
            var query = from h in _machineRepository.Table
                        where h.Id == MachineInfoId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a MachineInfo
        /// </summary>
        /// <param name="EquipmentId">Equipment identifier</param>
        /// <returns>A MachineInfo</returns>
       public IList<MachineMaster> GetMachineInfoByEquipmentId(int EquipmentId)
        {
            var query = from h in _machineRepository.Table
                        where h.EquipmentId == EquipmentId
                        select h;
            return query.ToList();
        }

        /// <summary>
        /// Gets a MachineInfo
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A MachineInfo</returns>
        public  MachineMaster GetMachineInfoByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _machineRepository.Table
                        where h.TreatmentRecordMasterId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all MachineInfo
        /// </summary>

        /// <returns>A MachineInfo</returns>
        public IList<MachineMaster> GetAllMachineInfo()
        {
            var query = from h in _machineRepository.Table
                       
                        select h;
            return query.ToList();
        }
        #endregion


        #region PreTreatmentCheck
        /// <summary>
        /// Insert a PreTreatmentCheck
        /// </summary>
        /// <param name="MachineInfo">PreTreatmentCheck</param>
       public void InsertPreTreatmentCheck(PreTreatmentCheck preTreatmentCheck)
        {
            if (preTreatmentCheck == null)
                throw new ArgumentNullException(nameof(preTreatmentCheck));

            _preTreatmentCheckRepository.Insert(preTreatmentCheck);
        }

        /// <summary>
        /// Updates the PreTreatmentCheck
        /// </summary>
        /// <param name="PreTreatmentCheck">PreTreatmentCheck</param>
        public void UpdatePreTreatmentCheck(PreTreatmentCheck preTreatmentCheck)
        {
            if (preTreatmentCheck == null)
                throw new ArgumentNullException(nameof(preTreatmentCheck));

            _preTreatmentCheckRepository.Update(preTreatmentCheck);
        }

        /// <summary>
        /// Gets a PreTreatmentCheck
        /// </summary>
        /// <param name="PreTreatmentCheckId">PreTreatmentCheck identifier</param>
        /// <returns>A PreTreatmentCheck</returns>
        public PreTreatmentCheck GetPreTreatmentCheckById(int PreTreatmentCheckId)
        {
            var query = from h in _preTreatmentCheckRepository.Table
                        where h.Id == PreTreatmentCheckId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a PreTreatmentCheck
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A PreTreatmentCheck</returns>
       public PreTreatmentCheck GetPreTreatmentCheckByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _preTreatmentCheckRepository.Table
                        where h.TreatmentRecordMasterId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all PreTreatmentCheck
        /// </summary>

        /// <returns>A MachineInfo</returns>
        public IList<PreTreatmentCheck> GetAllPreTreatmentCheck()
        {
            var query = from h in _preTreatmentCheckRepository.Table
                        
                        select h;
            return query.ToList();
        }
        #endregion

        #region LabValue
        /// <summary>
        /// Insert a LabValues
        /// </summary>
        /// <param name="LabValues">LabValues</param>
     public  void InsertLabValues(LabValues labValue)
        {
            if (labValue == null)
                throw new ArgumentNullException(nameof(labValue));

            _labValuesRepository.Insert(labValue);
        }

        /// <summary>
        /// Updates the LabValues
        /// </summary>
        /// <param name="LabValues">LabValues</param>
        public void UpdateLabValues(LabValues labValues)
        {
            if (labValues == null)
                throw new ArgumentNullException(nameof(labValues));

            _labValuesRepository.Update(labValues);
        }

        /// <summary>
        /// Gets a LabValues
        /// </summary>
        /// <param name="LabValuesId">LabValues identifier</param>
        /// <returns>A LabValues</returns>
        public LabValues GetLabValuesById(int LabValuesId)
        {
            var query = from h in _labValuesRepository.Table
                        where h.Id == LabValuesId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a LabValues
        /// </summary>
        /// <param name="TreatmentId">Treatment identifier</param>
        /// <returns>A LabValues</returns>
       public LabValues GetLabValuesByTreatmentId(int TreatmentId)
        {
            var query = from h in _labValuesRepository.Table
                        where h.TreatmentRecordMasterId == TreatmentId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all LabValues
        /// </summary>

        /// <returns>A LabValues</returns>
        public IList<LabValues> GetAllLabValues()
        {
            var query = from h in _labValuesRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion

        #region OtherLabValues

        /// <summary>
        /// Gets a OtherLabValues
        /// </summary>
        /// <param name="OtherLabValuesId">OtherLabValues identifier</param>
        /// <returns>A OtherLabValues</returns>
        public OtherLabValues GetOtherLabValueById(int otherLabValueId)
        {
            var query = from q in _otherlabValuesRepository.Table
                        where q.Id == otherLabValueId
                        select q;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a OtherLabValues
        /// </summary>
        /// <param name="OtherLabValuesId">OtherLabValues identifier</param>
        /// <returns>A OtherLabValues</returns>
        public IList<OtherLabValues> GetOtherLabValueByLabValueId(int LabValueId)
        {
            var query = from q in _otherlabValuesRepository.Table
                        where q.LabValuesId == LabValueId
                        select q;
            return query.ToList();
        }

        /// <summary>
        /// Updates the OtherLabValues
        /// </summary>
        /// <param name="OtherLabValues">OtherLabValues</param>
        public void UpdateOtherLabValues(OtherLabValues otherLabValues)
        {
            if (otherLabValues == null)
                throw new ArgumentNullException(nameof(otherLabValues));

            _otherlabValuesRepository.Update(otherLabValues);
        }

        #endregion

        #region Supplies
        /// <summary>
        /// Insert a Supplies
        /// </summary>
        /// <param name="Supplies">Supplies</param>
      public  void InsertSupplies(SuppliesAndAccess supplies)
        {
            if (supplies == null)
                throw new ArgumentNullException(nameof(supplies));

            _suppliesRepository.Insert(supplies);
        }

        /// <summary>
        /// Updates the Supplies
        /// </summary>
        /// <param name="Supplies">Supplies</param>
        public void UpdateSupplies(SuppliesAndAccess supplies)
        {
            if (supplies == null)
                throw new ArgumentNullException(nameof(supplies));

            _suppliesRepository.Update(supplies);
        }

        /// <summary>
        /// Gets a Supplies
        /// </summary>
        /// <param name="SuppliesId">Supplies identifier</param>
        /// <returns>A Supplies</returns>
        public SuppliesAndAccess GetSuppliesById(int SuppliesId)
        {
            var query = from h in _suppliesRepository.Table
                        where h.Id == SuppliesId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a Supplies
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A Supplies</returns>
       public SuppliesAndAccess GetSuppliesByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _suppliesRepository.Table
                        where h.TreatmentRecordId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all Supplies
        /// </summary>

        /// <returns>A Supplies</returns>
        public IList<SuppliesAndAccess> GetAllSupplies()
        {
            var query = from h in _suppliesRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion


     

        #region PreTreatmentAssessment
        /// <summary>
        /// Insert a PreTreatmentAssessment
        /// </summary>
        /// <param name="PreTreatmentAssessment">PreTreatmentAssessment</param>
        public void InsertPreTreatmentAssessment(PreTreatmentAssessment preTreatmentAssessment)
        {
            if (preTreatmentAssessment == null)
                throw new ArgumentNullException(nameof(preTreatmentAssessment));

            _preTreatmentAssessmentRepository.Insert(preTreatmentAssessment);
        }

        /// <summary>
        /// Updates the PreTreatmentAssessment
        /// </summary>
        /// <param name="PreTreatmentAssessment">PreTreatmentAssessment</param>
        public void UpdatePreTreatmentAssessment(PreTreatmentAssessment preTreatmentAssessment)
        {
            if (preTreatmentAssessment == null)
                throw new ArgumentNullException(nameof(preTreatmentAssessment));

            _preTreatmentAssessmentRepository.Update(preTreatmentAssessment);
        }

        /// <summary>
        /// Gets a PreTreatmentAssessment
        /// </summary>
        /// <param name="PreTreatmentAssessmentId">PreTreatmentAssessment identifier</param>
        /// <returns>A PreTreatmentAssessment</returns>
        public PreTreatmentAssessment GetPreTreatmentAssessmentById(int PreTreatmentAssessmentId)
        {
            var query = from h in _preTreatmentAssessmentRepository.Table
                        where h.Id == PreTreatmentAssessmentId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a PreTreatmentAssessment
        /// </summary>
        /// <param name="AutoTextId">AutoText identifier</param>
        /// <returns>A PreTreatmentAssessment</returns>
       public IList<PreTreatmentAssessment> GetPreTreatmentAssessmentByAutoTextId(int AutoTextId)
        {
            var query = from h in _preTreatmentAssessmentRepository.Table
                        where h.WeaknessAutoTextId == AutoTextId ||
                        h.SkinAutoTextId == AutoTextId
                        || h.RythmAutoTextId == AutoTextId ||
                        h.PainAutoTextId == AutoTextId ||
                        h.NumbnessAutoTextId ==AutoTextId ||
                        h.LungSoundsAutoTextId == AutoTextId ||
                        h.LocationAutoTextId == AutoTextId ||
                        h.EdemaAutoTextId == AutoTextId ||
                        h.BleendAutoTextId == AutoTextId
                        
                        select h;
            return query.ToList();
        }

        /// <summary>
        /// Gets a PreTreatmentAssessment
        /// </summary>
        /// <param name="TreatmentRercordId">TreatmentRercord identifier</param>
        /// <returns>A PreTreatmentAssessment</returns>
        public PreTreatmentAssessment GetPreTreatmentAssessmentByTreatmentRercordId(int TreatmentRercordId)
        {
            var query = from h in _preTreatmentAssessmentRepository.Table
                        where h.TreatmentRecordMasterId == TreatmentRercordId
                        select h;
            return query.FirstOrDefault();
        }


        /// <summary>
        /// Gets all PreTreatmentAssessment
        /// </summary>

        /// <returns>A PreTreatmentAssessment</returns>
        public IList<PreTreatmentAssessment> GetAllPreTreatmentAssessment()
        {
            var query = from h in _preTreatmentAssessmentRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion


        #region RunValues
        /// <summary>
        /// Insert a RunValues
        /// </summary>
        /// <param name="RunValues">RunValues</param>
        public void InsertRunValues(RunValues runValues)
        {
            if (runValues == null)
                throw new ArgumentNullException(nameof(runValues));

            _runVluesRepository.Insert(runValues);
        }

        /// <summary>
        /// Updates the RunValues
        /// </summary>
        /// <param name="RunValues">RunValues</param>
        public void UpdateRunValues(RunValues runValues)
        {
            if (runValues == null)
                throw new ArgumentNullException(nameof(runValues));

            _runVluesRepository.Update(runValues);
        }

        /// <summary>
        /// Gets a RunValues
        /// </summary>
        /// <param name="RunValuesId">RunValues identifier</param>
        /// <returns>A RunValues</returns>
        public RunValues GetRunValuesById(int RunValuesId)
        {
            var query = from h in _runVluesRepository.Table
                        where h.Id == RunValuesId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a RunValues
        /// </summary>
        /// <param name="TreatmentRecordId">RunValues identifier</param>
        /// <returns>A RunValues</returns>
        public IList<RunValues> GetRunValuesByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _runVluesRepository.Table
                        where h.TreatmentRecordMasterId == TreatmentRecordId
                        select h;
            return query.ToList();
        }

        /// <summary>
        /// Gets all RunValues
        /// </summary>

        /// <returns>A RunValues</returns>
        public IList<RunValues> GetAllRunValues()
        {
            var query = from h in _runVluesRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion



        #region FinalValues
        /// <summary>
        /// Insert a FinalValues
        /// </summary>
        /// <param name="FinalValues">FinalValues</param>
        public void InsertFinalValues(FinalValuesAndAccessPostAssessment finalValues)
        {
            if (finalValues == null)
                throw new ArgumentNullException(nameof(finalValues));

            _finalVluesRepository.Insert(finalValues);
        }

        /// <summary>
        /// Updates the FinalValues
        /// </summary>
        /// <param name="FinalValues">FinalValues</param>
        public void UpdateFinalValues(FinalValuesAndAccessPostAssessment finalValues)
        {
            if (finalValues == null)
                throw new ArgumentNullException(nameof(finalValues));

            _finalVluesRepository.Update(finalValues);
        }

        /// <summary>
        /// Gets a FinalValues
        /// </summary>
        /// <param name="FinalValuesId">FinalValues identifier</param>
        /// <returns>A FinalValues</returns>
        public FinalValuesAndAccessPostAssessment GetFinalValuesById(int FinalValuesId)
        {
            var query = from h in _finalVluesRepository.Table
                        where h.Id == FinalValuesId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a FinalValues
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A FinalValues</returns>
        public FinalValuesAndAccessPostAssessment GetFinalValuesByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _finalVluesRepository.Table
                        where h.TreatmentRecordId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all FinalValues
        /// </summary>

        /// <returns>A FinalValues</returns>
        public IList<FinalValuesAndAccessPostAssessment> GetAllFinalValues()
        {
            var query = from h in _finalVluesRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion



        #region Medication
        /// <summary>
        /// Insert a Medication
        /// </summary>
        /// <param name="Medication">Medication</param>
        public void InsertMedication(Medication medication)
        {
            if (medication == null)
                throw new ArgumentNullException(nameof(medication));

            _medicationRepository.Insert(medication);
        }

        /// <summary>
        /// Updates the Medication
        /// </summary>
        /// <param name="Medication">Medication</param>
        public void UpdateMedication(Medication medication)
        {
            if (medication == null)
                throw new ArgumentNullException(nameof(medication));

            _medicationRepository.Update(medication);
        }

        /// <summary>
        /// Gets a Medication
        /// </summary>
        /// <param name="MedicationId">Medication identifier</param>
        /// <returns>A Medication</returns>
        public Medication GetMedicationById(int MedicationId)
        {
            var query = from h in _medicationRepository.Table
                        where h.Id == MedicationId
                        select h;
            return query.FirstOrDefault();
        }

        // <summary>
        /// Gets a Medication
        /// </summary>
        /// <param name="MedicationId">Medication identifier</param>
        /// <returns>A Medication</returns>
        public IList<Medication> GetMedicationByPostTreatmentId(int PostTreatmentId)
        {
            var query = from h in _medicationRepository.Table
                        where h.PostTreatmentId == PostTreatmentId
                        select h;
            return query.ToList();
        }

        /// <summary>
        /// Gets all Medication
        /// </summary>

        /// <returns>A Medication</returns>
        public IList<Medication> GetAllMedication()
        {
            var query = from h in _medicationRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion

        #region PostTreatment
        /// <summary>
        /// Insert a PostTreatment
        /// </summary>
        /// <param name="PostTreatment">PostTreatment</param>
        public void InsertPostTreatment(PostTreatment postTreatment)
        {
            if (postTreatment == null)
                throw new ArgumentNullException(nameof(postTreatment));

            _postTreatmentRepository.Insert(postTreatment);
        }

        /// <summary>
        /// Updates the PostTreatment
        /// </summary>
        /// <param name="PostTreatment">PostTreatment</param>
        public void UpdatePostTreatment(PostTreatment postTreatment)
        {
            if (postTreatment == null)
                throw new ArgumentNullException(nameof(postTreatment));

            _postTreatmentRepository.Update(postTreatment);
        }

        /// <summary>
        /// Gets a PostTreatment
        /// </summary>
        /// <param name="PostTreatmentId">PostTreatment identifier</param>
        /// <returns>A PostTreatment</returns>
        public PostTreatment GetPostTreatmentById(int PostTreatmentId)
        {
            var query = from h in _postTreatmentRepository.Table
                        where h.Id == PostTreatmentId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a PostTreatment
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A PostTreatment</returns>
        public PostTreatment GetPostTreatmentByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _postTreatmentRepository.Table
                        where h.TreatmentRecordId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all PostTreatment
        /// </summary>

        /// <returns>A PostTreatment</returns>
        public IList<PostTreatment> GetAllPostTreatment()
        {
            var query = from h in _postTreatmentRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion


        #region NoteAndReport

        /// <summary>
        /// Insert a NoteAndReport
        /// </summary>
        /// <param name="NoteAndReport">NoteAndReport</param>
       public void InsertNoteAndReport(NoteAndReportMaster noteAndReport)
        {
            if (noteAndReport == null)
                throw new ArgumentNullException(nameof(noteAndReport));

            _noteAndReportMasterRepository.Insert(noteAndReport);
        }

        /// <summary>
        /// Updates the NoteAndReport
        /// </summary>
        /// <param name="NoteAndReport">NoteAndReport</param>
        public void UpdateNoteAndReport(NoteAndReportMaster noteAndReport)
        {
            if (noteAndReport == null)
                throw new ArgumentNullException(nameof(noteAndReport));

            _noteAndReportMasterRepository.Update(noteAndReport);
        }

        /// <summary>
        /// Gets a NoteAndReport
        /// </summary>
        /// <param name="NoteAndReportId">NoteAndReport identifier</param>
        /// <returns>A NoteAndReport</returns>
        public NoteAndReportMaster GetNoteAndReportById(int NoteAndReportId)
        {
            var query = from h in _noteAndReportMasterRepository.Table
                        where h.Id == NoteAndReportId
                        select h;
            return query.FirstOrDefault();
        }


        /// <summary>
        /// Gets a NoteAndReport
        /// </summary>
        /// <param name="NoteAndReportId">NoteAndReport identifier</param>
        /// <returns>A NoteAndReport</returns>
        public NoteAndReportMaster GetNoteAndReportByTreatmentRecordId(int TreatmentRecordId)
        {
            var query = from h in _noteAndReportMasterRepository.Table
                        where h.TreatmentRecordMasterId == TreatmentRecordId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all NoteAndReport
        /// </summary>

        /// <returns>A NoteAndReport</returns>
        public IList<NoteAndReportMaster> GetAllNoteAndReport()
        {
            var query = from h in _noteAndReportMasterRepository.Table
                        select h;
            return query.ToList();
        }
        #endregion


    }
}
