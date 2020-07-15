using MobileAheresisAdmin.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Hospitals
{
    public class HospitalModel :BaseEntityModel
    {

        public string HospitalName { get; set; }


        public string ContactPerson { get; set; }

        /// <summary>
        /// Default billing address
        /// </summary>
        public  AddressModel HospitalAddress { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
