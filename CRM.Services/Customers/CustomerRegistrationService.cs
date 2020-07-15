using CRM.Core;
using CRM.Core.Domain.Customers;
using CRM.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Services.Customers
{
    /// <summary>
    /// Customer registration service
    /// </summary>
    public partial class CustomerRegistrationService : ICustomerRegistrationService
    {
        #region Fields

        private const int SALT_KEY_SIZE = 5;

        private readonly ICustomerService _customerService;
        private readonly IEncryptionService _encryptionService;
        private readonly IWorkContext _workContext;
       
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="customerService">Customer service</param>
        /// <param name="encryptionService">Encryption service</param>
        /// <param name="newsLetterSubscriptionService">Newsletter subscription service</param>
        /// <param name="localizationService">Localization service</param>
        /// <param name="storeService">Store service</param>
        /// <param name="rewardPointService">Reward points service</param>
        /// <param name="genericAttributeService">Generic attribute service</param>
        /// <param name="workContext">Work context</param>
        /// <param name="workflowMessageService">Workflow message service</param>
        /// <param name="eventPublisher">Event publisher</param>
        /// <param name="rewardPointsSettings">Reward points settings</param>
        /// <param name="customerSettings">Customer settings</param>
        public CustomerRegistrationService(ICustomerService customerService,
            IEncryptionService encryptionService,
          
            IWorkContext workContext
         )
        {
            this._customerService = customerService;
            this._encryptionService = encryptionService;
         
            this._workContext = workContext;
        
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Check whether the entered password matches with a saved one
        /// </summary>
        /// <param name="customerPassword">Customer password</param>
        /// <param name="enteredPassword">The entered password</param>
        /// <returns>True if passwords match; otherwise false</returns>
        protected bool PasswordsMatch(CustomerPassword customerPassword, string enteredPassword)
        {
            if (customerPassword == null || string.IsNullOrEmpty(enteredPassword))
                return false;

            var savedPassword = string.Empty;
            //switch (customerPassword.PasswordFormat)
            //{
                //case PasswordFormat.Clear:
                //    savedPassword = enteredPassword;
                //    break;
                //case PasswordFormat.Encrypted:
                    savedPassword = _encryptionService.DecryptText(customerPassword.Password);
                    //break;
                //case PasswordFormat.Hashed:
                //    savedPassword = _encryptionService.CreatePasswordHash(enteredPassword, customerPassword.PasswordSalt, "");
                //    break;
            //}

            if (customerPassword.Password == null)
                return false;

            

            return (savedPassword == enteredPassword)? true:false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validate customer
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public virtual Customer ValidateCustomer(string usernameOrEmail, string password)
        {
            var customerList = _customerService.GetAllCustomers();

            var customer = new Customer();

            foreach (var cust in customerList)
            {
                var email = _encryptionService.DecryptText(cust.Email);
                if (email == usernameOrEmail)
                {
                    customer = cust;
                    break;
                }
                
            }

            if (customer == null)
                return null;
            if (customer.Deleted)
                return null;
            if (!customer.Active)
                return null;
            //only registered can login
            //if (!customer.IsRegistered())
            //    return null;
            ////check whether a customer is locked out
            //if (customer.CannotLoginUntilDateUtc.HasValue && customer.CannotLoginUntilDateUtc.Value > DateTime.UtcNow)
            //    return CustomerLoginResults.LockedOut;

            var Password = _customerService.GetCurrentPassword(customer.Id);
            if (!PasswordsMatch(_customerService.GetCurrentPassword(customer.Id), password))
            {
                ////wrong password
                //customer.FailedLoginAttempts++;
                //if (_customerSettings.FailedPasswordAllowedAttempts > 0 &&
                //    customer.FailedLoginAttempts >= _customerSettings.FailedPasswordAllowedAttempts)
                //{
                //    //lock out
                //    customer.CannotLoginUntilDateUtc = DateTime.UtcNow.AddMinutes(_customerSettings.FailedPasswordLockoutMinutes);
                //    //reset the counter
                //    customer.FailedLoginAttempts = 0;
                //}
                //_customerService.UpdateCustomer(customer);

                return null;
            }

            ////update login details
            //customer.FailedLoginAttempts = 0;
            //customer.CannotLoginUntilDateUtc = null;
            //customer.RequireReLogin = false;
            customer.LastLoginDateUtc = DateTime.UtcNow;
            _customerService.UpdateCustomer(customer);

            return customer;
        }


        /// <summary>
        /// Validate customer
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public virtual CustomerLoginResults ValidateCustomerLogin(string usernameOrEmail, string password)
        {
            var customerList = _customerService.GetAllCustomers();

            var customer = new Customer();

            foreach(var cust in customerList)
            {
                var email = _encryptionService.DecryptText(cust.Email);
                if (email == usernameOrEmail)
                {
                    customer = cust;
                    break;
                }
                //var   email =  _encryptionService.DecryptText(cust.Email) ;

                //  var pass = _customerService.GetCurrentPassword(cust.Id).Password;

                //  var decryptPass = _encryptionService.DecryptText(pass);
                // var pass = _encryptionService.DecryptText(cust.cus);
                //if (email == usernameOrEmail) {
                //    customer = cust;
                //}
            }


            if (customer == null)
                return CustomerLoginResults.CustomerNotExist;
            if (customer.Deleted)
                return CustomerLoginResults.Deleted;
            if (!customer.Active)
                return CustomerLoginResults.NotActive;

            if (customer.CannotLoginUntilDateUtc.HasValue && customer.CannotLoginUntilDateUtc.Value > DateTime.UtcNow)
                return CustomerLoginResults.LockedOut;
            
            if (!PasswordsMatch(_customerService.GetCurrentPassword(customer.Id), password))
            {
                //wrong password
                customer.FailedLoginAttempts++;
                if ( customer.FailedLoginAttempts >= 3)
                {
                    //lock out
                    customer.CannotLoginUntilDateUtc = DateTime.UtcNow.AddMinutes(10);
                    //reset the counter
                    customer.FailedLoginAttempts = 0;
                }
                _customerService.UpdateCustomer(customer);

                return CustomerLoginResults.WrongPassword;
            }

            //update login details
            customer.FailedLoginAttempts = 0;
            customer.CannotLoginUntilDateUtc = null;
            customer.RequireReLogin = false;
            customer.LastLoginDateUtc = DateTime.UtcNow;
            _customerService.UpdateCustomer(customer);

            return CustomerLoginResults.Successful;
        }


        /// <summary>
        /// Register customer
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Customer == null)
                throw new ArgumentException("Can't load current customer");

            var result = new CustomerRegistrationResult();
            //if (request.Customer.IsSearchEngineAccount())
            //{
            //    result.AddError("Search engine can't be registered");
            //    return result;
            //}
            //if (request.Customer.IsBackgroundTaskAccount())
            //{
            //    result.AddError("Background task account can't be registered");
            //    return result;
            //}
            //if (request.Customer.IsRegistered())
            //{
            //   // result.AddError("Current customer is already registered");
            //    return result;
            //}
            if (string.IsNullOrEmpty(request.Email))
            {
               // result.AddError(_localizationService.GetResource("Account.Register.Errors.EmailIsNotProvided"));
                return result;
            }
            //if (!CommonHelper.IsValidEmail(request.Email))
            //{
            //    //result.AddError(_localizationService.GetResource("Common.WrongEmail"));
            //    return result;
            //}
            if (string.IsNullOrWhiteSpace(request.Password))
            {
               // result.AddError(_localizationService.GetResource("Account.Register.Errors.PasswordIsNotProvided"));
                return result;
            }
            //if (_customerSettings.UsernamesEnabled)
            //{
            //    if (string.IsNullOrEmpty(request.Username))
            //    {
            //        result.AddError(_localizationService.GetResource("Account.Register.Errors.UsernameIsNotProvided"));
            //        return result;
            //    }
            //}

            //validate unique user
            if (_customerService.GetCustomerByEmail(request.Email) != null)
            {
             //   result.AddError(_localizationService.GetResource("Account.Register.Errors.EmailAlreadyExists"));
                return result;
            }
            //if (_customerSettings.UsernamesEnabled)
            //{
            //    if (_customerService.GetCustomerByUsername(request.Username) != null)
            //    {
            //        result.AddError(_localizationService.GetResource("Account.Register.Errors.UsernameAlreadyExists"));
            //        return result;
            //    }
            //}

            //at this point request is valid
            request.Customer.Username = request.Username;
            request.Customer.Email = request.Email;

            var customerPassword = new CustomerPassword
            {
                Customer = request.Customer,
                PasswordFormat = request.PasswordFormat,
                CreatedOnUtc = DateTime.UtcNow
            };
            switch (request.PasswordFormat)
            {
                case PasswordFormat.Clear:
                    customerPassword.Password = request.Password;
                    break;
                case PasswordFormat.Encrypted:
                    customerPassword.Password = _encryptionService.EncryptText(request.Password);
                    break;
                case PasswordFormat.Hashed:
                    {
                        var saltKey = _encryptionService.CreateSaltKey(SALT_KEY_SIZE);
                        customerPassword.PasswordSalt = saltKey;
                        customerPassword.Password = _encryptionService.CreatePasswordHash(request.Password, saltKey, "");
                    }
                    break;
            }
            _customerService.InsertCustomerPassword(customerPassword);

            request.Customer.Active = request.IsApproved;

            //add to 'Registered' role
            var registeredRole = _customerService.GetCustomerRoleBySystemName(SystemCustomerRoleNames.Registered);
            if (registeredRole == null)
                throw new Exception("'Registered' role could not be loaded");
            request.Customer.CustomerRoles.Add(registeredRole);
            //remove from 'Guests' role
            var guestRole = request.Customer.CustomerRoles.FirstOrDefault(cr => cr.SystemName == SystemCustomerRoleNames.Guests);
            if (guestRole != null)
                request.Customer.CustomerRoles.Remove(guestRole);

           

            _customerService.UpdateCustomer(request.Customer);

         
            return result;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual ChangePasswordResult ChangePassword(ChangePasswordRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var result = new ChangePasswordResult();
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                result.AddError("EmailIsNotProvided");
                return result;
            }
            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                result.AddError("PasswordIsNotProvided");
                return result;
            }

            var customer = _customerService.GetCustomerByEmail(request.Email);
            if (customer == null)
            {
                result.AddError("EmailNotFound");
                return result;
            }

            if (request.ValidateRequest)
            {
                //request isn't valid
                if (!PasswordsMatch(_customerService.GetCurrentPassword(customer.Id), request.OldPassword))
                {
                    result.AddError("OldPasswordDoesntMatch");
                    return result;
                }
            }

            //check for duplicates
            if (/*_customerSettings.UnduplicatedPasswordsNumber*/ 0 > 0)
            {
                //get some of previous passwords
                var previousPasswords = _customerService.GetCustomerPasswords(customer.Id, passwordsToReturn:0);

                var newPasswordMatchesWithPrevious = previousPasswords.Any(password => PasswordsMatch(password, request.NewPassword));
                if (newPasswordMatchesWithPrevious)
                {
                    result.AddError("");
                    return result;
                }
            }

            //at this point request is valid
            var customerPassword = new CustomerPassword
            {
                Customer = customer,
                PasswordFormat = request.NewPasswordFormat,
                CreatedOnUtc = DateTime.UtcNow
            };
            switch (request.NewPasswordFormat)
            {
                case PasswordFormat.Clear:
                    customerPassword.Password = request.NewPassword;
                    break;
                case PasswordFormat.Encrypted:
                    customerPassword.Password = _encryptionService.EncryptText(request.NewPassword);
                    break;
                case PasswordFormat.Hashed:
                    {
                        var saltKey = _encryptionService.CreateSaltKey(SALT_KEY_SIZE);
                        customerPassword.PasswordSalt = saltKey;
                        customerPassword.Password = _encryptionService.CreatePasswordHash(request.NewPassword, saltKey,"");
                    }
                    break;
            }
            _customerService.InsertCustomerPassword(customerPassword);

            return result;
        }

        /// <summary>
        /// Sets a user email
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newEmail">New email</param>
        /// <param name="requireValidation">Require validation of new email address</param>
        public virtual void SetEmail(Customer customer, string newEmail, bool requireValidation)
        {
            //if (customer == null)
            //    throw new ArgumentNullException(nameof(customer));

            //if (newEmail == null)
            //    throw new NopException("Email cannot be null");

            //newEmail = newEmail.Trim();
            //var oldEmail = customer.Email;

            //if (!CommonHelper.IsValidEmail(newEmail))
            //    throw new NopException(_localizationService.GetResource("Account.EmailUsernameErrors.NewEmailIsNotValid"));

            //if (newEmail.Length > 100)
            //    throw new NopException(_localizationService.GetResource("Account.EmailUsernameErrors.EmailTooLong"));

            //var customer2 = _customerService.GetCustomerByEmail(newEmail);
            //if (customer2 != null && customer.Id != customer2.Id)
            //    throw new NopException(_localizationService.GetResource("Account.EmailUsernameErrors.EmailAlreadyExists"));

            //if (requireValidation)
            //{
            //    //re-validate email
            //    customer.EmailToRevalidate = newEmail;
            //    _customerService.UpdateCustomer(customer);

            //    //email re-validation message
            //    _genericAttributeService.SaveAttribute(customer, SystemCustomerAttributeNames.EmailRevalidationToken, Guid.NewGuid().ToString());
            //    _workflowMessageService.SendCustomerEmailRevalidationMessage(customer, _workContext.WorkingLanguage.Id);
            //}
            //else
            //{
            //    customer.Email = newEmail;
            //    _customerService.UpdateCustomer(customer);

            //    //update newsletter subscription (if required)
            //    if (!string.IsNullOrEmpty(oldEmail) && !oldEmail.Equals(newEmail, StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        foreach (var store in _storeService.GetAllStores())
            //        {
            //            var subscriptionOld = _newsLetterSubscriptionService.GetNewsLetterSubscriptionByEmailAndStoreId(oldEmail, store.Id);
            //            if (subscriptionOld != null)
            //            {
            //                subscriptionOld.Email = newEmail;
            //                _newsLetterSubscriptionService.UpdateNewsLetterSubscription(subscriptionOld);
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Sets a customer username
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newUsername">New Username</param>
        public virtual void SetUsername(Customer customer, string newUsername)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            //if (!_customerSettings.UsernamesEnabled)
            //    throw new NopException("Usernames are disabled");

            newUsername = newUsername.Trim();

            //if (newUsername.Length > 100)
            //    throw new NopException(_localizationService.GetResource("Account.EmailUsernameErrors.UsernameTooLong"));

            var user2 = _customerService.GetCustomerByUsername(newUsername);
            //if (user2 != null && customer.Id != user2.Id)
            //    throw new NopException(_localizationService.GetResource("Account.EmailUsernameErrors.UsernameAlreadyExists"));

            customer.Username = newUsername;
            _customerService.UpdateCustomer(customer);
        }

        #endregion
    }
}
