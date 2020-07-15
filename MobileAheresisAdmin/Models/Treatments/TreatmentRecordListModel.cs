using CRM.Core.ViewModels.TreatmentRecord;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.TreatmentsRecord
{
    //18/09/19 aakansha
    public class TreatmentRecordListModel : BaseEntityModel
    {
        public TreatmentRecordListModel() {
            this.AvailableDaignosis = new List<SelectListItem>();
            this.AvailableHospital = new List<SelectListItem>();
            this.AvailableNurse = new List<SelectListItem>();
            this.AvailablePatient = new List<SelectListItem>();
            
        }
        public PagedResult<TreatmentRecordVM> List { get; set; }

        public int PatientId { get; set; }
        public int NurseId { get; set; }
        public int HospitalId { get; set; }
        public int DaignosisId { get; set; }
        public IList<SelectListItem> AvailablePatient { get; set; }
        public IList<SelectListItem> AvailableNurse { get; set; }
        public IList<SelectListItem> AvailableHospital { get; set; }
        public IList<SelectListItem> AvailableDaignosis { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
