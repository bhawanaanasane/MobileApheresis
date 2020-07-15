using MobileAheresisAPI.Models.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Appointment
{
    public class AppointmentModel { 
        public int ID { get; set; }
               
        public List<AppointmentDatesModel> _appointmentDates;

        public string PatientName { get; set; }

        public string MR { get; set; }

        public int? HospitalId { get; set; }

        public virtual HospitalModel HospitalMaster { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
