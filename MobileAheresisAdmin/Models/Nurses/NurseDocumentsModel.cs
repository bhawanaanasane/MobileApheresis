using CRM.Core.Domain.Nurses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Nurses
{
    public class NurseDocumentsModel :BaseEntityModel
    {

        public int NurseMasterId { get; set; }
        public string Document { get; set; }

        public virtual NurseMaster NurseMaster { get; set; }

        public int DocumentTypeId { get; set; }

        public DocumentType DocumentType
        {
            get
            {
                return (DocumentType)DocumentTypeId;
            }
            set
            {
                DocumentTypeId = (int)value;


            }
        }
    }
}
