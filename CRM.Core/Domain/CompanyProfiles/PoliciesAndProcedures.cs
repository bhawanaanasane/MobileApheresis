using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.CompanyProfiles
{
    public class PolicyAndProcedure : BaseEntity
    {
        public int CompanyProfileId { get; set; }
        public string Text { get; set; }
        public bool IsPolicy { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
    }
}
