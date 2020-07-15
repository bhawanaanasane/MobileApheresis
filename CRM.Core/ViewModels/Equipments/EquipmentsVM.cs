using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.Equipments
{
    public class EquipmentsVM
    {

        public int Id { get; set; }
        public string MachineName { get; set; }

        public string SerialNo { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the customer has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        public int TotalRecords { get; set; }

    }
}
