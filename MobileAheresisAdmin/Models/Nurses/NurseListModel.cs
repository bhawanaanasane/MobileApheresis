using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Nurses
{
    public class NurseListModel :BaseEntityModel
    {
        public NurseListModel()
        {
            this.NurseList = new List<NurseModel>();
        }
         public IList<NurseModel> NurseList { get; set; }

    }
}
