using CRM.Core.Domain.CompanyProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.Equipments
{
    public class EquipmentsPaginationModel
    {
        public EquipmentsPaginationModel()
        {
            List = new List<EquipmentsVM>();
           
        }
        public List<EquipmentsVM> List { get; set; }
    
        public int TotalRecords { get; set; }
    }
}
