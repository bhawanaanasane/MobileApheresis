using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Appointment
{
    public class GetAppointmentPaginationVM
    {
        public GetAppointmentPaginationVM()
        {
            this.Page = 1;
        }
        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        public string Keyword { get; set; }
    }
}
