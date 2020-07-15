using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Customers
{
    /// <summary>
    /// System customer role names
    /// </summary>
    public static partial class SystemCustomerRoleNames
    {
        /// <summary>
        /// Administrators
        /// </summary>
        public static string Admin { get { return "Admin"; } }

        /// <summary>
        /// ForumModerators
        /// </summary>
        public static string Customer { get { return "Customer"; } }

        /// <summary>
        /// Registered
        /// </summary>
        public static string Registered { get { return "Registered"; } }

        /// <summary>
        /// Guests
        /// </summary>
        public static string Guests { get { return "Guests"; } }

        /// <summary>
        /// Vendors
        /// </summary>
        public static string Vendors { get { return "Vendors"; } }
    }
}
