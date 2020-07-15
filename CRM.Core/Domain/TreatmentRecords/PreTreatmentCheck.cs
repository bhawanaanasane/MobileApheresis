using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
   public class PreTreatmentCheck :BaseEntity
    {
        public bool InformedConsent { get; set; }
        public bool BloodConsent { get; set; }
        public int? MachinePrimeId { get; set; }

        public MachinePrimed machinePrimed {
            get {
                return (MachinePrimed)MachinePrimeId;
            }
            set {
                MachinePrimeId = (int)value;
            }
        }
        public bool AlarmTest { get; set; }
        public bool UniversalPrecautions { get; set; }
        public int? TreatmentRecordMasterId { get; set; }

        public virtual TreatmentRecordMaster TreatmentRecord { get; set; }

        public bool MarkComplete { get; set; }
    }
    public enum MachinePrimed {
        [Description("NS")]
        NS = 10,
        [Description("RBC")]
        RBC = 20,
        [Description("ALB")]
        ALB = 30
    }
}
