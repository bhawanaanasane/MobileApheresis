using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class PatientVM
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime Date { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public int? PatientMasterId { get; set; }
       
        public string MR { get; set; }

        public int? HospitalMasterId { get; set; }
        public int? NurseMasterId { get; set; }
        public int ProcedureId { get; set; }
        public int DiagnosisId { get; set; }
        public string PatientName { get; set; }
        public string HospitalName { get; set; }
        //public string NurseName { get; set; }
        public string NurseFirstName { get; set; }
        public string NurseLastName { get; set; }
        public string DaignosisName { get; set; }
        public string ProcedureName { get; set; }
       
        public bool MarkComplete { get; set; }
        public int? TreatmentRecordMasterId { get; set; }
    }
}
