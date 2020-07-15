using MobileAheresisAPI.Models.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.TreatmentRecords
{
    public class PreTreatmentAssessmentMasterModel
    {

        public PreTreatmentAssessmentMasterModel()
        {
            this.WeaknessAutoTexts = new List<AutoTextModel>();
            this.NumbnessAutoTexts = new List<AutoTextModel>();
            this.PainAutoTexts = new List<AutoTextModel>();
            this.LocationAutoTexts = new List<AutoTextModel>();
            this.LungSoundsAutoTexts = new List<AutoTextModel>();
            this.RhythmAutoTexts = new List<AutoTextModel>();
            this.EdemaAutoTexts = new List<AutoTextModel>();
            this.BleedingAutoTexts = new List<AutoTextModel>();
            this.SkinAutoTexts = new List<AutoTextModel>();      
       
    }
        public IList<AutoTextModel> WeaknessAutoTexts { get; set; }

        public IList<AutoTextModel> NumbnessAutoTexts { get; set; }
        public IList<AutoTextModel> PainAutoTexts { get; set; }
        public IList<AutoTextModel> LocationAutoTexts { get; set; }
        public IList<AutoTextModel> LungSoundsAutoTexts { get; set; }
        public IList<AutoTextModel> RhythmAutoTexts { get; set; }
        public IList<AutoTextModel> EdemaAutoTexts { get; set; }
        public IList<AutoTextModel> BleedingAutoTexts { get; set; }
        public IList<AutoTextModel> SkinAutoTexts { get; set; }


    }
}
