using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.Report
{
  public  class TreatmentReportPaginationModel
    {
        public TreatmentReportPaginationModel()
        {
            List = new List<TreatmentReportModel>();
            PatientList= new List<TreatmentByPatientReport>();
            NurseList = new List<TreatmentByNurseReport>();
            DiagnosisList = new List<TreatmentByDiagnosisReport>();
            DateList = new List<TreatmentByDateReport>();
            ProcedureList = new List<TreatmentByProcedureReport>();
            HospitalList = new List<TreatmentByHospitalReport>(); 
        }
        public List<TreatmentReportModel> List { get; set; }
        public List<TreatmentByPatientReport> PatientList { get; set; }
        public List<TreatmentByNurseReport> NurseList { get; set; }
        public List<TreatmentByHospitalReport> HospitalList { get; set; }
        public List<TreatmentByDiagnosisReport> DiagnosisList { get; set; }
        public List<TreatmentByDateReport> DateList { get; set; }
        public List<TreatmentByProcedureReport> ProcedureList { get; set; }

       

        public int TotalRecords { get; set; }
        public string ReportType { get; set; }
        public int ProcedureId { get; set; }
        public int HospitalId { get; set; }
        public int PatientId { get; set; }
        public int NurseId { get; set; }
        public int DiagnosisId { get; set; }
		
		public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
