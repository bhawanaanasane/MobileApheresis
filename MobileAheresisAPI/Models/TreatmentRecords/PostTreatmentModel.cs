using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class PostTreatmentModel
    {
        public PostTreatmentModel() {
            this.MedicationList = new List<MedicationModel>();
        }
        public int Id { get; set; }
        public int? TreatmentRecordId { get; set; }
        public IList<MedicationModel> MedicationList { get; set; }
        public bool? IsRinseBackComplete { get; set; }
        public bool IsPostCVCCarePerPolicy { get; set; }
        public bool IsEquipmentCleanedAndDisinfected { get; set; }
        public bool IsBiohazardWasteDisposed { get; set; }
        public bool IsSideRailsUp { get; set; }
        public bool MarkComplete { get; set; }


    }
}
