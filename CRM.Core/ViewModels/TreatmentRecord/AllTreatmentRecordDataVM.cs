using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
    public class AllTreatmentRecordDataVM
    {
        public AllTreatmentRecordDataVM()
        {
            this.RunValuesVM = new List<RunValuesVM>();
            this.PatientVM = new PatientVM();
            this.DoctorsInfo = new DoctorsInfoVM();
            this.MachineMaster = new MachineMasterVM();
            this.PreTreatmentCheck = new PreTreatmentCheckVM();
            this.LabValues = new LabValuesVM();
            this.SuppliesVM = new SuppliesVM();
            this.PreTreatmentAssessment = new PreTreatmentAssessmentVM();
            this.FinalValuesVM = new FinalValuesVM();
            this.PostTreatmentVM = new PostTreatmentVM();
            this.NoteAndReportVM = new NoteAndReportVM();
            this.OtherLabValuesVMs = new List<OtherLabValuesVM>();
            this.medication = new List<MedicationVM>();

        }


        public PatientVM PatientVM { get; set; }
        public DoctorsInfoVM DoctorsInfo {get;set;}

        public MachineMasterVM MachineMaster { get; set; }

        public PreTreatmentCheckVM PreTreatmentCheck { get; set; }

        public LabValuesVM LabValues { get; set; }

        public SuppliesVM SuppliesVM { get; set; }
        public PreTreatmentAssessmentVM PreTreatmentAssessment { get; set; }

        public FinalValuesVM FinalValuesVM { get; set; }

        public PostTreatmentVM PostTreatmentVM { get; set;}
        public IList<RunValuesVM> RunValuesVM { get; set; }
        public IList<OtherLabValuesVM> OtherLabValuesVMs { get; set; }
       
        public IList <MedicationVM >medication { get; set; }



        public NoteAndReportVM NoteAndReportVM { get; set; }
    }
}
