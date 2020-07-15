using CRM.Core.Domain.Common;
using CRM.Core.Domain.CompanyProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.CompanyProfiles
{
    public class CompanyProfileModel : BaseEntityModel
    {
        public List<PolicyAndProcedure> policiesAndProcedures;

        public ICollection<CompanyDocument> companyDocuments;

        /// <summary>
        /// Ctor

        /// //16/09/19 aakansha</summary>

        public CompanyProfileModel()
        {
            this.DownloadHistoryList = new List<DownloadHistoryModel>();
        }
       


        /// <summary>
        /// Gets or sets the customer GUID
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }

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

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public bool IsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string DocumentName { get; set; }


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
        //16/09/19 aakansha
        public IList<DownloadHistoryModel> DownloadHistoryList { get; set; }


        #endregion
    }
}
