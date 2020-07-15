using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Treatment
{
    public class DiagnosisModel
    {
        public string DiagnosisName { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
