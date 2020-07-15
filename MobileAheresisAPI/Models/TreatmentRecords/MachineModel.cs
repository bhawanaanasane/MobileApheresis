using CRM.Core.Domain.TreatmentRecords;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class MachineModel
    {
        public int Id { get; set; }
        public int? EquipmentId { get; set; }

        public int? TreatmentRecordMasterId { get; set; }

        public string EquipSerial { get; set; }

        public int? KitTypeId { get; set; }

        public KitTypeMaster KitTypeMaster
        {
            get
            {
                return (KitTypeMaster) KitTypeId;
            }
            set
            {
                KitTypeId = (int)value;
            }
        }


        public string KitTypeSerial { get; set; }

        public DateTime? PMDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public DateTime? SafetyChkDate { get; set; }

        public bool? MachineClean { get; set; }
        public bool? AlarmCheck { get; set; }

        public string CorrectiveAction { get; set; }

        public bool? PrimeSuccess { get; set; }
        public bool? CleanedTrackDoors { get; set; }
        public bool? CleanedSensors { get; set; }
        public bool? CleanedFrontDoorSensors{ get; set; }
        public bool? CleanedPressurePODSSeals { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public bool MarkComplete { get; set; }
        public string EquipmentName { get; set; }
    }
    public enum KitTypeMaster
    {
        [Description("Select")]
        Select = 0,
        [Description("Exchange")]
        Exchange = 10,
        [Description("IDL")]
        IDL = 20,

    }
}
