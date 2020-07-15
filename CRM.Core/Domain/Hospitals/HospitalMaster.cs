using CRM.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Hospitals
{
  public  class HospitalMaster :BaseEntity
    {
        private ICollection<Address> _addresses;


        public string HospitalName { get; set; }


        public string ContactPerson { get; set; }

        /// <summary>
        /// Default billing address
        /// </summary>
        public virtual Address HospitalAddress { get; set; }

      
        /// <summary>
        /// Gets or sets customer addresses
        /// </summary>
        public virtual ICollection<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            protected set { _addresses = value; }
        }


        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
