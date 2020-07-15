using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class PostTreatmentVM
    {
        public int Id { get; set; }
        public int? TreatmentRecordId { get; set; }      
        public bool IsRinseBackComplete { get; set; }
        public bool IsPostCVCCarePerPolicy { get; set; }
        public bool IsEquipmentCleanedAndDisinfected { get; set; }
        public bool IsBiohazardWasteDisposed { get; set; }
        public bool IsSideRailsUp { get; set; }
        public bool MarkComplete { get; set; }
    }
}
