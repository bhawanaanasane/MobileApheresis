using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.CompanyProfiles
{
    public class CompanyDocument : BaseEntity
    {
        public int CompanyProfileId { get; set; }
        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }

    }
}
