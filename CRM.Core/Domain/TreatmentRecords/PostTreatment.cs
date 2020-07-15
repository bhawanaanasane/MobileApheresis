using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
   public class PostTreatment :BaseEntity
    {
        public int? TreatmentRecordId { get; set; }

        public virtual TreatmentRecordMaster TreatmentRecord { get; set; }
        public ICollection<Medication> _medications;
        public bool? IsRinseBackComplete { get; set; }
        public bool IsPostCVCCarePerPolicy { get; set; }
        public bool IsEquipmentCleanedAndDisinfected { get; set; }
        public bool IsBiohazardWasteDisposed { get; set; }
        public bool IsSideRailsUp { get; set; }
        public bool MarkComplete { get; set; }
        public virtual ICollection<Medication> Medications
        {
            get { return _medications ?? (_medications = new List<Medication>()); }
            protected set { _medications = value; }
        }
    }
}
