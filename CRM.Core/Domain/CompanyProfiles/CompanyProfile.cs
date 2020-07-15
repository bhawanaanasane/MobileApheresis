using CRM.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.CompanyProfiles
{
    public class CompanyProfile :BaseEntity
    {
        private ICollection<PolicyAndProcedure> _policiesAndProcedures;

        private ICollection<CompanyDocument> _companyDocuments;

        /// <summary>
        /// Ctor
        /// </summary>
        public CompanyProfile()
        {
          
        }

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


        #region Navigation properties

        /// <summary>
        /// Default billing address
        /// </summary>
        public virtual Address CompanyAddress { get; set; }



        /// <summary>
        /// Gets or sets customer addresses
        /// </summary>
        public virtual ICollection<PolicyAndProcedure> PoliciesAndProcedures
        {
            get { return _policiesAndProcedures ?? (_policiesAndProcedures = new List<PolicyAndProcedure>()); }
            protected set { _policiesAndProcedures = value; }
        }

        public virtual ICollection<CompanyDocument> CompanyDocuments
        {
            get { return _companyDocuments ?? (_companyDocuments = new List<CompanyDocument>()); }
            protected set { _companyDocuments = value; }
        }
        #endregion
    }
}
