using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.UsersRole
{
    public class CustomerRoleModel : BaseEntityModel
    {

        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>

        public string Name { get; set; }

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

        ///// <summary>
        ///// Gets or sets the customer role system name
        ///// </summary>
        //public string SystemName { get; set; }


        ///// <summary>
        ///// Gets or sets a value indicating whether the customer role is marked as tax exempt
        ///// </summary>
        //public bool TaxExempt { get; set; }


        /// <summary>
        /// Gets or sets the customer role Desscription
        /// </summary>
        public string Description { get; set; }

    }
}
