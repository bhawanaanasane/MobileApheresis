using CRM.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Nurses
{
    public class NurseMaster : BaseEntity
    {
        private ICollection<NurseDocuments> _nurseDocuments;

        //UserId For username and Password
        public int? UserId { get; set; }
        public virtual Customer Customer { get;set;}
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<NurseDocuments> NurseDocuments
        {
            get { return _nurseDocuments ?? (_nurseDocuments = new List<NurseDocuments>()); }
            protected set { _nurseDocuments = value; }
        }
    }
}
