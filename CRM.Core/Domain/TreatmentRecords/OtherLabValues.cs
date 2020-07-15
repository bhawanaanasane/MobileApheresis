using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
   public  class OtherLabValues :BaseEntity
    {
        public int? LabValuesId { get; set; }
        public virtual LabValues LabValues { get; set; }
        public string ContentName { get; set; }

        public decimal? ContentValue { get; set; }
    }
}
