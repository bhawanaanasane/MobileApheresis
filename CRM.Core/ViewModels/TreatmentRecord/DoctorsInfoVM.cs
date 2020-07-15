using CRM.Core.Domain.TreatmentRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
  public class DoctorsInfoVM
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }

        public bool OrdersReviewed { get; set; }

        public string Room { get; set; }
        public bool OutPatient { get; set; }

        public string Comments { get; set; }

        public int EducatioPreTreatmentId { get; set; }
     

        public int? TreatmentRecordMasterId { get; set; }
        public bool MarkComplete { get; set; }
        public EducatioPreTreatment EducatioPreTreatment
        {
            get
            {
                return (EducatioPreTreatment)EducatioPreTreatmentId;
            }
            set
            {
                EducatioPreTreatmentId = (int)value;


            }
        }


    }
}
