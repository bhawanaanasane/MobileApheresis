using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Appointment
{
    public class AppointmentDatesModel
    {
        public int ID { get; set; }

        public int AppointmentMasterId { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
