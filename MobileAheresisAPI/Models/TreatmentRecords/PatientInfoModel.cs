using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class PatientInfoModel
    {
        public int PatientInfoId { get; set; }
        public bool Deleted { get; set; }
        public DateTime Date { get; set; } 
        public DateTime LastUpdated { get; set; }
        public int? TreatmentRecordMasterId { get; set; }      
        public int? AppointmentDateId { get; set; }
        public int? PatientMasterId { get; set; }
        public string PatientName { get; set; }
        public string MR { get; set; }
        public int? HospitalMasterId { get; set; }
        public int? NurseMasterId { get; set; }
        public int ProcedureId { get; set; }
        public int DiagnosisId { get; set; }       
        public string HospitalName { get; set; }
        public string NurseName { get; set; }
        public string DaignosisName { get; set; }
        public string ProcedureName { get; set; }
        public string TreatmentRecordNo { get; set; }

        public bool MarkComplete { get; set; }
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
}
