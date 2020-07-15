using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class MachineMasterVM
    {
        public int Id { get; set; }
        public int? TreatmentRecordMasterId { get; set; }

    
        public int? EquipmentId { get; set; }

        public string EquipSerial { get; set; }

        public int? KitTypeId { get; set; }    

        public string KitTypeSerial { get; set; }

        public DateTime PMDate { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime SafetyChkDate { get; set; }

        public bool MachineClean { get; set; }
        public bool AlarmCheck { get; set; }

        public string CorrectiveAction { get; set; }

        public bool PrimeSuccess { get; set; }
        public bool CleanedTrackDoors { get; set; }
        public bool CleanedSensors { get; set; }
        public bool CleanedFrontDoorSensors { get; set; }
        public bool CleanedPressurePODSSeals { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public string EquipmentName { get; set; }

        public bool MarkComplete { get; set; }
    }
}
