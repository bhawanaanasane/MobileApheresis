using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class MachineDropDown
    {
        public MachineDropDown() { this.equipmentList = new List<EquipmentModel>(); }
        public IList<EquipmentModel> equipmentList { get; set; }
    }
}
