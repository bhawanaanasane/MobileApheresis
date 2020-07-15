using CRM.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Customers
{

    /// <summary>
    /// CustomerPasswordService service interface
    /// </summary>

    public partial interface ICustomerPasswordService
    {
        /// <summary>
        /// Inserts a vendor
        /// </summary>
        /// <param name="passwword">Password</param>
        void InsertCustomerPassword(CustomerPassword password);

        /// <summary>
        /// Gets an Password by Customer identifier
        /// </summary>
        /// <param name="PasswordId">Password identifier</param>
        /// <returns>Address</returns>
        CustomerPassword GetPasswordByCustomerId(int customerId);

        /// <summary>
        /// Updates the Password
        /// </summary>
        /// <param name="password">Password</param>
        void UpdatePassword(CustomerPassword password);
    }
}
