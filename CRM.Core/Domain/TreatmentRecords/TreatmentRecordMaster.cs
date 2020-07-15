using CRM.Core.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
  public class TreatmentRecordMaster :BaseEntity
    {

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
        //public DateTime AppointmentDate { get; set; }

        public int? AppointmentDateId { get; set; }
        public virtual AppointmentDates AppointmentDate { get; set; }

    }
    public enum TreatmentStatus
    {
        [Description("Started")]
        Started = 10,
        [Description("InProcess")]
        InProcess = 20,
        [Description("Completed")]
        Completed = 30

       

    }
}
