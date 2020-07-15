using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class OtherLabValuesVM
    {
        public int? LabValuesId { get; set; }
        public int Id { get; set; }
        public string ContentName { get; set; }

        public decimal ContentValue { get; set; }
    }
}
