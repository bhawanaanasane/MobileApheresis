using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class RunValuesListModel
    {
        public RunValuesListModel()
        {
            this.runValuesList = new List<RunValuesModel>();
        }
        public IList<RunValuesModel> runValuesList {get; set;}
        public bool MarkComplete { get; set; }

    }
}
