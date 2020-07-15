using CRM.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Common
{
    public partial interface IReportSettingServices
    {
        /// <summary>
        /// Get rowcount
        /// </summary>
        /// <param name="rowcount">rowcount</param>
        int GetRowCountByReportName(string reportname, int userId);

        /// <summary>
        /// Get rowcount
        /// </summary>
        /// <param name="rowcount">rowcount</param>
        ReportSetting GetReportSettingByReportName(string reportname, int userId);

        /// <summary>
        /// Get rowcount
        /// </summary>
        /// <param name="rowcount">rowcount</param>
        IList<ReportSetting> GetReportSettingList();


        /// <summary>
        /// Inserts  PAgeSize
        /// </summary>
        /// <param name="address">Address</param>
        void InsertReportSetting(ReportSetting report);

        /// <summary>
        /// Update  PageSize
        /// </summary>
        /// <param name="address">Address</param>
        void UpdateReportSetting(ReportSetting report);
    }
}
