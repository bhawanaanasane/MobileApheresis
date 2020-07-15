using CRM.Core.Domain.TreatmentRecords;

using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.TreatmentRecords
{
    
    public partial interface ITreatmentRecordServices
    {

        #region PatientMaster
        /// <summary>
        /// Insert a PatientMaster
        /// </summary>
        /// <param name="PatientMaster">PatientMaster</param>
        void InsertPatientMaster(PatientMaster patientMaster);

        /// <summary>
        /// Updates the PatientMaster
        /// </summary>
        /// <param name="PatientInfo">PatientInfo</param>
        void UpdatePatientMaster(PatientMaster patientMaster);

        /// <summary>
        /// Gets a PatientMaster
        /// </summary>
        /// <param name="PatientInfoId">PatientMaster identifier</param>
        /// <returns>A PatientMaster</returns>
        PatientMaster GetPatientMasterById(int PatientMasterId);

        /// <summary>
        /// Gets all PatientMaster
        /// </summary>

        /// <returns>A PatientMaster</returns>
        IList<PatientMaster> GetAllPatientMaster();
        #endregion


        #region PatientInfo
        /// <summary>
        /// Insert a PatientInfo
        /// </summary>
        /// <param name="Nurse">Nurse</param>
        void InsertPatientInfo(PatientInfo patientInfo);

        /// <summary>
        /// Updates the PatientInfo
        /// </summary>
        /// <param name="PatientInfo">PatientInfo</param>
        void UpdatePatientInfo(PatientInfo patientInfo);

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="PatientInfoId">PatientInfo identifier</param>
        /// <returns>A Nurse</returns>
        PatientInfo GetPatientInfoById(int PatientInfoId);

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="HospitalId">Hospital identifier</param>
        /// <returns>A Nurse</returns>
        IList<PatientInfo> GetPatientInfoByHospitalId(int HospitalId);

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="NurseId">Nurse identifier</param>
        /// <returns>A List</returns>
        IList<PatientInfo> GetPatientInfoByNurseId(int NurseId);

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="ProcedureId">Procedure identifier</param>
        /// <returns>A List</returns>
        IList<PatientInfo> GetPatientInfoByProcedureId(int ProcedureId);

        /// <summary>
        /// Gets a PatientInfo
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A PatientInfo</returns>
        PatientInfo GetPatientInfoByTreatmentRecordId(int TreatmentRecordId);
        ///// <summary>
        ///// Gets a PatientInfo List
        ///// </summary>
        ///// <param name="PatientMasterId">PatientMaster identifier</param>
        ///// <returns>A Nurse</returns>
        //IList<PatientInfo> GetPatientInfoByPatientMasterId(int PatientMasterId);

        /// <summary>
        /// Gets all PatientInfo
        /// </summary>

        /// <returns>A Nurse</returns>
        IList<PatientInfo> GetAllPatientInfo();
        #endregion


        #region TreatmentRecords
        /// <summary>
        /// Insert a TreatmentRecords
        /// </summary>
        /// <param name="TreatmentRecords">TreatmentRecords</param>
        void InsertTreatmentRecords(TreatmentRecordMaster treatmentRecordMaster);

        /// <summary>
        /// Updates the TreatmentRecords
        /// </summary>
        /// <param name="TreatmentRecords">TreatmentRecords</param>
        void UpdateTreatmentRecords(TreatmentRecordMaster treatmentRecordMaster);

        /// <summary>
        /// Gets a TreatmentRecords
        /// </summary>
        /// <param name="TreatmentRecordsId">TreatmentRecords identifier</param>
        /// <returns>A TreatmentRecords</returns>
        TreatmentRecordMaster GetTreatmentRecordsById(int TreatmentRecordsId);

        TreatmentRecordMaster GetTreatmentRecordsByAppointmentDateId(int AppointmentDateId);
        /// <summary>
        /// Gets all TreatmentRecords
        /// </summary>

        /// <returns>A Nurse</returns>
        IList<TreatmentRecordMaster> GetAllTreatmentRecords();

        string GetTreatmentRecordNo();

        #endregion

        #region DoctorInfo
        /// <summary>
        /// Insert a DoctorInfo
        /// </summary>
        /// <param name="DoctorInfo">DoctorInfo</param>
        void InsertDoctorInfo(DoctorInfo doctorInfo);

        /// <summary>
        /// Updates the DoctorInfo
        /// </summary>
        /// <param name="DoctorInfo">DoctorInfo</param>
        void UpdateDoctorInfo(DoctorInfo doctorInfo);

        /// <summary>
        /// Gets a DoctorInfo
        /// </summary>
        /// <param name="DoctorInfoId">DoctorInfo identifier</param>
        /// <returns>A DoctorInfo</returns>
        DoctorInfo GetDoctorInfoById(int DoctorInfoId);

        /// <summary>
        /// Gets a DoctorInfo
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A DoctorInfo</returns>
        DoctorInfo GetDoctorInfoByTreatmentRecordId(int TreatmentRecordId);

        /// <summary>
        /// Gets all DoctorInfo
        /// </summary>

        /// <returns>A DoctorInfo</returns>
        IList<DoctorInfo> GetAllDoctorInfo();
        #endregion

        #region MachineInfo
        /// <summary>
        /// Insert a MachineInfo
        /// </summary>
        /// <param name="MachineInfo">MachineInfo</param>
        void InsertMachineInfo(MachineMaster machineMaster);

        /// <summary>
        /// Updates the MachineInfo
        /// </summary>
        /// <param name="MachineInfo">MachineInfo</param>
        void UpdateMachineInfo(MachineMaster machineMaster);

        /// <summary>
        /// Gets a MachineInfo
        /// </summary>
        /// <param name="MachineInfoId">MachineInfo identifier</param>
        /// <returns>A MachineInfo</returns>
        MachineMaster GetMachineInfoById(int MachineInfoId);

        /// <summary>
        /// Gets a MachineInfo
        /// </summary>
        /// <param name="EquipmentId">Equipment identifier</param>
        /// <returns>A MachineInfo</returns>
        IList<MachineMaster> GetMachineInfoByEquipmentId(int EquipmentId);

        /// <summary>
        /// Gets a MachineInfo
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A MachineInfo</returns>
        MachineMaster GetMachineInfoByTreatmentRecordId(int TreatmentRecordId);

        /// <summary>
        /// Gets all MachineInfo
        /// </summary>

        /// <returns>A MachineInfo</returns>
        IList<MachineMaster> GetAllMachineInfo();
        #endregion

        #region PreTreatmentCheck
        /// <summary>
        /// Insert a PreTreatmentCheck
        /// </summary>
        /// <param name="MachineInfo">PreTreatmentCheck</param>
        void InsertPreTreatmentCheck(PreTreatmentCheck preTreatmentCheck);

        /// <summary>
        /// Updates the PreTreatmentCheck
        /// </summary>
        /// <param name="PreTreatmentCheck">PreTreatmentCheck</param>
        void UpdatePreTreatmentCheck(PreTreatmentCheck preTreatmentCheck);

        /// <summary>
        /// Gets a PreTreatmentCheck
        /// </summary>
        /// <param name="PreTreatmentCheckId">PreTreatmentCheck identifier</param>
        /// <returns>A PreTreatmentCheck</returns>
        PreTreatmentCheck GetPreTreatmentCheckById(int PreTreatmentCheckId);


        /// <summary>
        /// Gets a PreTreatmentCheck
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A PreTreatmentCheck</returns>
        PreTreatmentCheck GetPreTreatmentCheckByTreatmentRecordId(int TreatmentRecordId);

        /// <summary>
        /// Gets all PreTreatmentCheck
        /// </summary>

        /// <returns>A MachineInfo</returns>
        IList<PreTreatmentCheck> GetAllPreTreatmentCheck();
        #endregion


        #region LabValue
        /// <summary>
        /// Insert a LabValues
        /// </summary>
        /// <param name="LabValues">LabValues</param>
        void InsertLabValues(LabValues labValue);

        /// <summary>
        /// Updates the LabValues
        /// </summary>
        /// <param name="LabValues">LabValues</param>
        void UpdateLabValues(LabValues labValues);

        /// <summary>
        /// Gets a LabValues
        /// </summary>
        /// <param name="LabValuesId">LabValues identifier</param>
        /// <returns>A LabValues</returns>
        LabValues GetLabValuesById(int LabValuesId);

        /// <summary>
        /// Gets a LabValues
        /// </summary>
        /// <param name="TreatmentId">Treatment identifier</param>
        /// <returns>A LabValues</returns>
        LabValues GetLabValuesByTreatmentId(int TreatmentId);

        /// <summary>
        /// Gets all LabValues
        /// </summary>

        /// <returns>A LabValues</returns>
        IList<LabValues> GetAllLabValues();
        #endregion

        #region OtherLabValues


        /// <summary>
        /// Gets a OtherLabValues
        /// </summary>
        /// <param name="OtherLabValuesId">OtherLabValues identifier</param>
        /// <returns>A OtherLabValues</returns>
        OtherLabValues GetOtherLabValueById(int otherLabValueId);


        /// <summary>
        /// Gets a OtherLabValues
        /// </summary>
        /// <param name="OtherLabValuesId">OtherLabValues identifier</param>
        /// <returns>A OtherLabValues</returns>
        IList<OtherLabValues> GetOtherLabValueByLabValueId(int LabValueId);

        /// <summary>
        /// Updates the OtherLabValues
        /// </summary>
        /// <param name="OtherLabValues">OtherLabValues</param>
        void UpdateOtherLabValues(OtherLabValues otherLabValues);

        #endregion

        #region Supplies
        /// <summary>
        /// Insert a Supplies
        /// </summary>
        /// <param name="Supplies">Supplies</param>
        void InsertSupplies(SuppliesAndAccess supplies);

        /// <summary>
        /// Updates the Supplies
        /// </summary>
        /// <param name="Supplies">Supplies</param>
        void UpdateSupplies(SuppliesAndAccess supplies);

        /// <summary>
        /// Gets a Supplies
        /// </summary>
        /// <param name="SuppliesId">Supplies identifier</param>
        /// <returns>A Supplies</returns>
        SuppliesAndAccess GetSuppliesById(int SuppliesId);

        /// <summary>
        /// Gets a Supplies
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A Supplies</returns>
        SuppliesAndAccess GetSuppliesByTreatmentRecordId(int TreatmentRecordId);

        /// <summary>
        /// Gets all Supplies
        /// </summary>

        /// <returns>A Supplies</returns>
        IList<SuppliesAndAccess> GetAllSupplies();
        #endregion

      


        #region PreTreatmentAssessment
        /// <summary>
        /// Insert a PreTreatmentAssessment
        /// </summary>
        /// <param name="PreTreatmentAssessment">PreTreatmentAssessment</param>
        void InsertPreTreatmentAssessment(PreTreatmentAssessment preTreatmentAssessment);

        /// <summary>
        /// Updates the PreTreatmentAssessment
        /// </summary>
        /// <param name="PreTreatmentAssessment">PreTreatmentAssessment</param>
        void UpdatePreTreatmentAssessment(PreTreatmentAssessment PreTreatmentAssessment);

        /// <summary>
        /// Gets a PreTreatmentAssessment
        /// </summary>
        /// <param name="PreTreatmentAssessmentId">PreTreatmentAssessment identifier</param>
        /// <returns>A PreTreatmentAssessment</returns>
        PreTreatmentAssessment GetPreTreatmentAssessmentById(int PreTreatmentAssessmentId);

        /// <summary>
        /// Gets a PreTreatmentAssessment
        /// </summary>
        /// <param name="AutoTextId">AutoText identifier</param>
        /// <returns>A PreTreatmentAssessment</returns>
        IList<PreTreatmentAssessment> GetPreTreatmentAssessmentByAutoTextId(int AutoTextId);


        /// <summary>
        /// Gets a PreTreatmentAssessment
        /// </summary>
        /// <param name="TreatmentRercordId">TreatmentRercord identifier</param>
        /// <returns>A PreTreatmentAssessment</returns>
        PreTreatmentAssessment GetPreTreatmentAssessmentByTreatmentRercordId(int TreatmentRercordId);

        /// <summary>
        /// Gets all PreTreatmentAssessment
        /// </summary>

        /// <returns>A PreTreatmentAssessment</returns>
        IList<PreTreatmentAssessment> GetAllPreTreatmentAssessment();
        #endregion

        #region RunValues
        /// <summary>
        /// Insert a RunValues
        /// </summary>
        /// <param name="RunValues">RunValues</param>
        void InsertRunValues(RunValues runValues);

        /// <summary>
        /// Updates the RunValues
        /// </summary>
        /// <param name="RunValues">RunValues</param>
        void UpdateRunValues(RunValues runValues);

        /// <summary>
        /// Gets a RunValues
        /// </summary>
        /// <param name="RunValuesId">RunValues identifier</param>
        /// <returns>A RunValues</returns>
        RunValues GetRunValuesById(int RunValuesId);
        /// <summary>
        /// Gets a RunValues
        /// </summary>
        /// <param name="TreatmentRecordId">RunValues identifier</param>
        /// <returns>A RunValues</returns>
        IList<RunValues> GetRunValuesByTreatmentRecordId (int TreatmentRecordId);
        

        /// <summary>
        /// Gets all RunValues
        /// </summary>

        /// <returns>A RunValues</returns>
        IList<RunValues> GetAllRunValues();
        #endregion

        #region FinalValues
        /// <summary>
        /// Insert a FinalValues
        /// </summary>
        /// <param name="FinalValues">FinalValues</param>
        void InsertFinalValues(FinalValuesAndAccessPostAssessment finalValues);

        /// <summary>
        /// Updates the FinalValues
        /// </summary>
        /// <param name="FinalValues">FinalValues</param>
        void UpdateFinalValues(FinalValuesAndAccessPostAssessment finalValues);

        /// <summary>
        /// Gets a FinalValues
        /// </summary>
        /// <param name="FinalValuesId">FinalValues identifier</param>
        /// <returns>A FinalValues</returns>
        FinalValuesAndAccessPostAssessment GetFinalValuesById(int FinalValuesId);

        /// <summary>
        /// Gets a FinalValues
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A FinalValues</returns>
        FinalValuesAndAccessPostAssessment GetFinalValuesByTreatmentRecordId(int TreatmentRecordId);

        /// <summary>
        /// Gets all FinalValues
        /// </summary>

        /// <returns>A FinalValues</returns>
        IList<FinalValuesAndAccessPostAssessment> GetAllFinalValues();
        #endregion

     

        #region Medication
        /// <summary>
        /// Insert a Medication
        /// </summary>
        /// <param name="Medication">Medication</param>
        void InsertMedication(Medication medication);

        /// <summary>
        /// Updates the Medication
        /// </summary>
        /// <param name="Medication">Medication</param>
        void UpdateMedication(Medication medication);

        /// <summary>
        /// Gets a Medication
        /// </summary>
        /// <param name="MedicationId">Medication identifier</param>
        /// <returns>A Medication</returns>
        Medication GetMedicationById(int MedicationId);

        // <summary>
        /// Gets a Medication
        /// </summary>
        /// <param name="MedicationId">Medication identifier</param>
        /// <returns>A Medication</returns>
        IList<Medication> GetMedicationByPostTreatmentId(int PostTreatmentId);

        /// <summary>
        /// Gets all Medication
        /// </summary>

        /// <returns>A Medication</returns>
        IList<Medication> GetAllMedication();
        #endregion


        #region PostTreatment
        /// <summary>
        /// Insert a PostTreatment
        /// </summary>
        /// <param name="PostTreatment">PostTreatment</param>
        void InsertPostTreatment(PostTreatment postTreatment);

        /// <summary>
        /// Updates the PostTreatment
        /// </summary>
        /// <param name="PostTreatment">PostTreatment</param>
        void UpdatePostTreatment(PostTreatment postTreatment);

        /// <summary>
        /// Gets a PostTreatment
        /// </summary>
        /// <param name="PostTreatmentId">PostTreatment identifier</param>
        /// <returns>A PostTreatment</returns>
        PostTreatment GetPostTreatmentById(int PostTreatmentId);


        /// <summary>
        /// Gets a PostTreatment
        /// </summary>
        /// <param name="TreatmentRecordId">TreatmentRecord identifier</param>
        /// <returns>A PostTreatment</returns>
        PostTreatment GetPostTreatmentByTreatmentRecordId(int TreatmentRecordId);

        /// <summary>
        /// Gets all PostTreatment
        /// </summary>

        /// <returns>A PostTreatment</returns>
        IList<PostTreatment> GetAllPostTreatment();



        #endregion


     

        #region NoteAndReport

        /// <summary>
        /// Insert a NoteAndReport
        /// </summary>
        /// <param name="NoteAndReport">NoteAndReport</param>
        void InsertNoteAndReport(NoteAndReportMaster noteAndReport);

        /// <summary>
        /// Updates the NoteAndReport
        /// </summary>
        /// <param name="NoteAndReport">NoteAndReport</param>
        void UpdateNoteAndReport(NoteAndReportMaster noteAndReport);

        /// <summary>
        /// Gets a NoteAndReport
        /// </summary>
        /// <param name="NoteAndReportId">NoteAndReport identifier</param>
        /// <returns>A NoteAndReport</returns>
        NoteAndReportMaster GetNoteAndReportById(int NoteAndReportId);


        /// <summary>
        /// Gets a NoteAndReport
        /// </summary>
        /// <param name="NoteAndReportId">NoteAndReport identifier</param>
        /// <returns>A NoteAndReport</returns>
        NoteAndReportMaster GetNoteAndReportByTreatmentRecordId(int TreatmentRecordId);

        /// <summary>
        /// Gets all NoteAndReport
        /// </summary>

        /// <returns>A NoteAndReport</returns>
        IList<NoteAndReportMaster> GetAllNoteAndReport();
        #endregion



    }
}
