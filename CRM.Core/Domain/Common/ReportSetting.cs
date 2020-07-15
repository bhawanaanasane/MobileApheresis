using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Common
{
    public class ReportSetting : BaseEntity
    {
        //datarowCount
        public int RowCount { get; set; }

        //UserId
        public int UserId { get; set; }
        //ReportName
        public string ReportName { get; set; }



    }
}
