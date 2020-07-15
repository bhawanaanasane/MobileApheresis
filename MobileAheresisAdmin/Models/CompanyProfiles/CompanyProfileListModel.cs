using CRM.Core.ViewModels.CompanyProfiles;
using MobileAheresisAdmin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.CompanyProfiles
{
    //16/09/19 aakansha
    public class CompanyProfileListModel :BaseEntityModel
    {
        public CompanyProfileListModel() {
            
               
            
        }

        public PagedResult<CompanyProfileVM> List { get; set; }

       
       
     



    }
}
