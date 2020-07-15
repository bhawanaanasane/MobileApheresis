using CRM.Core.Domain.TreatmentRecords;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Treatments
{
    //20/09/19 aakansha
    public class TreatmentRecordModel:BaseEntityModel

    {
        public TreatmentRecordModel() {
            //this.AvailablePatients = new List<SelectListItem>();
            //this.AvailableStates = new List<SelectListItem>();
            this.AvailableHospitals = new List<SelectListItem>();
        }
        public bool Deleted { get; set; }
    
        public DateTime CreatedOn { get; set; }
                public DateTime LastUpdated { get; set; }
        public string TreatmentRecordNo { get; set; }
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
        public DateTime AppointmentDate { get; set; }
       // public DateTime DateOfBirth { get; set; }
        //public int? PatientMasterId { get; set; }
        //public virtual PatientmasterModel PatientMaster { get; set; }

        //public IList<SelectListItem> AvailablePatients { get; set; }
        //public int StateProvinceId { get; set; }
        //public IList<SelectListItem> AvailableStates { get; set; }
        public int HospitalId { get; set; }

        public IList<SelectListItem> AvailableHospitals { get; set; }

    }
}
