using CRM.Core.ViewModels.Equipments;
using MobileAheresisAdmin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Equipments
{
    public class EquipmentListModel :BaseEntityModel
    {
        public EquipmentListModel() {  }
        public PagedResult<EquipmentsVM> List { get; set; }
    }
}
