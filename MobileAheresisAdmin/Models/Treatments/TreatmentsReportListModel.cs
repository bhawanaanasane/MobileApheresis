using CRM.Core.ViewModels.Report;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Treatments
{
    public class TreatmentsReportListModel : BaseEntityModel
    {
        public TreatmentsReportListModel()
        {
            
            List = new List<TreatmentReportModel>();
            PatientList = new List<TreatmentByPatientReport>();
            HospitalList = new List<TreatmentByHospitalReport>();
            NurseList = new List<TreatmentByNurseReport>();
            DiagnosisList = new List<TreatmentByDiagnosisReport>();
            DateList = new List<TreatmentByDateReport>();
            ProcedureList = new List<TreatmentByProcedureReport>();
            this.AvailableDaignosis = new List<SelectListItem>();
            this.AvailableHospital = new List<SelectListItem>();
            this.AvailableNurse = new List<SelectListItem>();
            this.AvailablePatient = new List<SelectListItem>();
            this.AvailableProcedure = new List<SelectListItem>();

        }

        public IList<SelectListItem> AvailablePatient { get; set; }
        public IList<SelectListItem> AvailableNurse { get; set; }
        public IList<SelectListItem> AvailableHospital { get; set; }
        public IList<SelectListItem> AvailableDaignosis { get; set; }
        public IList<SelectListItem> AvailableProcedure { get; set; }
        public List<TreatmentReportModel> List { get; set; }
        public List<TreatmentByPatientReport> PatientList { get; set; }
        public List<TreatmentByHospitalReport> HospitalList { get; set; }
        public List<TreatmentByNurseReport> NurseList { get; set; }
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
