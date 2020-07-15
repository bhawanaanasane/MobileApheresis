using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Security
{
    public partial class PermissionRecordModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string SystemName { get; set; }
    }
}
