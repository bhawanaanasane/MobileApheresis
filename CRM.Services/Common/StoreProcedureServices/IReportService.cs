using CRM.Core.Domain.Common;
using CRM.Core.Domain.CompanyProfiles;
using CRM.Core.ViewModels.CompanyProfiles;
using CRM.Core.ViewModels.Equipments;
using CRM.Core.ViewModels.Report;
using CRM.Core.ViewModels.TreatmentRecord;
using System;
using System.Collections.Generic;

namespace CRM.Services.Common.StoreProcedureServices
{
    public partial interface IReportService
    {
        #region CompanyProfile

        CompanyProfilesPaginationModel GetAllCompanyProfiles(
              int page_size,
              int page_num,

              string keywords = null,
                bool IsExport = false,
                bool GetAll = false
         );



        #endregion

        #region Equipments

        EquipmentsPaginationModel GetAllEquipments(
            int page_size,
            int page_num,
            string keywords = null,
            bool IsExport = false,
            bool GetAll = false
       );
        #endregion

        #region TreatmentRecords
        //Get All treatment Record Data
        TreatmentRecordsPaginationModel GetAllTreatmentRecords(
           int page_size,
           int page_num,
          bool GetAll = false,
          int TreatmentRecordStatusId = 0,
          int HospitalId = 0,
            int NurseId  = 0,
            int PatientId = 0,
            int DaignosisId  = 0,
            string StartDate = null,
            string EndDate = null
      );

        //Changes Treatment Status
        void UpdateTreatmentStatusID( int TreatmentRecordId = 0 );
        #endregion

        #region Other Lab Values
        OtherLabValuesPaginationModel GetAllOtherLabValues(
           int LabValuesId
      );
        #endregion

        #region RunValues
        RunValuesPaginationModel GetAllRunValues(
           int TreatmentRecordId
      );
        #endregion
        #region RunValues
        AllTreatmentRecordDataVM GetAllTreatmentRecordData(
           int TreatmentRecordId
      );
        #endregion

        #region Appointment

        List<AppointmentVM> GetAllAppointment(
            int page_size,
              int page_num,

              string keywords = null,
                bool IsExport = false,
                bool GetAll = false);
        #endregion

        #region AppointmentDate

        List<AppoimtmentDateVM> GetAppointmentDates(int AppointmentDateId);
        #endregion
        #region Dashboard
        DashboardData GetDashboardDetails(string StartDate = null, string EndDate = null, string StartDateForCalendar = null, string EndDateForCalendar = null,string TodaysDate = null);
        DashboardData GetDastboard(string StartDate = null, string EndDate = null, string StartDateForCalendar = null, string EndDateForCalendar = null);

   
        List<CalendarData> GetDastboardCalendarData(string StartDateForCalendar = null, string EndDateForCalendar = null);


        #endregion

        #region report
        TreatmentReportPaginationModel GetTreatmentRecordReport(
            int page_size,
            int page_num,
            bool GetAll = false,
            int ProcedureId = 0,
            int HospitalId = 0,
            int PatientId = 0,
            int NurseId = 0,
            int DiagnosisId = 0,
            string ReportType = null,
            string StartDate = null,
            string EndDate = null
            );

        #endregion













    }
}
