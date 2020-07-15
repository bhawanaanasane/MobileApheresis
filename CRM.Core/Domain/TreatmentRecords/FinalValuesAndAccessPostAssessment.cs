using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
   public class FinalValuesAndAccessPostAssessment :BaseEntity
    {
       public int? Time { get; set; }

        public int? AC { get; set; }
        public int? Inlet { get; set; }
        public int? Plasma { get; set; }
        public int? Collet { get; set; }

        public string FluidBalance { get; set; }
        public string BP { get; set; }

        public int? T { get; set; }
        public int? P { get; set; }
        public int? R { get; set; }
        public int? TreatmentRecordId { get; set; }

        public virtual TreatmentRecordMaster TreatmentRecord { get; set; }

        public bool NewDressing { get; set; }

        public bool Reinforced { get; set; }
        public bool Intact { get; set; }

        public bool Saline { get; set; }
        public bool Heparin { get; set; }
        public bool ChlorhexidineCapApplied { get; set; }

        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public bool MarkComplete { get; set; }

    }
}
