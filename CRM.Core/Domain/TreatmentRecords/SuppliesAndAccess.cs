﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
    public class SuppliesAndAccess : BaseEntity
    {

       
        public int? TreatmentRecordId { get; set; }

        public virtual TreatmentRecordMaster TreatmentRecord { get; set; }
        public string ACDLot { get; set; }
        public DateTime? ACDLotExpDate { get; set; }
        public string NSPrimeLot { get; set; }
        public DateTime? NSPrimeLotExpDate { get; set; }
        public string Rate { get; set; }

        public bool? BloodWarmer { get; set; }
        public bool? ACEInhibitors { get; set; }
        public bool? MedsReviewed { get; set; }


        public decimal? TEMP { get; set; }

        public string Serial { get; set; }

       
        public DateTime? LastDoseDate { get; set; }

        public DateTime? DateDC { get; set; }

        public bool CVC { get; set; }

        public string Type { get; set; }
        public bool Peripheral { get; set; }
        public bool Vortex { get; set; }

        public string Locations { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public bool MarkComplete { get; set; }

    }
}