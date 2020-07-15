using CRM.Core.Domain.CompanyProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.CompanyProfiles
{
  public partial  interface ICompanyProfileService
    {
        #region General

        /// <summary>
        /// Insert a General
        /// </summary>
        /// <param name="General">General</param>
        CompanyProfile GetCompanyProfileById(int Id);

        /// Insert a General
        /// </summary>
        /// <param name="General">General</param>
        CompanyProfile GetAllCompanyProfile();

        /// <summary>
        /// Insert a General
        /// </summary>
        /// <param name="General">General</param>
        void InsertCompanyProfile(CompanyProfile companyProfile);


        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="General">General</param>
        void UpdateCompanyProfile(CompanyProfile general);
        /// <summary>
        /// Insert a General
        /// </summary>
        /// <param name="General">General</param>
        void DeleteCompanyProfile(CompanyProfile companyProfile);
        #endregion

        #region Poliecies And Procedures
        /// <summary>
        /// Get all Poliecies And Procedures
        /// </summary>
        /// <param name="Poliecies And Procedures">Poliecies And Procedures</param>
        IList<PolicyAndProcedure> GetAllPolicyAndProcedure();
        #endregion
        //13/09/19 aakansha
        #region DownloadHistory
        /// <summary>
        /// Insert a DownloadHistory
        /// </summary>
        /// <param name="DownloadHistory">DownloadHistory</param>
        DownloadHistory GetDownloadHistoryById(int Id);
        IList<DownloadHistory> GetAllDownloadHistory();

        /// <summary>
        /// Insert a DownloadHistory
        /// </summary>
        /// <param name="DownloadHistory">DownloadHistory</param>
        void InsertDownloadHistory(DownloadHistory DownloadHistory);

        #endregion
    }
}
