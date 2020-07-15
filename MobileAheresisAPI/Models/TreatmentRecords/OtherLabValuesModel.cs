using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class OtherLabValuesModel
    {

        public int Id { get; set; }
        public int? LabValuesId { get; set; }
      
        public string ContentName { get; set; }

        public decimal? ContentValue { get; set; }
    }
}
