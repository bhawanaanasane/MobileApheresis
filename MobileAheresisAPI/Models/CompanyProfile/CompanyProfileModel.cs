using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.CompanyProfile
{
    public class CompanyProfileModel
    {
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Companyname { get; set; }


        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }



        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string License { get; set; }


        public int CompanyAddressId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the customer has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }             

    }
}
