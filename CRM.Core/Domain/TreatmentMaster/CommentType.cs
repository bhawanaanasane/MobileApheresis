using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.TreatmentMaster
{
    public class CommentType :BaseEntity
    {

        public string CommentTypeName { get; set; }


        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

                                                                                                                           
    }
}
