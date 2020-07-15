using CRM.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
   public  class PatientMaster :BaseEntity
    {
        private ICollection<PatientInfo> _patientInfo;
        
        public string PatientName { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }      

        public virtual ICollection<PatientInfo> PatientInfo

        {
            get { return _patientInfo ?? (_patientInfo = new List<PatientInfo>()); }
            protected set { _patientInfo = value; }
        }

        //public DateTime DateOfBirth { get; set; }

        //public int GenderId { get; set; }

        //public virtual Gender Gender
        //{
        //    get {
        //        return (Gender)GenderId;
        //    }
        //    set {
        //        GenderId = (int)value;
        //    }
        //}

        //public int? PatientAddressId { get; set; }

        //public virtual Address PatientAddress { get; set; }
        //public string MR { get; set; }
    }

    //public enum Gender
    //{
    //    [Description("Male")]
    //    Male = 10,
    //    [Description("Female")]
    //    Female = 20,
    //    [Description("Other")]
    //    Other = 30
    //}
}
