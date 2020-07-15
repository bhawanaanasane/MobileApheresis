using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.Equipments
{
   public  class EquipmentDocuments :BaseEntity
    {
        public int EquipmentId { get; set; }
        public string Document { get; set; }

        public virtual Equipment Equipment { get; set; }
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

    public enum EqpDocumentType
    {
        [Description("Preventative Maintenance")]
        PreventativeMaintenance = 10,
        [Description("Warranty Info")]
        WarrantyInfo = 20,
        
    }
}
