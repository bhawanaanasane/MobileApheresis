using CRM.Core.Domain.Equipments;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Equipments
{
   public partial interface IEquipmentServices
    {
        Equipment GetEquiipmentInfoById(int Id);
        void InsertEquipment(Equipment equipment);
        void Updateequipment(Equipment equipment);
            void DeleteEquipment(Equipment equipment);
        IList<Equipment> GetAllEquiipmentInfo();
    }
}
