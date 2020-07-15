using CRM.Core.Domain.CompanyProfiles;
using CRM.Core.Domain.Hospitals;
using CRM.Core.Domain.Nurses;
using CRM.Core.Domain.TreatmentMaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
    public class PatientInfo : BaseEntity
    {
        public bool Deleted { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? PatientMasterId { get; set; }
        public virtual PatientMaster PatientMaster { get; set; }
        public string MR { get; set; }
        public int? HospitalMasterId { get; set; }
        public int ?NurseMasterId { get; set; }
        public int ProcedureId { get; set; }
        public int DiagnosisId { get; set; }
        public virtual NurseMaster NurseMaster { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual PolicyAndProcedure PolicyAndProcedure { get; set; }
        public virtual HospitalMaster HospitalMaster { get; set; }
        public int? TreatmentRecordMasterId { get; set; }
        public virtual TreatmentRecordMaster TreatmentRecord { get; set; }
        public bool MarkComplete { get; set; }
    }
}
