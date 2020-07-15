using CRM.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Core.Domain.Customers
{

    /// <summary>
    /// Represents a customer role
    /// </summary>
    public partial class CustomerRole : BaseEntity
    {
        private ICollection<PermissionRecord_Role_Mapping> _PermissionRecord_Role_Mapping;
        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>
        public string Description { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether the customer role is marked as free shippping
        ///// </summary>
        //public bool FreeShipping { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is active
        /// </summary>
        public bool Active { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether the customer role is system
        ///// </summary>
        //public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string SystemName { get; set; }


        ///// <summary>
        ///// Gets or sets a value indicating whether the customer role is marked as tax exempt
        ///// </summary>
        //public bool TaxExempt { get; set; }

        ///// <summary>
        ///// Gets or sets the permission records
        ///// </summary>
        ///// 
        ///// <summary>
        ///// Gets or sets discount usage history
        /// </summary>
        public virtual ICollection<PermissionRecord_Role_Mapping> PermissionRecord_Role_Mapping
        {
            get { return _PermissionRecord_Role_Mapping ?? (_PermissionRecord_Role_Mapping = new List<PermissionRecord_Role_Mapping>()); }
            protected set { _PermissionRecord_Role_Mapping = value; }
        }

    }
}
