using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class PatientModel
    {
        public PatientModel() {
            this.PatientInfoData = new PatientInfoModel(); }
        public int PatientMasterId { get; set; }

        public IList<PatientInfoModel> PatientInfoList { get; set; }

        public PatientInfoModel PatientInfoData { get; set; }

        public string PatientName { get; set;}       
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        //public string MR { get; set; }

    }
}
