using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
  public class DoctorInfo :BaseEntity
    {
        public string DoctorName { get; set; }

       public bool? OrdersReviewed { get; set; }

        public string Room { get; set; }
        public bool? OutPatient { get; set; }

        public string Comments { get; set; }

        public int EducatioPreTreatmentId { get; set; }

        public EducatioPreTreatment EducatioPreTreatment
        {
            get
            {
                return (EducatioPreTreatment)EducatioPreTreatmentId;
            }
            set
            {
                EducatioPreTreatmentId = (int)value;


            }
        }

        public int? TreatmentRecordMasterId { get; set; }

        public virtual TreatmentRecordMaster TreatmentRecord { get; set; }
        public bool MarkComplete { get; set; }
    }
    public enum EducatioPreTreatment
    {
        [Description("Transfusion reactions")]
        Transfusionreactions = 10,
        [Description("Citrate Symptoms")]
        CitrateSymptoms = 20,
        [Description("Procedure Related")]
        ProcedureRelated = 30,
        [Description("Other")]
        Other = 40
    }
}
