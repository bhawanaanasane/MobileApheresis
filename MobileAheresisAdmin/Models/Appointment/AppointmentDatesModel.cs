using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Appointment
{
    public class AppointmentDatesModel:BaseEntityModel
    {
        public int AppointmentMasterId { get; set; }

        public virtual AppointmentModel AppointmentMaster { get; set; }

        public string CancelDate { get; set; }
        public DateTime AppointmentDates { get; set; }
        
    }
}
