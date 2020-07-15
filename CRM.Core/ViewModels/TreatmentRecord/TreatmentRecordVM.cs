using CRM.Core.Domain.TreatmentRecords;
using System;
using System.Collections.Generic;
using System.Text;
using static CRM.Core.Infrastructure.Extensions;

namespace CRM.Core.ViewModels.TreatmentRecord
{
  public  class TreatmentRecordVM
    { 
        [EpplusIgnore]
        public int TreatmentRecordId { get; set; }
        [EpplusIgnore]
        public bool Deleted { get; set; }
        [EpplusIgnore]
        public DateTime CreatedOn { get; set; }
        [EpplusIgnore]
        public DateTime LastUpdated { get; set; }
        [EpplusIgnore]

        public int TreatmentStatusId { get; set; }
        public TreatmentStatus TreatmentStatus
        {
            get
            {
                return (TreatmentStatus)TreatmentStatusId;
            }
            set
            {
                TreatmentStatusId = (int)value;
            }
        }

        public string TreatmentRecordNo { get; set; }

        public string PateintName { get; set; }
        public string MR { get; set; }

        public string NurseFirstName { get; set; }
        public string NurseLastName { get; set; }
        public string HospitalName { get; set; }
        public string ContactPerson { get; set; }
        public string DoctorName { get; set; }

        public string Room { get; set; }

        public string EquipSerial { get; set; }
        public string EquipmentName { get; set; }
        
        public DateTime? PMDate { get; set; }

        [EpplusIgnore]
        public int TotalRecords { get; set; }

       
        




    }

    



}

