using CRM.Core.Domain.Common;
using CRM.Core.Domain.TreatmentRecords;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Treatments
{
    //20/09/19 aakansha
    public class PatientmasterModel:BaseEntityModel

    {
        public PatientmasterModel() {
           
        }

        private ICollection<TreatmentRecordMaster> _treatmentRecordMaster;

        public string PatientName { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<TreatmentRecordMaster> TreatmentRecordMaster

        {
            get { return _treatmentRecordMaster ?? (_treatmentRecordMaster = new List<TreatmentRecordMaster>()); }
            protected set { _treatmentRecordMaster = value; }
        }

        //public DateTime DateOfBirth { get; set; }

        //public int GenderId { get; set; }

        //public virtual Gender Gender
        //{
        //    get
        //    {
        //        return (Gender)GenderId;
        //    }
        //    set
        //    {
        //        GenderId = (int)value;
        //    }
        //}

        //public int? PatientAddressId { get; set; }

        //public virtual Address PatientAddress { get; set; }
        
    }




}

