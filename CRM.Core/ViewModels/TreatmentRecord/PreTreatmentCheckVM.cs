using CRM.Core.Domain.TreatmentRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
    public class PreTreatmentCheckVM
    {
        public int Id { get; set; }
        public bool InformedConsent { get; set; }
        public bool BloodConsent { get; set; }
        public int? MachinePrimeId { get; set; }
        public MachinePrimed machinePrimed
        {
            get
            {
                return (MachinePrimed)MachinePrimeId;
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
}
