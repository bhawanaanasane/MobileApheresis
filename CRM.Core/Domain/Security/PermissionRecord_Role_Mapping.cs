using CRM.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Security
{
    public class PermissionRecord_Role_Mapping : BaseEntity
    {
        public int PermissionRecordId { get; set; }
        public virtual PermissionRecord PermissionRecord { get; set; }
        public int CustomerRoleId { get; set; }
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
