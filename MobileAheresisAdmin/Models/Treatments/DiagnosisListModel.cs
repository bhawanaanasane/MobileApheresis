using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Treatments
{
    public class DiagnosisListModel :BaseEntityModel
    {
        public DiagnosisListModel()
        {
            this.diagnosisList = new List<DiagnosisModel>();
        }

        public IList<DiagnosisModel> diagnosisList { get; set; }
    }
}
