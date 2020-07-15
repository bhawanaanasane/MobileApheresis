using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Appointment
{
  public class AppointmentDates :BaseEntity
    {
    
        public int AppointmentMasterId { get; set; }

        public virtual AppointmentMaster AppointmentMaster { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentStatusId { get; set; }

        public virtual AppointmentStatus AppointmentStatus
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
    }
}
