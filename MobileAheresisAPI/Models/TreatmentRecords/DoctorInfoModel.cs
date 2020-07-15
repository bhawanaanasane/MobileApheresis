using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class DoctorInfoModel
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }

        public bool? OrdersReviewed { get; set; }

        public string Room { get; set; }
        public bool? OutPatient { get; set; }

        public string Comments { get; set; }

        public int EducatioPreTreatmentId { get; set; }

        public int? TreatmentRecordMasterId { get; set; }
        public bool MarkComplete { get; set; }
    }
    public enum EducatioPreTreatmentStatus
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
