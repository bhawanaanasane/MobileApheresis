using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.CompanyProfiles
{
   public class AppoimtmentDateVM
    {
        public int Id { get; set; }
        public int AppointmentMasterId { get; set; }
    
        public DateTime AppointmentDate { get; set; }

    }
}
