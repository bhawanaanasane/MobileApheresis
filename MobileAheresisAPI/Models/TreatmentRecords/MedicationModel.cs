using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class MedicationModel
    {

        public int Id { get; set; }
        public int? PostTreatmentId { get; set; }
      

        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Route { get; set; }

        public string Comments { get; set; }
    }
}
