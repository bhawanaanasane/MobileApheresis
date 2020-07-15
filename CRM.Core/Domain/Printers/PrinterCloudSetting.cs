using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Printers
{
    public class PrinterCloudSetting:BaseEntity
    {
        private ICollection<Printer> _printers;
        /// <summary>
        /// Gets or sets the ServiceName
        /// </summary>
        public string ServiceName  { get; set; }

        public string ServiceAccountEmail { get; set; }

        public string KeyFilePath { get; set; }

        public string KeyFileSecreat { get; set; }


        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the collection of ProductManufacturer
        /// </summary>
        public virtual ICollection<Printer> Printers
        {
            get { return _printers ?? (_printers = new List<Printer>()); }
            protected set { _printers = value; }
        }
    }
}
