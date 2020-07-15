using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
  public  class LabValuesVM
    {
        public int Id { get; set; }
        public int? TreatmentRecordMasterId { get; set; }

        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? EBV { get; set; }
        public decimal? EPV { get; set; }
        public decimal? ECV10 { get; set; }
        public decimal? ECV15 { get; set; }
        public decimal? HGB { get; set; }
        public decimal? HTC { get; set; }
        public decimal? WBC { get; set; }
        public decimal? PLT { get; set; }

       
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public bool MarkComplete { get; set; }
    }
}
