using System;
using System.Collections.Generic;
using System.Text;
using static CRM.Core.Infrastructure.Extensions;

namespace CRM.Core.ViewModels.Report
{
   public class TreatmentByPatientReport
    {

        public DateTime Date { get; set; }

        public string Hospital { get; set; }

        public string NurseFirstName { get; set; }

        public string NurseLastName { get; set; }

        [EpplusIgnore]
        public string PatientName { get; set; }

        public string procedure { get; set; }
        [EpplusIgnore]
        public string MR { get; set; }

        [EpplusIgnore]
        public string Diagnosis { get; set; }


        [EpplusIgnore]
        public int TotalRecords { get; set; }

       
      
 
       


   























    }
}
