using CRM.Core.Domain.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Models.Addresses;
using MobileAheresisAdmin.Models.UsersRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Users
{
    public class CustomerModel :BaseEntityModel
    {
        public CustomerModel()
        {
            this.SelectedCustomerRoleIds = new List<int>();
            this.AvailableCustomerRoles = new List<SelectListItem>();
            this.AvailableCountries = new List<SelectListItem>();
            this.AvailableStates = new List<SelectListItem>();
            this.AvailableCustomers = new List<SelectListItem>();

        }

        //MVC is suppressing further validation if the IFormCollection is passed to a controller method. That's why we add to the model
        public IFormCollection Form { get; set; }

        public string Username { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        public CustomerPassword CustomerPassword { get; set; }



        //form fields & properties
        public bool GenderEnabled { get; set; }
        public string Gender { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public string CompanyName { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public string ZipPostalCode { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public bool CountryEnabled { get; set; }
        public int CountryId { get; set; }


        public IList<SelectListItem> AvailableCountries { get; set; }

        public IList<SelectListItem> AvailableCustomers { get; set; }

        //billing info
        public AddressModel BillingAddress { get; set; }

        //shipping info
        public AddressModel ShippingAddress { get; set; }
        //items

        //CustomerRole info

        public int CustomerRoleId { get; set; }

        public CustomerRoleModel CustomerRole { get; set; }
        //State 
        public string State { get; set; }
        public int StateProvinceId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        public string RegisteredInStore { get; set; }

        public string AdminComment { get; set; }

        public bool IsTaxExempt { get; set; }

        public bool Active { get; set; }

        public int AffiliateId { get; set; }
        public string AffiliateName { get; set; }

        public bool AllowCustomersToSetTimeZone { get; set; }


        //EU VAT
        public string VatNumber { get; set; }

        public string VatNumberStatusNote { get; set; }

        public bool DisplayVatNumber { get; set; }

        //registration date
        public DateTime CreatedOn { get; set; }
        public DateTime LastActivityDate { get; set; }

        //IP address
        public string LastIpAddress { get; set; }

        public string LastVisitedPage { get; set; }

        //customer roles

        public string CustomerRoleNames { get; set; }
        public List<SelectListItem> AvailableCustomerRoles { get; set; }
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public int VendorId { get; set; }


        
    }
}
