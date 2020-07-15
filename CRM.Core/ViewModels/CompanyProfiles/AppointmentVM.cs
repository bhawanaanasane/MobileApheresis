using CRM.Core.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.CompanyProfiles
{
   public class AppointmentVM
    {
        public int Id { get; set; }

        public int AppointmentDateId { get; set; }
        public string PatientName { get; set; }
        public List<AppoimtmentDateVM> _appointmentDates;
        public string MR { get; set; }

        public int? HospitalId { get; set; }
     
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public int AppointmentStatusId { get; set; }
        public AppointmentStatus AppointmentStatus 
        {
            get
            {
                return (AppointmentStatus)AppointmentStatusId;
            }
            set
            {
                AppointmentStatusId = (int)value;
            }
        }
        public DateTime AppointmentDate { get; set; }

        public string HospitalName { get; set; }
        public int TotalRecords { get; set; }
    }
}
