using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class RunValuesVM
    {
        public int Id { get; set; }
        public TimeSpan RunTime { get; set; }

        public int ACFlowRate { get; set; }

        public int ACFlowVol { get; set; }

        public int IntelFlowRate { get; set; }

        public int IntelFlowVol { get; set; }
        public int PlasmaFlowRate { get; set; }

        public int PlasmaFlowVol { get; set; }
        public int CollectFlowRate { get; set; }

        public int CollectFlowVol { get; set; }
        public decimal WarmerTemp { get; set; }

        public int ReplaceFluidId { get; set; }

       

        public string LotNo { get; set; }

        public string BP { get; set; }

        public int T { get; set; }
        public int P { get; set; }
        public int R { get; set; }

        public int? TreatmentRecordMasterId { get; set; }

       
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
