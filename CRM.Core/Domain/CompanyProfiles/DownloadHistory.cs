using CRM.Core.Domain.Nurses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.CompanyProfiles
{
    //13/09/19 aakansha
    public class DownloadHistory: BaseEntity
    {
        public string DocumentFormat { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentType{ get; set; }
        public string DocumentName { get; set; }
        public DateTime DownloadDateTime { get; set; }
        public int UserId { get; set; }
        //16/09/19 aakansha
        public int ProcessTypeId { get;  set; }
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

    public enum ProcessType
    {
        [Description("Download")]
        Download = 10,
        [Description("Upload")]
        Upload = 20,

    }






}

