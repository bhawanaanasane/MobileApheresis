using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Nurse
{
    public class NurseModel
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
