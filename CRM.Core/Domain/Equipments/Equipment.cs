using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Equipments
{
   public  class Equipment :BaseEntity
    {
        private ICollection<EquipmentDocuments> _equipmentDocuments;
        public string MachineName { get; set; }
        public string SerialNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<EquipmentDocuments> EquipmentDocuments
        {
            get { return _equipmentDocuments ?? (_equipmentDocuments = new List<EquipmentDocuments>()); }
            protected set { _equipmentDocuments = value; }
        }
    }
}
