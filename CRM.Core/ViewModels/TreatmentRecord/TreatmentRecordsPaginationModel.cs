using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class TreatmentRecordsPaginationModel
    {
        public TreatmentRecordsPaginationModel()
        {
            List = new List<TreatmentRecordVM>();

        }
        public List<TreatmentRecordVM> List { get; set; }

        public int TotalRecords { get; set; }
    }
}
