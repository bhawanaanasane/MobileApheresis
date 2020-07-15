using CRM.Core.Domain.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Equipments
{
    public class EquipmentModel :BaseEntityModel
    {
        public EquipmentModel() { this.EquipmentDocuments = new List<EquipmentDocuments>(); }
        public string MachineName { get; set; }

        public string SerialNo { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public int EqpDocumentId { get; set; }

        public IList<EquipmentDocuments> EquipmentDocuments { get; set; }
    }
}
