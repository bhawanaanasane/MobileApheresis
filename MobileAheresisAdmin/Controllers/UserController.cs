using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core;
using CRM.Core.Domain.Common;
using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Directory;
using CRM.Services.Authentication;
using CRM.Services.Common;
using CRM.Services.Customers;
using CRM.Services.Directory;
using CRM.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Factories;
using MobileAheresisAdmin.Models.Addresses;
using MobileAheresisAdmin.Models.Common;
using MobileAheresisAdmin.Models.CustomerLogin;
using MobileAheresisAdmin.Models.Users;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    public class UserController : BaseController
    {

        #region Fields
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _WorkContextService;
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ICustomerPasswordService _customerpasswordservice;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPermissionService _permissionService;
        private readonly IEncryptionService _encryptionService;
        #endregion

        #region CTOR
        public UserController(ICustomerService CustomerService,
            IWorkContext WorkContextService,
            IAddressService addressService,
            ICountryService countryService,
            IStateProvinceService stateProvinceService,
            ICustomerPasswordService Customerpasswordservice,
            IAuthenticationService AuthenticationService,
            ICustomerModelFactory CustomerModelFactory,
            ICustomerRegistrationService CustomerRegistrationService,
            IHttpContextAccessor httpContextAccessor,
            IPermissionService permissionService,
            IEncryptionService encryptionService)
        {
            this._customerService = CustomerService;
            this._WorkContextService = WorkContextService;
            this._addressService = addressService;
            this._countryService = countryService;
            this._stateProvinceService = stateProvinceService;
            this._customerpasswordservice = Customerpasswordservice;
            this._authenticationService = AuthenticationService;
            this._customerModelFactory = CustomerModelFactory;
            this._customerRegistrationService = CustomerRegistrationService;
            this._permissionService = permissionService;
            this._httpContextAccessor = httpContextAccessor;
            this._encryptionService = encryptionService;
        }

        #endregion

        #region Utilities
        protected virtual void PrepareCustomerDataModel(CustomerModel model)
        {
            model.AvailableCustomerRoles.Add(new SelectListItem { Text = "Select Roles", Value = "0" });

            foreach (var c in _customerService.GetAllCustomerRoles(showHidden: true).Where(a => a.Name != "Nurse"))
            {
                model.AvailableCustomerRoles.Add(new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = c.Id == model.CustomerRoleId
                });
            }

            model.AvailableCustomers.Add(new SelectListItem { Text = "Select Customer", Value = "0" });
            foreach (var c in _customerService.GetAllCustomers().Where(a => a.CustomerRole.Name == "Customer"))
            {
                model.AvailableCustomers.Add(new SelectListItem
                {
                    Text = c.BillingAddress.FirstName + " " + c.BillingAddress.LastName + " ( " + c.Email + " )",
                    Value = c.Id.ToString(),
                    Selected = c.Id == model.Id

                });
            }
        }

        protected virtual void PrepareCustomerModel(CustomerModel model, Customer customer, bool excludeProperties, bool prepareEntireAddressModel)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var address = _addressService.GetAddressById(customer != null ? customer.BillingAddress.Id : 0);
            if (customer != null)
            {
                if (!excludeProperties)
                {
                    if (address != null)
                    {
                        var Baddress = new AddressModel();
                        Baddress.FirstName = _encryptionService.DecryptText(address.FirstName);
                        Baddress.LastName = _encryptionService.DecryptText(address.LastName);
                        Baddress.PhoneNumber = _encryptionService.DecryptText(address.PhoneNumber);
                        Baddress.StateProvince = _encryptionService.DecryptText(address.StateProvince);
                        Baddress.ZipPostalCode = _encryptionService.DecryptText(address.ZipPostalCode);
                        Baddress.Email = _encryptionService.DecryptText(address.Email);
                        Baddress.City = _encryptionService.DecryptText(address.City);
                        Baddress.Address1 = _encryptionService.DecryptText(address.Address1);
                        Baddress.Address2 = _encryptionService.DecryptText(address.Address2);
                        Baddress.Id = address.Id;
                        Baddress.CreatedOnUtc = address.CreatedOnUtc;
                        model.BillingAddress = Baddress;
                    }
                }
            }
        }

        protected virtual void PrepareCustomerPasswordModel(CustomerModel model, Customer customer, bool excludeProperties, bool prepareEntireAddressModel)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var password = _customerpasswordservice.GetPasswordByCustomerId(customer != null ? customer.Id : 0);
            if (customer != null)
            {
                if (!excludeProperties)
                {
                    if (password != null)
                    {
                        model.CustomerPassword = password;
                        model.CustomerPassword.Password = _encryptionService.DecryptText(password.Password);
                    }
                }
            }
        }

        #endregion

        #region User Form

        // GET: User
        public IActionResult Index()
        {
            if (!(bool)SharedData.isManageUserMenuAccessible)
                return AccessDeniedView();

            //PageSize
            //var report = SharedData.CustomerReport;
            //if (report != null)
            //{
            //    SharedData.RowCount = report.RowCount;
            //    SharedData.ReportName = "Customer";
            //}
            //else
            //{
            //    SharedData.RowCount = 10;
            //    SharedData.ReportName = "Customer";
            //}
            //FormName
            ViewBag.FormName = "Users";
            //permissions
            if (SharedData.isManageUserMenuAccessible == false)
                return AccessDeniedView();
            CustomerListModel customerListModel = new CustomerListModel();
            var cust = _customerService.GetAllCustomers();
            foreach (var item in cust)
            {
                customerListModel.ListCustomerModel.Add(new CustomerViewModel
                {

                    CustomerName = _encryptionService.DecryptText(item.BillingAddress.FirstName) +
                                    " " + _encryptionService.DecryptText(item.BillingAddress.LastName),
                    Id = item.Id,
                    Email = _encryptionService.DecryptText(item.Email),
                    Status = item.Active,
                    CustomerRoleName = _customerService.GetCustomerRoleById(item.CustomerRoleId).Name

                    //            CustomerName = _encryptionService.DecryptText(item.BillingAddress.FirstName) + " "
                    //                + _encryptionService.DecryptText(item.BillingAddress.LastName),
                    //Id = item.Id,
                    //Email = _encryptionService.DecryptText(item.Email),
                    //Status = item.Active,
                    //CustomerRoleName = _customerService.GetCustomerRoleById(item.CustomerRoleId).Name

                });
            }
            return View(customerListModel);
        }


        // GET: User/Create
        public IActionResult Create()
        {
            ViewBag.FormName = "User";
            //permissions
            if (SharedData.isManageUserMenuAccessible == false)
                return AccessDeniedView();

            var model = new CustomerModel();
            PrepareCustomerDataModel(model);
            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerModel model, bool continueEditing)
        {
            ViewBag.FormName = "User :#" + model.Id;
            //permissions
            if (SharedData.isManageUserMenuAccessible == false)
                return AccessDeniedView();

            try
            {
                var formData = this.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

                //defult Customer role
                var customerrole = _customerService.GetAllCustomerRoles().Where(a => a.Name == "Customer").FirstOrDefault();

                Customer customer = null;

                CustomerPassword password = null;
                if (model.Id == 0)
                {
                    if (!string.IsNullOrWhiteSpace(model.BillingAddress.Email))
                    {
                        model.Phone = model.BillingAddress.PhoneNumber;
                        var customerList = _customerService.GetAllCustomers();

                        var customerData = new Customer();

                        foreach (var cust in customerList)
                        {
                            var email = _encryptionService.DecryptText(cust.BillingAddress.Email);
                            if (email == model.BillingAddress.Email)
                            {
                                customerData = cust;
                                break;
                            }
                        }
                        if (customerData.BillingAddress != null)
                        {
                            if (model.Id == 0)
                            {
                                AddNotification(NotificationMessage.TitleError, NotificationMessage.Emailisalreadyregistered, NotificationMessage.TypeError);
                                return RedirectToAction("Create");
                            }
                        }
                       

                    }
                }
                else
                {
                    customer = _customerService.GetCustomerById(model.Id);
                    AddNotification(NotificationMessage.TitleError, NotificationMessage.UserAlreadyRegistered, NotificationMessage.TypeError);
                    return RedirectToAction("Index");
                }

                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        var Baddress = new Address();
                        Baddress.FirstName = _encryptionService.EncryptText(model.BillingAddress.FirstName);
                        Baddress.LastName = _encryptionService.EncryptText(model.BillingAddress.LastName);
                        Baddress.PhoneNumber = _encryptionService.EncryptText(model.BillingAddress.PhoneNumber);
                        Baddress.StateProvince = _encryptionService.EncryptText(model.BillingAddress.StateProvince);
                        Baddress.ZipPostalCode = _encryptionService.EncryptText(model.BillingAddress.ZipPostalCode);
                        Baddress.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                        Baddress.City = _encryptionService.EncryptText(model.BillingAddress.City);
                        Baddress.Address1 = _encryptionService.EncryptText(model.BillingAddress.Address1);
                        Baddress.Address2 = _encryptionService.EncryptText(model.BillingAddress.Address2);

                        Baddress.CreatedOnUtc = DateTime.UtcNow;
                        customer = new Customer();
                        customer.CustomerGuid = Guid.NewGuid();
                        customer.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                        customer.Username = _encryptionService.EncryptText(model.BillingAddress.Email);
                        customer.CustomerRoleId = model.CustomerRole.Id;
                        customer.Active = true;
                        customer.CreatedOnUtc = DateTime.UtcNow;
                        customer.LastActivityDateUtc = DateTime.UtcNow;

                        _customerService.InsertCustomer(customer);
                        //customer.CustomerRoles.Add();
                        customer.Addresses.Add(Baddress);
                        customer.BillingAddress = Baddress;
                        _customerService.UpdateCustomer(customer);
                        // password
                        if (!string.IsNullOrWhiteSpace(model.CustomerPassword.Password))
                        {
                            password = new CustomerPassword
                            {
                                CustomerId = customer.Id,
                                Password = _encryptionService.EncryptText(model.CustomerPassword.Password),
                                CreatedOnUtc = DateTime.UtcNow,
                                //default passwordFormat
                                PasswordFormat = PasswordFormat.Encrypted

                            };
                            _customerpasswordservice.InsertCustomerPassword(password);
                        }

                    }
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddUser, NotificationMessage.TypeSuccess);

                    return RedirectToAction("Index");
                }
                else
                {
                    PrepareCustomerDataModel(model);
                    //defult Customer role
                    model.CustomerRoleNames = customerrole.Name;
                    return View(model);
                }
            }
            catch (Exception e)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return RedirectToAction("Create");
            }
        }

        // GET: User/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.FormName = "User :#" + id;
            //permissions
            if (SharedData.isManageUserMenuAccessible == false)
                return AccessDeniedView();
            var customers = _customerService.GetCustomerById(id);
            //var address = _addressService.GetAddressById(id);
            if (customers == null || customers.Deleted)
                //No Customer found with the specified id
                return RedirectToAction("UserCustomerList");
            var model = new CustomerModel
            {
                Email = _encryptionService.DecryptText(customers.Email),
                Username = _encryptionService.DecryptText(customers.Username),
                Active = customers.Active,
                CustomerRoleId = customers.CustomerRoleId
            };
            PrepareCustomerModel(model, customers, false, true);
            PrepareCustomerPasswordModel(model, customers, false, true);
            PrepareCustomerDataModel(model);
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerModel model, bool continueEditing)
        {
            ViewBag.FormName = "User :#" + model.Id;
            //permissions
            if (SharedData.isManageUserMenuAccessible == false)
                return AccessDeniedView();
            try
            {
                var customer = _customerService.GetCustomerById(model.Id);
                var password = _customerpasswordservice.GetPasswordByCustomerId(model.Id);
                if (customer == null || customer.Deleted)
                    //No vendor found with the specified id
                    return RedirectToAction("Index");

                if (ModelState.IsValid)
                {
                    customer.Username = _encryptionService.EncryptText(model.BillingAddress.Email);
                    customer.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                    customer.CustomerRoleId = model.CustomerRoleId;
                    _customerService.UpdateCustomer(customer);
                    password.Password = _encryptionService.EncryptText(model.CustomerPassword.Password);
                    _customerpasswordservice.UpdatePassword(password);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                    //address
                    var address = _addressService.GetAddressById(customer.BillingAddress.Id);
                    if (address == null)
                    {
                        address.FirstName = _encryptionService.EncryptText(model.BillingAddress.FirstName);
                        address.LastName = _encryptionService.EncryptText(model.BillingAddress.LastName);
                        address.PhoneNumber = _encryptionService.EncryptText(model.BillingAddress.PhoneNumber);
                        address.StateProvince = _encryptionService.EncryptText(model.BillingAddress.StateProvince);
                        address.ZipPostalCode = _encryptionService.EncryptText(model.BillingAddress.ZipPostalCode);
                        address.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                        address.City = _encryptionService.EncryptText(model.BillingAddress.City);
                        address.Address1 = _encryptionService.EncryptText(model.BillingAddress.Address1);
                        address.Address2 = _encryptionService.EncryptText(model.BillingAddress.Address2);

                        _addressService.InsertAddress(address);
                        // customer.Id = address.Id;
                        _customerService.UpdateCustomer(customer);
                    }
                    else
                    {
                        address.Address1 = _encryptionService.EncryptText(model.BillingAddress.Address1);
                        address.Address2 = _encryptionService.EncryptText(model.BillingAddress.Address2);
                        address.StateProvince = _encryptionService.EncryptText(model.BillingAddress.StateProvince);
                        address.City = _encryptionService.EncryptText(model.BillingAddress.City);
                        address.ZipPostalCode = _encryptionService.EncryptText(model.BillingAddress.ZipPostalCode);
                        address.FirstName = _encryptionService.EncryptText(model.BillingAddress.FirstName);
                        address.LastName = _encryptionService.EncryptText(model.BillingAddress.LastName);
                        address.Email = _encryptionService.EncryptText(model.BillingAddress.Email);

                        _addressService.UpdateAddress(address);
                    }
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgEditUser, NotificationMessage.TypeSuccess);
                    if (continueEditing)
                    {
                        return RedirectToAction("Edit", new { id = customer.Id });
                    }
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    PrepareCustomerModel(model, customer, false, true);
                    PrepareCustomerPasswordModel(model, customer, false, true);
                    PrepareCustomerDataModel(model);
                    return View(model);
                }

            }
            catch (Exception e)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return RedirectToAction("Edit", "User", model.Id);
            }
        }

        // Post: User/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //permissions
            if (SharedData.isManageUserMenuAccessible == false)
                return AccessDeniedView();
            ResponceModel responceModel = new ResponceModel();
            try
            {
                var UserData = _customerService.GetCustomerById(id);
                _customerService.DeleteCustomer(UserData);
                responceModel.Success = true;
                responceModel.Message = "Deleted.";
                AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgUserDeleted, NotificationMessage.TypeSuccess);
                return Json(responceModel);
            }
            catch (Exception e)
            {
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrormsgUserDeleted, NotificationMessage.TypeError);
                return Json(responceModel);
            }
        }
        #endregion


        #region UserLogin

        public virtual IActionResult Login()
        {
            var model = _customerModelFactory.PrepareLoginModel();
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Login(LoginModel model, string returnUrl, bool captchaValid)
        {
            var username = _encryptionService.EncryptText(model.Email);
            var password = _encryptionService.EncryptText(model.Password);
            if (ModelState.IsValid)
            {

                var loginResult = _customerRegistrationService.ValidateCustomerLogin(model.Email, model.Password);
                switch (loginResult)
                {
                    case CustomerLoginResults.Successful:
                        {
                            var customer = _customerService.GetCustomerByEmail(_encryptionService.EncryptText(model.Email));

                            _authenticationService.SignIn(customer, model.RememberMe);

                            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                            {
                                NotificationMessage.msgLoginSuccessfull = "Welcome Back !" + " " + _encryptionService.DecryptText(_WorkContextService.CurrentCustomer.BillingAddress.FirstName) + "" + _encryptionService.DecryptText(_WorkContextService.CurrentCustomer.BillingAddress.LastName);
                                AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgLoginSuccessfull, NotificationMessage.TypeSuccess);

                                return Redirect("/Home/Index");
                            }
                            return Redirect(returnUrl);
                        }
                    case CustomerLoginResults.CustomerNotExist:
                        ModelState.AddModelError("", "CustomerNotExist");
                        break;
                    case CustomerLoginResults.Deleted:
                        ModelState.AddModelError("", "Deleted");
                        break;
                    case CustomerLoginResults.NotActive:
                        ModelState.AddModelError("", "NotActive");
                        break;
                    case CustomerLoginResults.NotRegistered:
                        ModelState.AddModelError("", "NotRegistered");
                        break;
                    case CustomerLoginResults.LockedOut:
                        ModelState.AddModelError("", "LockedOut.Try after 10 min");
                        break;
                    case CustomerLoginResults.WrongPassword:
                    default:
                        ModelState.AddModelError("", "WrongCredentials");
                        break;
                }
            }
            return View(model);
        }

        public virtual IActionResult Logout()
        {
            SharedData.ClearAll();

            //standard logout 
            _authenticationService.SignOut();

            //raise logged out event       
            var CustomerLogOut = new CustomerLoggedOutEvent(_WorkContextService.CurrentCustomer);

            _WorkContextService.CurrentCustomer.CustomerGuid = new Guid();
            //delete current cookie value
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(".MobileApheresis.Users");
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}