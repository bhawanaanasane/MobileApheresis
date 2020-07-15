using CRM.Core.Domain.Common;
using CRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CRM.Services.Common
{
    public partial class ReportSettingServices :IReportSettingServices
    {
        #region Fields
        private readonly IRepository<ReportSetting> _reportSettingRepository;
        #endregion
        #region Ctor
        public ReportSettingServices(
           IRepository<ReportSetting> ReportSettingRepository
          )
        {

            this._reportSettingRepository = ReportSettingRepository;
         
        }
        #endregion
        #region Methods

        /// <summary>
        ///Get report row
        /// </summary>
        /// <param name="rowcount">RowCount</param>
        public virtual int GetRowCountByReportName(string reportname , int userId)
        {
            if (reportname == null)
                throw new ArgumentNullException(nameof(reportname));

            var query = (from data in _reportSettingRepository.Table
                        where data.ReportName == reportname && data.UserId == userId
                        select data).FirstOrDefault();
             return query.RowCount;
            //cache

        }

        /// <summary>
        ///Get report row
        /// </summary>
        /// <param name="rowcount">RowCount</param>
        public virtual ReportSetting GetReportSettingByReportName(string reportname, int userId)
        {
            if (reportname == null)
                throw new ArgumentNullException(nameof(reportname));

            var query = (from data in _reportSettingRepository.Table
                         where data.ReportName == reportname && data.UserId == userId
                         select data).FirstOrDefault();
            return query;
            //cache

        }

        public virtual IList<ReportSetting> GetReportSettingList()
        {
            var query = from data in _reportSettingRepository.Table
                         select data;
            return query.ToList();
        }


        /// <summary>
        /// Inserts an address
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void InsertReportSetting(ReportSetting report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

          _reportSettingRepository.Insert(report);


        }

        /// <summary>
        /// update pagesize
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void UpdateReportSetting(ReportSetting report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

            _reportSettingRepository.Update(report);


        }
        #endregion
    }
}
