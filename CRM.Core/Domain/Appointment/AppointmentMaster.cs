using CRM.Core.Domain.Hospitals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.Appointment
{
    public class AppointmentMaster : BaseEntity
    {
        public ICollection<AppointmentDates> _appointmentDates;

        public string PatientName { get; set; }

        public string MR { get; set; }

        public int? HospitalId { get; set; }
       
        public virtual HospitalMaster HospitalMaster {get;set;}
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<AppointmentDates> AppointmentDates
        {
            get { return _appointmentDates ?? (_appointmentDates = new List<AppointmentDates>()); }
            protected set { _appointmentDates = value; }
        }
    }
    public enum AppointmentStatus
    {
        [Description("Created")]
        Created = 10,
        [Description("Completed")]
        Completed = 20,
        [Description("Cancelled")]
        Cancelled = 30,
        [Description("Treatment Started")]
        TreatmentStarted = 40,
    }
}
