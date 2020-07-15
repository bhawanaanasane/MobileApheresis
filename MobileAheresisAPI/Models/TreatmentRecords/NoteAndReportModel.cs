using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class NoteAndReportModel
    {
        public int Id { get; set; }
        public int? TreatmentRecordMasterId { get; set; }
     
        public string Note { get; set; }

        public string ReportGivenTo { get; set; }

        public bool? IsTreatmentCompletedWOIncident { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public bool MarkComplete { get; set; }
    }
}
