using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
public class Medication:BaseEntity
    {
        public int? PostTreatmentId { get; set; }
        public virtual PostTreatment PostTreatment { get; set; }

        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Route { get; set; }

        public string Comments { get; set; }

    }
}
