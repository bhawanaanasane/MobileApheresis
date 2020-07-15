using CRM.Core.Domain.Hospitals;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Hospitals
{
  public partial  interface IHospitalServices
    {

        /// <summary>
        /// Insert a hospital
        /// </summary>
        /// <param name="hospital">hospital</param>
        void InsertHospital(HospitalMaster hospital);

        // Delete hospital
        void DeleteHospital(HospitalMaster hospital);

        /// <summary>
        /// Updates the hospital
        /// </summary>
        /// <param name="hospital">hospital</param>
        void UpdateHospital(HospitalMaster hospital);

        /// <summary>
        /// Gets a Hospital
        /// </summary>
        /// <param name="hospitalId">Hospital identifier</param>
        /// <returns>A Hospital</returns>
        HospitalMaster GetHospitalById(int hospitalId);

        /// <summary>
        /// Gets all Hospital
        /// </summary>
      
        /// <returns>A Hospital</returns>
        IList<HospitalMaster> GetAllHospital();
    }
}
