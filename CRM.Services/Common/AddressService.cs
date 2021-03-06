﻿using CRM.Core.Domain.Common;
using CRM.Data.Interfaces;
using CRM.Services.Directory;
using CRM.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Services.Common
{
    public partial class AddressService : IAddressService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address ID
        /// </remarks>
        private const string ADDRESSES_BY_ID_KEY = "Nop.address.id-{0}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string ADDRESSES_PATTERN_KEY = "Nop.address.";

        #endregion

        #region Fields

        private readonly IRepository<Address> _addressRepository;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IAddressAttributeService _addressAttributeService;
      
        private readonly AddressSettings _addressSettings;
       

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="addressRepository">Address repository</param>
        /// <param name="countryService">Country service</param>
        /// <param name="stateProvinceService">State/province service</param>
        /// <param name="addressAttributeService">Address attribute service</param>
        /// <param name="eventPublisher">Event publisher</param>
        /// <param name="addressSettings">Address settings</param>
        public AddressService(
            IRepository<Address> addressRepository,
            ICountryService countryService,
            IStateProvinceService stateProvinceService,
            IAddressAttributeService addressAttributeService,
          
            AddressSettings addressSettings)
        {
           
            this._addressRepository = addressRepository;
            this._countryService = countryService;
            this._stateProvinceService = stateProvinceService;
            this._addressAttributeService = addressAttributeService;
            
            this._addressSettings = addressSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes an address
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void DeleteAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            _addressRepository.Delete(address);

            //cache
       
        }

        /// <summary>
        /// Gets all Address
        /// </summary>
        /// <returns>Warehouses</returns>
        public virtual IList<Address> GetAllAddresses()
        {
            var query = from wh in _addressRepository.Table
                        orderby wh.FirstName
                        select wh;
            var warehouses = query.ToList();
            return warehouses;
        }


      
       
        

        /// <summary>
        /// Gets an address by address identifier
        /// </summary>
        /// <param name="addressId">Address identifier</param>
        /// <returns>Address</returns>
        public virtual Address GetAddressById(int addressId)
        {
            if (addressId == 0)
                return null;

           
           return _addressRepository.GetById(addressId);
        }

        /// <summary>
        /// Get customers by identifiers
        /// </summary>
        /// <param name="customerIds">Customer identifiers</param>
        /// <returns>Customers</returns>
        public virtual IList<Address> GetAddressByIds(int[] addressIds)
        {
            if (addressIds == null || addressIds.Length == 0)
                return new List<Address>();

            var query = from c in _addressRepository.Table
                        where addressIds.Contains(c.Id) 
                        select c;
            var customers = query.ToList();
            //sort by passed identifiers
            var sortedCustomers = new List<Address>();
            foreach (var id in addressIds)
            {
                var customer = customers.Find(x => x.Id == id);
                if (customer != null)
                    sortedCustomers.Add(customer);
            }
            return sortedCustomers;
        }



        /// <summary>
        /// Inserts an address
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void InsertAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            address.CreatedOnUtc = DateTime.UtcNow;

            //some validation
         

            _addressRepository.Insert(address);

           
        }

        /// <summary>
        /// Updates the address
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void UpdateAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            //some validation
           

            _addressRepository.Update(address);

           
        }

        /// <summary>
        /// Gets a value indicating whether address is valid (can be saved)
        /// </summary>
        /// <param name="address">Address to validate</param>
        /// <returns>Result</returns>
        public virtual bool IsAddressValid(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            if (string.IsNullOrWhiteSpace(address.FirstName))
                return false;

            if (string.IsNullOrWhiteSpace(address.LastName))
                return false;

            if (string.IsNullOrWhiteSpace(address.Email))
                return false;

            if (_addressSettings.CompanyEnabled &&
                _addressSettings.CompanyRequired)
                return false;

            if (_addressSettings.StreetAddressEnabled &&
                _addressSettings.StreetAddressRequired &&
                string.IsNullOrWhiteSpace(address.Address1))
                return false;

            if (_addressSettings.StreetAddress2Enabled &&
                _addressSettings.StreetAddress2Required &&
                string.IsNullOrWhiteSpace(address.Address2))
                return false;

            if (_addressSettings.ZipPostalCodeEnabled &&
                _addressSettings.ZipPostalCodeRequired &&
                string.IsNullOrWhiteSpace(address.ZipPostalCode))
                return false;

          

            if (_addressSettings.CityEnabled &&
                _addressSettings.CityRequired &&
                string.IsNullOrWhiteSpace(address.City))
                return false;

            if (_addressSettings.PhoneEnabled &&
                _addressSettings.PhoneRequired &&
                string.IsNullOrWhiteSpace(address.PhoneNumber))
                return false;

            if (_addressSettings.FaxEnabled &&
                _addressSettings.FaxRequired &&
                string.IsNullOrWhiteSpace(address.FaxNumber))
                return false;

            var attributes = _addressAttributeService.GetAllAddressAttributes();
            if (attributes.Any(x => x.IsRequired))
                return false;

            return true;
        }

        #endregion
    }
}
