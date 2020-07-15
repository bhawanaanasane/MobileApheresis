using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentMaster
{
   public class AutoText :BaseEntity
    {

        public string AutoTextName { get; set; }

        public int CommentTypeId { get; set; }

        public virtual CommentType CommentType { get; set; }

        public string Comment { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

    }
}
