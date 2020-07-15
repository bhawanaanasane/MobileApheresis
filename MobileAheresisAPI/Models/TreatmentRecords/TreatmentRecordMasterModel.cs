using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class TreatmentRecordMasterModel
    {
        public int Id { get; set; }
        public TreatmentRecordMasterModel()
        {
            this.PatientInfoData = new PatientInfoModel();
            this.DoctorData = new DoctorInfoModel();
            this.MachineData = new MachineModel();

            this.PreTreatmentCheckData = new PreTreatmentCheckModel();
            this.LabValueData = new LabValuesModel();

            this.SuppliesData = new SuppliesAndAccessModel();

            this.PreTreatmentAssessmentData = new PreTreatmentAssessmentModel();

            this.RunValues = new RunValuesListModel();

            this.FinalValuesData = new FinalValuesAndAccessPostAssessmentModel();

            this.PostTreatmentData = new PostTreatmentModel();
            this.NoteAndReportData = new NoteAndReportModel();
        }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public int TreatmentStatusId { get; set; }
        //19/09/19 aakansha
        public string TreatmentRecordNo { get; set; }
        //Bhawana (07/10/2019)
        public int? AppointmentDateId { get; set; }
        //public string PateintName { get; set; }
        //public string MR { get; set; }
        //public string NurseName { get; set; }
        //public string HospitalName { get; set; }
        //public string ContactPerson { get; set; }
        //public string DoctorName { get; set; }

        //public string Room { get; set; }

        //public string EquipSerial { get; set; }
        //public string EquipmentName { get; set; }

        //public string PMDate { get; set; }


        public int TotalRecords { get; set; }


        public PatientInfoModel PatientInfoData { get; set; }
        public DoctorInfoModel DoctorData { get; set; }
        public MachineModel MachineData { get; set; }

        public PreTreatmentCheckModel PreTreatmentCheckData { get; set; }
        public LabValuesModel LabValueData { get; set; }

        public SuppliesAndAccessModel SuppliesData { get; set; }

        public PreTreatmentAssessmentModel PreTreatmentAssessmentData { get; set; }

        public RunValuesListModel RunValues { get; set; }


        public FinalValuesAndAccessPostAssessmentModel FinalValuesData { get; set; }

        public PostTreatmentModel PostTreatmentData { get; set; }

        public NoteAndReportModel NoteAndReportData { get; set; }


    }
    public enum TreatmentRecordStatus
    {
        [Description("Started")]
        Started = 10,
        [Description("InProcess")]
        InProcess = 20,
        [Description("Completed")]
        Completed = 30



    }
}
