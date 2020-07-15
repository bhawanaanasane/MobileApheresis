using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.Nurses
{
    public class NurseDocuments :BaseEntity
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

    public enum DocumentType
    {
        [Description("RN License")]
        RNLicense = 10,
        [Description("Competencies")]
        Competencies = 20,
        [Description("CPR/ACLS")]
        CPR_ACLS = 30,
        [Description("Training forms")]
        Trainingforms = 40
    }
}
