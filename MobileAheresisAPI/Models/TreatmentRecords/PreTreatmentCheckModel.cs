using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class PreTreatmentCheckModel
    {
       public int Id { get; set; }

        public bool InformedConsent { get; set; }
        public bool BloodConsent { get; set; }
        public int? MachinePrimeId { get; set; }

        public MachinePrimedData machinePrimedData
        {
            get
            {
                return (MachinePrimedData)MachinePrimeId;
            }
            set
            {
                MachinePrimeId = (int)value;
            }
        }
        public bool AlarmTest { get; set; }
        public bool UniversalPrecautions { get; set; }
        public int? TreatmentRecordMasterId { get; set; }
        public bool MarkComplete { get; set; }

    }
    public enum MachinePrimedData
    {
        [Description("Select")]
        Select = 0,
        [Description("NS")]
        NS = 10,
        [Description("RBC")]
        RBC = 20,
        [Description("ALB")]
        ALB = 30
    }
}
