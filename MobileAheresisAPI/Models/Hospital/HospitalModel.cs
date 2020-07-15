using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Hospital
{
    public class HospitalModel
    {
        public string HospitalName { get; set; }


        public string ContactPerson { get; set; }

     public int Id { get; set; }


        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
