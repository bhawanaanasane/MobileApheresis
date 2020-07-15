using System;
using System.Collections.Generic;
using System.Text;
using static CRM.Core.Infrastructure.Extensions;

namespace CRM.Core.ViewModels.Report
{
   public class TreatmentReportModel
    {
      
        public DateTime Date { get; set; }
       
        public string Hospital { get; set; }
       
        public string NurseFirstName { get; set; }
     
        public string NurseLastName { get; set; }
       
        public virtual string PatientName { get; set; }
      
        public string procedure { get; set; }
      
        public virtual string MR { get; set; }
      
        public virtual string Diagnosis { get; set; }


 
        public  int TotalRecords { get; set; }



    }
}
