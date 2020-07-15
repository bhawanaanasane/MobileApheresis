using CRM.Core.Domain.Hospitals;
using CRM.Data.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Hospitals
{
  public partial  class HospitalServices :IHospitalServices
    {
        #region  Fields

        private IRepository<HospitalMaster> _hospitalMasterRepository;
        #endregion

        #region  CTOR
        public HospitalServices(IRepository<HospitalMaster> HospitalMasterRepository) {
            this._hospitalMasterRepository = HospitalMasterRepository;
        }

        #endregion


        /// <summary>
        /// Insert a hospital
        /// </summary>
        /// <param name="hospital">hospital</param>
        public void InsertHospital(HospitalMaster hospital)
        {
            if (hospital == null)
                throw new ArgumentNullException(nameof(hospital));

            _hospitalMasterRepository.Insert(hospital);
        }
        //Delete Hospital
        public virtual void DeleteHospital(HospitalMaster hospital)
        {
            if (hospital == null)
                throw new ArgumentNullException(nameof(hospital));

            hospital.Deleted = true;
            UpdateHospital(hospital);


        }

        /// <summary>
        /// Updates the hospital
        /// </summary>
        /// <param name="hospital">hospital</param>
        public  void UpdateHospital(HospitalMaster hospital)
        {
            if (hospital == null)
                throw new ArgumentNullException(nameof(hospital));

            _hospitalMasterRepository.Update(hospital);
        }


        /// <summary>
        /// Gets a Hospital
        /// </summary>
        /// <param name="hospitalId">Hospital identifier</param>
        /// <returns>A Hospital</returns>
        public HospitalMaster GetHospitalById(int hospitalId)
        {
            var query = from h in _hospitalMasterRepository.Table
                        where h.Id == hospitalId
                        select h;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all Hospital
        /// </summary>

        /// <returns>A Hospital</returns>
        public IList<HospitalMaster> GetAllHospital()
         {
            var query = from h in _hospitalMasterRepository.Table
                        select h;
            return query.ToList();
        }
    }
}
