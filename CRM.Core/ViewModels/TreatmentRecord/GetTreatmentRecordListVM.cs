using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class GetTreatmentRecordListVM
    {
        public GetTreatmentRecordListVM()
        {
            this.Page = 1;
        }
        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        public int TreatmentStatusId { get; set; }


    }
}
