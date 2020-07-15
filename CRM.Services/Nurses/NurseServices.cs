using CRM.Core.Domain.Nurses;
using CRM.Data.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Nurses
{
  public partial  class NurseServices : INurseServices
    {
        #region  Fields

        private IRepository<NurseMaster> _nurseMasterRepository;
        #endregion

        #region  CTOR
        public NurseServices(IRepository<NurseMaster> NurseMasterRepository)
        {
            this._nurseMasterRepository = NurseMasterRepository;
        }

        #endregion


        /// <summary>
        /// Insert a Nurse
        /// </summary>
        /// <param name="Nurse">Nurse</param>
        public void InsertNurse(NurseMaster nurse)
        {
            if (nurse == null)
                throw new ArgumentNullException(nameof(nurse));

            _nurseMasterRepository.Insert(nurse);
        }

        /// <summary>
        /// Updates the Nurse
        /// </summary>
        /// <param name="Nurse">Nurse</param>
        public void UpdateNurse(NurseMaster nurse)
        {
            if (nurse == null)
                throw new ArgumentNullException(nameof(nurse));

            _nurseMasterRepository.Update(nurse);
        }


        /// <summary>
        /// Gets a Nurse
        /// </summary>
        /// <param name="NurseId">Nurse identifier</param>
        /// <returns>A Nurse</returns>
        public NurseMaster GetNurseById(int nurseId)
        {
            var query = from h in _nurseMasterRepository.Table
                        where h.Id == nurseId
                        select h;
            return query.FirstOrDefault();
        }
        //Delete nurse
        //1/10/19 aakansha
        public virtual void DeleteNurse(NurseMaster nurse)
        {
            if (nurse == null)
                throw new ArgumentNullException(nameof(nurse));

          nurse.Deleted = true;
            UpdateNurse(nurse);


        }

        /// <summary>
        /// Gets all Nurse
        /// </summary>

        /// <returns>A Nurse</returns>
        public IList<NurseMaster> GetAllNurse()
        {
            var query = from h in _nurseMasterRepository.Table
                        select h;
            return query.ToList();
        }
    }
}
