using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CRM.Core.Domain.Customers;
using CRM.Data.Interfaces;

namespace CRM.Services.Customers
{
   public class CustomerPasswordService :ICustomerPasswordService
    {
        #region Field
        private readonly IRepository<CustomerPassword> _customerPasswordRepository;
        #endregion
        #region Ctor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vendorRepository">Vendor repository</param>
        public CustomerPasswordService(IRepository<CustomerPassword> customerPasswordRepository) {
            this._customerPasswordRepository = customerPasswordRepository;
        }

        #endregion
        #region Methods

        public void InsertCustomerPassword(CustomerPassword password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            _customerPasswordRepository.Insert(password);
        }
        /// <summary>
        /// Gets Password by Customer identifier
        /// </summary>
        /// <param name="CustomerId">Customer identifier</param>
        /// <returns>Number of addresses</returns>
        public  CustomerPassword GetPasswordByCustomerId(int customerId)
        {
            if (customerId == 0)
                throw new ArgumentNullException(nameof(customerId));

            var query = from a in _customerPasswordRepository.Table
                        where a.CustomerId == customerId
                        select a;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Updates the Password
        /// </summary>
        /// <param name="Password">Password</param>
        public virtual void UpdatePassword(CustomerPassword password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            _customerPasswordRepository.Update(password);

        }

        #endregion

    }
}
