using CRM.Core.Domain.CompanyProfiles;
using CRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CRM.Services.CompanyProfiles
{
    //13/09/19 aakansha
    public partial  class CompanyProfileService :ICompanyProfileService
    {
        #region Fields
        private IRepository<CompanyProfile> _companyProfileRepository;
        private IRepository<PolicyAndProcedure> _policyAndProcedureRepository;
        private IRepository<DownloadHistory> _downloadHistoryRepository;


        #endregion

        #region Ctor
        public CompanyProfileService(IRepository<CompanyProfile> CompanyProfileRepository,
            IRepository<PolicyAndProcedure> PolicyAndProcedureRepository,
            IRepository<DownloadHistory> DownloadHistoryRepository
            ) {
            this._companyProfileRepository = CompanyProfileRepository;
            this._policyAndProcedureRepository = PolicyAndProcedureRepository;
            this._downloadHistoryRepository = DownloadHistoryRepository;
        }


        #endregion

        #region General
        public CompanyProfile GetCompanyProfileById(int Id)
        {
            var query = from data in _companyProfileRepository.Table
                        where data.Id == Id
                        select data;
            var data1 = query.FirstOrDefault();

            return data1;
        }
        public CompanyProfile GetAllCompanyProfile()
        {
            var query = from data in _companyProfileRepository.Table
                      
                        select data;
            var data1 = query.FirstOrDefault();

            return data1;
        }

        public void InsertCompanyProfile(CompanyProfile companyProfile)
        {
            if (companyProfile == null)
                throw new ArgumentNullException(nameof(companyProfile));

            _companyProfileRepository.Insert(companyProfile);
        }

        public void UpdateCompanyProfile(CompanyProfile companyProfile)
        {
            if (companyProfile == null)
                throw new ArgumentNullException(nameof(companyProfile));

            _companyProfileRepository.Update(companyProfile);
        }

        /// <summary>
        /// Insert a General
        /// </summary>
        /// <param name="General">General</param>
        public void DeleteCompanyProfile(CompanyProfile companyProfile)
        {
            if (companyProfile == null)
                throw new ArgumentNullException(nameof(companyProfile));

            companyProfile.Deleted = true;
            UpdateCompanyProfile(companyProfile);


        }


        #endregion

        #region Poliecies And Procedures
        /// <summary>
        /// Get all Poliecies And Procedures
        /// </summary>
        /// <param name="Poliecies And Procedures">Poliecies And Procedures</param>
        public IList<PolicyAndProcedure> GetAllPolicyAndProcedure() {
            var query = from p in _policyAndProcedureRepository.Table
                        select p;
            return query.ToList();
        }
        #endregion

        //13/09/19 aakansha
        #region DownloadHistory
        public DownloadHistory GetDownloadHistoryById(int Id)
        {
            var query = from data in _downloadHistoryRepository.Table
                        where data.Id == Id
                        select data;
            var data1 = query.FirstOrDefault();

            return data1;
        }

        public void InsertDownloadHistory(DownloadHistory DownloadHistory)
        {
            if (DownloadHistory == null)
                throw new ArgumentNullException(nameof(DownloadHistory));

            _downloadHistoryRepository.Insert(DownloadHistory);
        }

        public IList< DownloadHistory> GetAllDownloadHistory()
        {
            var query = from p in _downloadHistoryRepository.Table
                        select p;
            return query.ToList();
        }






        #endregion
    }
}
