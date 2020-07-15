using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Hospitals
{
    public class HospitalListModel :BaseEntityModel
    {
        public HospitalListModel() {
            this.hospitalList = new List<HospitalModel>();
        }
        public IList<HospitalModel> hospitalList { get; set; }

    }
}
