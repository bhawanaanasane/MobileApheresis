using CRM.Core.Domain.CompanyProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.CompanyProfiles
{
    public class CompanyProfilesPaginationModel
    {
        public CompanyProfilesPaginationModel()
        {
            List = new List<CompanyProfileVM>();
           
        }
        public List<CompanyProfileVM> List { get; set; }
    
        public int TotalRecords { get; set; }
    }
}
