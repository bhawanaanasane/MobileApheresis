using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.CompanyProfile
{
    public class PoliciesAndProceduresModel
    {
        public int Id { get; set; }
        public int CompanyProfileId { get; set; }
        public string Text { get; set; }
        public bool IsPolicy { get; set; }
        public virtual CompanyProfileModel CompanyProfile { get; set; }
    }
}
