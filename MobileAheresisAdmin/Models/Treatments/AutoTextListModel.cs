using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Treatments
{
    public class AutoTextListModel :BaseEntityModel
    {
        public AutoTextListModel() {
            this.autoTextList = new List<AutoTextModel>();
        }

        public IList<AutoTextModel> autoTextList { get; set; }
    }
}
