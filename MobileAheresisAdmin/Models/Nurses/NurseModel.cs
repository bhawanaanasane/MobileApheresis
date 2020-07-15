using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Nurses;
using MobileAheresisAdmin.Models.Addresses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Nurses
{
    public class NurseModel :BaseEntityModel
    {
        public NurseModel() {
            this.BillingAddress = new AddressModel();
            this.CustomerPassword = new CustomerPassword();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public IList<NurseDocuments> NurseDocuments { get; set; }

        public string Document { get; set; }
        //PhoneNumber
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        //State Id
        public int StateProvinceId { get; set; }

        //billing info
        public AddressModel BillingAddress { get; set; }
        //Password
        public CustomerPassword CustomerPassword { get; set; }

        public int DocumentTypeId { get; set; }

      
        public DocumentType DocumentType
        {
            get
            {
                return (DocumentType)DocumentTypeId;
            }
            set
            {
                DocumentTypeId = (int)value;
            }
        }




    }
   
}
