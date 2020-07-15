using CRM.Core.Domain.Nurses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Nurses
{
   public partial interface INurseServices
    {

        /// <summary>
        /// Insert a Nurse
        /// </summary>
        /// <param name="Nurse">Nurse</param>
        void InsertNurse(NurseMaster nurse);

        /// <summary>
        /// Updates the Nurse
        /// </summary>
        /// <param name="hospital">Nurse</param>
        void UpdateNurse(NurseMaster nurse);
        // Delete nurse
        void DeleteNurse(NurseMaster nurse);


        /// <summary>
        /// Gets a Nurse
        /// </summary>
        /// <param name="NurseId">Nurse identifier</param>
        /// <returns>A Nurse</returns>
        NurseMaster GetNurseById(int NurseId);

        /// <summary>
        /// Gets all Nurse
        /// </summary>

        /// <returns>A Nurse</returns>
        IList<NurseMaster> GetAllNurse();
    }
}
