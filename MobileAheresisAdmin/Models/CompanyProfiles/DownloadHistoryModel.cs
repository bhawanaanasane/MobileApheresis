using CRM.Core.Domain.CompanyProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.CompanyProfiles
{
    //13/09/19 aakansha
    public class DownloadHistoryModel :BaseEntityModel
    {
        public string DocFormat { get; set; }
        public string DocType { get; set; }
        public string DocName { get; set; }
        public DateTime DownloadDateTime { get; set; }
        public int UserId { get; set; }
        public int ProcessTypeId { get; set; }
        public ProcessType ProcessType
        {
            get
            {
                return (ProcessType)ProcessTypeId;
            }
            set
            {
                ProcessTypeId = (int)value;


            }




        }

    }
}
