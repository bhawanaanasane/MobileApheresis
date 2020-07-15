using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Printers
{
    public class Printer : BaseEntity
    {
        public string PrinterId { get; set; }
        public int PrinterCloudSettingId { get; set; }
        public virtual PrinterCloudSetting PrinterCloudSetting { get; set; }

    }
}
