using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Treatments
{
    public class AutoTextModel :BaseEntityModel
    {
        public AutoTextModel()
        {
            this.AvailableComments = new List<SelectListItem>();
        }
        public string AutoTextName { get; set; }

        public int CommentTypeId { get; set; }

        public string CommentTypeName { get; set; }

        public  CommentTypeModel CommentType { get; set; }

        public IList<SelectListItem> AvailableComments { get; set; }

        public string Comment { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
