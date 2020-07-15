using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Models.Hospitals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Appointment
{
    public class AppointmentModel :BaseEntityModel
    {
        public AppointmentModel() {
            this.AvailableHospitals = new List<SelectListItem>();
            this._appointmentDates = new List<AppointmentDatesModel>();

        }
       

        public IList<AppointmentDatesModel> _appointmentDates;


        public string PatientName { get; set; }

        public string MR { get; set; }

        public int? HospitalId { get; set; }

        public virtual HospitalModel HospitalMaster { get; set; }
        public DateTime AppointmentDate { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public IList<SelectListItem> AvailableHospitals { get; set; }
    }
}
