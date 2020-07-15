using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class PreTreatmentAssessmentModel
    {
        public int Id { get; set; }
        public bool IsAlert { get; set; }

        public bool IsLethargic { get; set; }
        public bool IsComatose { get; set; }

        public string OrientedX { get; set; }
        public bool IsWeakness { get; set; }

        public int? WeaknessAutoTextId { get; set; }
        public bool IsNumbness { get; set; }

        public int? NumbnessAutoTextId { get; set; }

        public int? PainAutoTextId { get; set; }

        public int? LocationAutoTextId { get; set; }
        public bool IsEasy { get; set; }
        public bool IsLabored { get; set; }
        public string OSat { get; set; }

        public bool IsNC { get; set; }
        public bool IsRoomAir { get; set; }
        public bool IsMask { get; set; }
        public bool IsVent { get; set; }
        public bool IsFiO2 { get; set; }

        public int? LungSoundsAutoTextId { get; set; }
        public int? RythmAutoTextId { get; set; }
        public bool IsEdema { get; set; }
        public int? EdemaAutoTextId { get; set; }
        public bool IsBleeding { get; set; }
        public int? BleendAutoTextId { get; set; }
        public int? SkinAutoTextId { get; set; }

        public int? TreatmentRecordMasterId { get; set; }
        

        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool MarkComplete { get; set; }
    }
}
