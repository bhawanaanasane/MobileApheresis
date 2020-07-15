using CRM.Core.ViewModels.CompanyProfiles;
using MobileAheresisAdmin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Appointment
{
    public class AppointmentListModel
    {
        public PagedResult<AppointmentVM> List { get; set; }

    }
}
