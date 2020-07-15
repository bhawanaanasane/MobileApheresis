using CRM.Core.Domain.CompanyProfiles;
using CRM.Core.Domain.Hospitals;
using CRM.Core.Domain.Nurses;
using CRM.Core.Domain.TreatmentMaster;
using MobileAheresisAPI.Models.CompanyProfile;
using MobileAheresisAPI.Models.Hospital;
using MobileAheresisAPI.Models.Nurse;
using MobileAheresisAPI.Models.Treatment;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class PatientInfoDropDownMasterModel 
    {
        public PatientInfoDropDownMasterModel()
        {
            hospitalList = new List<HospitalModel>();
            DiagnosisList = new List<DiagnosisModel>();

            ProceduresList = new List<PoliciesAndProceduresModel>();

            NurseList = new List<NurseModel>();
            PatientList = new List<PatientModel>();
           
        }

        public IList<PatientModel> PatientList { get; set; }

        public IList<HospitalModel> hospitalList { get; set; }

        public IList<DiagnosisModel> DiagnosisList { get; set; }
        public IList<PoliciesAndProceduresModel> ProceduresList { get; set; }

        public IList<NurseModel> NurseList { get; set; }
      
    }
}
