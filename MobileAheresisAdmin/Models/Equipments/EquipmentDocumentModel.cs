using CRM.Core.Domain.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Equipments
{
    public class EquipmentDocumentModel
    {
        public int EquipmentId { get; set; }
        public string Document { get; set; }

        public virtual EquipmentModel Equipment { get; set; }
        public int EqpDocumentId { get; set; }

        public EqpDocumentType EqpDocumentType
        {
            get
            {
                return (EqpDocumentType)EqpDocumentId;
            }
            set
            {
                EqpDocumentId = (int)value;


            }
        }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
