using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Report
{
    public class TreatmentReport:BaseEntity
    {
        public string Date { get; set; }
        public string Hospital{ get; set; }
        public string NurseName { get; set; }
        public string procedure { get; set; }
        public string MR { get; set; }
        public string Diagnosis { get; set; }
        public string CleanedTrackDoors { get; set; }
        public string CleanedSensors { get; set; }
        public string CleanedFrontDoorSensors { get; set; }
        public string CleanedPressurePODSSeals { get; set; }
        public string DidMachinePrimeSuccessfully { get; set; }
        public string TreatmentCompletedWithoutIncident { get; set; }




    }
}
