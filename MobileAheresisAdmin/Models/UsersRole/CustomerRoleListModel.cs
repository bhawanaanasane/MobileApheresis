using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.UsersRole
{
    public partial class CustomerRoleListModel : BaseEntityModel
    {
        public CustomerRoleListModel()
        {

            ListCustomerRole = new List<CustomerRoleModel>();
        }
        [Required(ErrorMessage = "Enter valid Name")]
        [DisplayName("SearchName")]
        public string SearchName { get; set; }

        public IList<CustomerRoleModel> ListCustomerRole { get; set; }
    }
}
