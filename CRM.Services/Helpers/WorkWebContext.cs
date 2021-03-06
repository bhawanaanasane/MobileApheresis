﻿using CRM.Core;
using CRM.Core.Domain.Customers;
using CRM.Services.Authentication;
using CRM.Services.Customers;

using Microsoft.AspNetCore.Http;
using System;

namespace CRM.Services.Helpers
{
    public partial class WebWorkContext: IWorkContext
    {
        #region Const
       
        private const string CUSTOMER_COOKIE_NAME = ".MobileApheresis.Users";

        #endregion

        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAuthenticationService _authenticationService;

        private readonly ICustomerService _customerService;




        private readonly IUserAgentHelper _userAgentHelper;



        private Customer _cachedCustomer;
        private Customer _originalCustomerIfImpersonated;


        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpContextAccessor">HTTP context accessor</param>
        /// <param name="currencySettings">Currency settings</param>
        /// <param name="authenticationService">Authentication service</param>
        /// <param name="currencyService">Currency service</param>
        /// <param name="customerService">Customer service</param>
        /// <param name="genericAttributeService">Generic attribute service</param>
        /// <param name="languageService">Language service</param>
        /// <param name="storeContext">Store context</param>
        /// <param name="storeMappingService">Store mapping service</param>
        /// <param name="userAgentHelper">User gent helper</param>
        /// <param name="vendorService">Vendor service</param>
        /// <param name="localizationSettings">Localization settings</param>
        /// <param name="taxSettings">Tax settings</param>
        public WebWorkContext(IHttpContextAccessor httpContextAccessor,

            IAuthenticationService authenticationService,

            ICustomerService customerService,


            IUserAgentHelper userAgentHelper
          )
        {
            this._httpContextAccessor = httpContextAccessor;

            this._authenticationService = authenticationService;

            this._customerService = customerService;

            this._userAgentHelper = userAgentHelper;

        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get nop customer cookie
        /// </summary>
        /// <returns>String value of cookie</returns>
        protected virtual string GetCustomerCookie()
        {
            return _httpContextAccessor.HttpContext?.Request?.Cookies[CUSTOMER_COOKIE_NAME];
        }

        /// <summary>
        /// Set nop customer cookie
        /// </summary>
        /// <param name="customerGuid">Guid of the customer</param>
        protected virtual void SetCustomerCookie(Guid customerGuid)
        {
            if (_httpContextAccessor.HttpContext?.Response == null)
                return;

            //delete current cookie value
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(CUSTOMER_COOKIE_NAME);

            //get date of cookie expiration
            var cookieExpires = 24 * 365; //TODO make configurable
            var cookieExpiresDate = DateTime.Now.AddHours(cookieExpires);

            //if passed guid is empty set cookie as expired
            if (customerGuid == Guid.Empty)
                cookieExpiresDate = DateTime.Now.AddMonths(-1);

            //set new cookie value
            var options = new Microsoft.AspNetCore.Http.CookieOptions
            {
                HttpOnly = true,
                Expires = cookieExpiresDate
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(CUSTOMER_COOKIE_NAME, customerGuid.ToString(), options);
        }







        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        public virtual Customer CurrentCustomer
        {
            get
            {
                //whether there is a cached value
                if (_cachedCustomer != null)
                    return _cachedCustomer;

                Customer customer = null;

                //check whether request is made by a background (schedule) task
                if (_httpContextAccessor.HttpContext == null)
                {
                    //in this case return built-in customer record for background task
                    customer = _customerService.GetCustomerBySystemName(SystemCustomerNames.BackgroundTask);
                }

                //if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                //{
                //    //check whether request is made by a search engine, in this case return built-in customer record for search engines
                //    if (_userAgentHelper.IsSearchEngine())
                //        customer = _customerService.GetCustomerBySystemName(SystemCustomerNames.SearchEngine);
                //}

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //try to get registered user
                    customer = _authenticationService.GetAuthenticatedCustomer();

                }


                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //get guest customer
                    var customerCookie = GetCustomerCookie();
                    if (!string.IsNullOrEmpty(customerCookie))
                    {
                        if (Guid.TryParse(customerCookie, out Guid customerGuid))
                        {
                            //get customer from cookie (should not be registered)
                            var customerByCookie = _customerService.GetCustomerByGuid(customerGuid);
                            if (customerByCookie != null && !customerByCookie.IsRegistered())
                                customer = customerByCookie;
                        }
                    }
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //create guest if not exists
                   // customer = _customerService.InsertGuestCustomer();
                }


                //if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                //{
                //    //create guest if not exists
                //    customer = _customerService.InsertGuestCustomer();
                //}

                if (customer!=null)
                {
                    //set customer cookie
                    SetCustomerCookie(customer.CustomerGuid);

                    //cache the found customer
                    _cachedCustomer = customer;
                }

                return _cachedCustomer;
            }
            set
            {
                SetCustomerCookie(value.CustomerGuid);
                _cachedCustomer = value;
            }
        }

        /// <summary>
        /// Gets the original customer (in case the current one is impersonated)
        /// </summary>
        public virtual Customer OriginalCustomerIfImpersonated
        {
            get { return _originalCustomerIfImpersonated; }
        }


        /// <summary>
        /// Gets or sets value indicating whether we're in admin area
        /// </summary>
        public virtual bool IsAdmin { get; set; }

      

        #endregion
    }
}
