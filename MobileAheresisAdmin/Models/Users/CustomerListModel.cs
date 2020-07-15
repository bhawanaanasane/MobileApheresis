using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Users
{
    public class CustomerListModel :BaseEntityModel
    {
        public CustomerListModel()
        {
            AvailableName = new List<SelectListItem>();
            AvailableEmail = new List<SelectListItem>();
            AvailableActive = new List<SelectListItem>();
            ListCustomerModel = new List<CustomerViewModel>();
        }
        [DisplayName("SearchName")]
        public string SearchName { get; set; }
        public IList<SelectListItem> AvailableName { get; set; }
        public IList<SelectListItem> AvailableEmail { get; set; }
        public IList<SelectListItem> AvailableActive { get; set; }
        public IList<CustomerViewModel> ListCustomerModel { get; set; }
    }

    public partial class CustomerViewModel : BaseEntityModel
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Use valid emailId")]
        public string Email { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        public string CustomerRoleName { get; set; }

        public int pickupId { get; set; }



    }
}
