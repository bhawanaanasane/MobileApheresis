using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentMaster
{
    public class Diagnosis :BaseEntity
    {
        public string DiagnosisName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
