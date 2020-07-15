using System;
using System.Collections.Generic;
using System.Text;
using static CRM.Core.Infrastructure.Extensions;

namespace CRM.Core.ViewModels.Report
{
   public class TreatmentByProcedureReport
    {
        public DateTime Date { get; set; }

        public string Hospital { get; set; }
        [EpplusIgnore]
        public string NurseFirstName { get; set; }
        [EpplusIgnore]
        public string NurseLastName { get; set; }

        public virtual string PatientName { get; set; }
        [EpplusIgnore]
        public string procedure { get; set; }

        public virtual string MR { get; set; }

        public virtual string Diagnosis { get; set; }


        [EpplusIgnore]
        public int TotalRecords { get; set; }
    }
}
