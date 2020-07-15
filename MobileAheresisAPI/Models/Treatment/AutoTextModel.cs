using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Treatment
{
    public class AutoTextModel
    {
        public int Id { get; set; }
        public string AutoTextName { get; set; }

        public int CommentTypeId { get; set; }
        public string CommentTypeName { get; set; }



        public string Comment { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
