using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.Core.Domain.TreatmentRecords
{
    public partial class RunValues : BaseEntity
    {
        public TimeSpan? RunTime { get; set; }

        public int? ACFlowRate { get; set; }

        public int? ACFlowVol { get; set; }

        public int? IntelFlowRate { get; set; }

        public int? IntelFlowVol { get; set; }
        public int? PlasmaFlowRate { get; set; }

        public int? PlasmaFlowVol { get; set; }
        public int? CollectFlowRate { get; set; }

        public int? CollectFlowVol { get; set; }
        public decimal? WarmerTemp { get; set; }

        public int? ReplaceFluidId { get; set; }

        public virtual ReplaceFluid ReplaceFluid
        {
            get { return (ReplaceFluid)ReplaceFluidId; }
            set { ReplaceFluidId = (int)value; }
        }

        public string LotNo { get; set; }

        public string BP { get; set; }

        public int? T { get; set; }
        public int? P { get; set; }
        public int? R { get; set; }

        public int? TreatmentRecordMasterId { get; set; }

        public virtual TreatmentRecordMaster TreatmentRecord { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public bool MarkComplete { get; set; }
    }
    public enum ReplaceFluid
    {
        [Description("Alb5%")]
        Alb5 = 10,
        [Description("FFPot")]
        FFPot = 20,
        [Description("RBCA")]
        RBCA = 30
    }
}
