using CRM.Core.ViewModels.CompanyProfiles;
using CRM.Core.ViewModels.TreatmentRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Common
{
    public class DashboardData
    {
        public List<SliderValues> SliderValues { get; set; }
        public List<CalendarValues> CalendarValues { get; set; }
        public List<CalendarData> CalendarDatas { get; set; }
        public List<AppointmentVM> TodaysAppointment { get; set; }
          
    }

    public class SliderValues
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string HospitalName { get; set; }
       
    }

    public class CalendarValues
    {
        public DateTime Date { get; set; }
        public string WRReceivingLogProducts { get; set; }
    }

    public class CalendarData
    {
     
        public string start { get; set; }
        public string title { get; set; }
        public string color { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }
}
