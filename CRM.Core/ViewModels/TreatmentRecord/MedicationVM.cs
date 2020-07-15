using CRM.Core.Domain.TreatmentRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
     public class MedicationVM
    {
        
        public int? PostTreatmentId { get; set; }
        public virtual PostTreatment PostTreatment { get; set; }
        public int id { get; set; }

        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Route { get; set; }

        public string Comments { get; set; }
    }
}

