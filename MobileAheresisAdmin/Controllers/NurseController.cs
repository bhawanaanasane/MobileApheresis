using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core;
using CRM.Core.Domain.Common;
using CRM.Core.Domain.CompanyProfiles;
using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Nurses;
using CRM.Services.Common;
using CRM.Services.CompanyProfiles;
using CRM.Services.Customers;
using CRM.Services.Nurses;
using CRM.Services.Security;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Models.Addresses;
using MobileAheresisAdmin.Models.Common;
using MobileAheresisAdmin.Models.Nurses;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    public class NurseController : BaseController
    {

        #region Fields
        private readonly INurseServices _nurseServices;
        private readonly ICustomerService _customerServices;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IWorkContext _workContext;
        private readonly ICompanyProfileService _companyProfileService;
        private readonly ICustomerPasswordService _customerpasswordservice;
        private readonly IAddressService _addressservice;
        private readonly ITreatmentRecordServices _treatmentRecordservice;
        private readonly IPermissionService _permissionService;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region CTOR
        public NurseController(INurseServices NurseServices, IWorkContext workContext,
            ICompanyProfileService CompanyProfileService,
            IHostingEnvironment hostingEnvironment,
            ICustomerService CustomerServices,
            ICustomerPasswordService Customerpasswordservice,
            IAddressService Addressservice,
            ITreatmentRecordServices TreatmentRecordservice,
            IPermissionService permissionService,
            IEncryptionService encryptionService)
        {
            this._nurseServices = NurseServices;
            this._hostingEnvironment = hostingEnvironment;
            this._workContext = workContext;
            _companyProfileService = CompanyProfileService;
            this._customerServices = CustomerServices;
            this._customerpasswordservice = Customerpasswordservice;
            this._addressservice = Addressservice;
            this._treatmentRecordservice = TreatmentRecordservice;
            this._permissionService = permissionService;
            this._encryptionService = encryptionService;
        }

        #endregion


        #region Utilities

        #endregion

        // GET: Nurse
        public IActionResult Index()
        {
            if (!(bool)SharedData.isNurseMenuAccessible)
                return AccessDeniedView();

            ViewBag.FormName = "Nurse";
            var NurseList = new NurseListModel();
            var nurseListData = _nurseServices.GetAllNurse();
            var nurse = nurseListData.Select(a => new NurseModel
            {
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                Email = _encryptionService.DecryptText(a.Email),
                FirstName = _encryptionService.DecryptText(a.FirstName),
                Id = a.Id,
                LastName = _encryptionService.DecryptText(a.LastName),
                LastUpdated = a.LastUpdated
            }).ToList();
            NurseList.NurseList = nurse;
            return View(NurseList);
        }




        #region Create Nurse
        // GET: Nurse/Create
        public IActionResult Create()
        {//10/10/2019 aakansha
            ViewBag.FormName = "Nurse";
            if (!(bool)SharedData.isNurseMenuAccessible)
                return AccessDeniedView();
            var nurse = new NurseModel();
            nurse.NurseDocuments = new List<NurseDocuments>();

            return View(nurse);
        }

        // POST: Nurse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //Bhawana (2/10/2019)
        [HttpPost("CreateNurse")]
        public IActionResult CreateNurse(NurseModel model)
        {//10/10/2019 aakansha
            ViewBag.FormName = "Nurse";
            if (!(bool)SharedData.isNurseMenuAccessible)
                return AccessDeniedView();
            Customer customer = null;

            CustomerPassword password = null;
            if (model.Id == 0)
            {
                if (!string.IsNullOrWhiteSpace(model.BillingAddress.Email))
                {
                    model.Phone = model.BillingAddress.PhoneNumber;
                    customer = _customerServices.GetCustomerByEmail(model.BillingAddress.Email);
                    if (customer != null)
                    {
                        if (model.Id == 0)
                        {
                            AddNotification(NotificationMessage.TitleError, NotificationMessage.Emailisalreadyregistered, NotificationMessage.TypeError);
                            return RedirectToAction("Create");
                        }
                    }
                }
                //Address Data 
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
                //Inser Nurse Data In User Table
                customer = new Customer();


                customer.CustomerGuid = Guid.NewGuid();
                customer.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                customer.Username = _encryptionService.EncryptText(model.BillingAddress.Email);
                var nurseRoleData = _customerServices.GetAllCustomerRoles().Where(a => a.Name == "Nurse").FirstOrDefault();
                customer.CustomerRoleId = nurseRoleData.Id;
                customer.Active = true;
                customer.CreatedOnUtc = DateTime.UtcNow;
                customer.LastActivityDateUtc = DateTime.UtcNow;


                _customerServices.InsertCustomer(customer);
                //customer.CustomerRoles.Add();
                customer.Addresses.Add(Baddress);
                customer.BillingAddress = Baddress;
                _customerServices.UpdateCustomer(customer);
                // password
                if (!string.IsNullOrWhiteSpace(model.CustomerPassword.Password))
                {
                    password = new CustomerPassword
                    {
                        CustomerId = customer.Id,
                        Password = model.CustomerPassword.Password,
                        CreatedOnUtc = DateTime.UtcNow,
                        //default passwordFormat
                        PasswordFormat = PasswordFormat.Clear

                    };
                    _customerpasswordservice.InsertCustomerPassword(password);
                }
                //General Data
                var data = new NurseMaster();

                data.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                data.UserId = customer.Id;
                data.FirstName = _encryptionService.EncryptText(model.BillingAddress.FirstName);
                data.LastName = _encryptionService.EncryptText(model.BillingAddress.LastName);
                data.CreatedOn = DateTime.UtcNow;
                data.Deleted = false;

                _nurseServices.InsertNurse(data);
                return Json(data.Id);
            }
            else
            {

                var data = _nurseServices.GetNurseById(model.Id);
                customer = _customerServices.GetCustomerById((int)data.UserId);
                //Address Data 
                var Baddress = _addressservice.GetAddressById(customer.BillingAddress.Id);
                Baddress.FirstName = _encryptionService.EncryptText(model.BillingAddress.FirstName);
                Baddress.LastName = _encryptionService.EncryptText(model.BillingAddress.LastName);
                Baddress.PhoneNumber = _encryptionService.EncryptText(model.BillingAddress.PhoneNumber);
                Baddress.StateProvince = _encryptionService.EncryptText(model.BillingAddress.StateProvince);
                Baddress.ZipPostalCode = _encryptionService.EncryptText(model.BillingAddress.ZipPostalCode);
                Baddress.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                Baddress.City = _encryptionService.EncryptText(model.BillingAddress.City);
                Baddress.Address1 = _encryptionService.EncryptText(model.BillingAddress.Address1);
                Baddress.Address2 = _encryptionService.EncryptText(model.BillingAddress.Address2);
                //Update address
                _addressservice.UpdateAddress(Baddress);
                //Inser Nurse Data In User Table

                customer.CustomerGuid = Guid.NewGuid();
                customer.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                customer.Username = _encryptionService.EncryptText(model.BillingAddress.Email);
                var nurseRoleData = _customerServices.GetAllCustomerRoles().Where(a => a.Name == "Nurse").FirstOrDefault();
                customer.CustomerRoleId = nurseRoleData.Id;
                customer.Active = true;
                customer.CreatedOnUtc = DateTime.UtcNow;
                customer.LastActivityDateUtc = DateTime.UtcNow;

                _customerServices.UpdateCustomer(customer);

                // password
                if (!string.IsNullOrWhiteSpace(model.CustomerPassword.Password))
                {
                    password = _customerpasswordservice.GetPasswordByCustomerId((int)data.UserId);
                    password.Password = model.CustomerPassword.Password;
                    _customerpasswordservice.UpdatePassword(password);
                }
                //Genereal Data
                data.Email = _encryptionService.EncryptText(model.BillingAddress.Email);
                data.FirstName = _encryptionService.EncryptText(model.BillingAddress.FirstName);
                data.LastName = _encryptionService.EncryptText(model.BillingAddress.LastName);
                data.Deleted = false;
                data.LastUpdated = DateTime.UtcNow;
                _nurseServices.UpdateNurse(data);
                return Json(data.Id);
            }


        }


        // GET: Nurse/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.FormName = "Nurse";
            var nursedata = _nurseServices.GetNurseById(id);
            var model = nursedata.ToModel();
            var userData = _customerServices.GetCustomerById((int)nursedata.UserId);
            model.BillingAddress = new AddressModel
            {
                Id = userData.BillingAddress.Id,
                Address1 = _encryptionService.DecryptText(userData.BillingAddress.Address1),
                Address2 = _encryptionService.DecryptText(userData.BillingAddress.Address2),
                City = _encryptionService.DecryptText(userData.BillingAddress.City),
                Email = _encryptionService.DecryptText(userData.BillingAddress.Email),
                FirstName = _encryptionService.DecryptText(userData.BillingAddress.FirstName),
                LastName = _encryptionService.DecryptText(userData.BillingAddress.LastName),
                PhoneNumber = _encryptionService.DecryptText(userData.BillingAddress.PhoneNumber),
                StateProvince = _encryptionService.DecryptText(userData.BillingAddress.StateProvince),
                ZipPostalCode = _encryptionService.DecryptText(userData.BillingAddress.ZipPostalCode)
            };
            model.CustomerPassword = _customerpasswordservice.GetPasswordByCustomerId(userData.Id);

            return View(model);
        }
        //Partial View Nurse Documents

        [HttpPost]
        public IActionResult NurseDocuments(int NurseId)
        {
            var model = _nurseServices.GetNurseById(NurseId);

            return PartialView("_NurseDocuments", model.NurseDocuments);
        }


        [HttpPost]
        public IActionResult UploadNurseDocument()
        {//10/10/2019 aakansha
            ViewBag.FormName = "Nurse";
            var formData = this.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            String[] documentTypeId = formData["DocumentTypeId"].Split(",");
            String[] NurseMasterId = formData["NurseMasterId"].Split(",");


            var data = _nurseServices.GetNurseById(Convert.ToInt32(NurseMasterId[0]));

            // Checking no of files injected in Request object  
            if (Request.Form.Files.Count > 0)
            {
                var documentFile = Request.Form.Files[0];
                try
                {
                    if (documentFile != null)
                    {
                        string saveFilePath = _hostingEnvironment.WebRootPath + "\\NurseDocuments";

                        var filePath = Path.Combine(saveFilePath, documentFile.FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            documentFile.CopyToAsync(fileStream);
                        }
                        data.NurseDocuments.Add(new NurseDocuments()
                        {
                            DocumentTypeId = Convert.ToInt32(documentTypeId[0]),
                            Document = documentFile.FileName,
                            NurseMasterId = Convert.ToInt32(NurseMasterId[0])
                        });
                        _nurseServices.UpdateNurse(data);
                        //16/09/19 aakansha
                        var model = new DownloadHistory();
                        model.DownloadDateTime = DateTime.UtcNow;
                        model.DocumentName = Path.GetFileName(filePath);

                        model.DocumentPath = filePath;
                        model.DocumentFormat = Path.GetExtension(filePath);
                        model.DocumentType = "NurseDocuments";
                        model.ProcessTypeId = (int)ProcessType.Upload;
                        model.UserId = _workContext.CurrentCustomer.Id;
                        _companyProfileService.InsertDownloadHistory(model);
                        return Json(data.Id);
                    }
                }
                catch (Exception ex)
                {
                    return Json(data.Id);
                }
            }
            else
            {
                return Json(data.Id);
            }
            return Json(data.Id);
        }


        //Download Nurse Documents
        public FileResult DownloadNurseDocument(int NurseMasterId, int DocumentId)
        {//10/10/2019 aakansha
            ViewBag.FormName = "Nurse";
            var data = _nurseServices.GetNurseById(NurseMasterId);
            var document = data.NurseDocuments.Where(a => a.Id == DocumentId).FirstOrDefault();

            string filePath = _hostingEnvironment.WebRootPath + "\\NurseDocuments\\" + document.Document;
            string fileName = document.Document;
            //filePath = $"{this.Request.Host}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //16/09/19 aakansha
            var model = new DownloadHistory();
            model.DownloadDateTime = DateTime.UtcNow;
            model.DocumentName = Path.GetFileName(filePath);

            model.DocumentPath = filePath;
            model.DocumentFormat = Path.GetExtension(filePath);
            model.DocumentType = "NurseDocuments";
            model.ProcessTypeId = (int)ProcessType.Download;
            model.UserId = _workContext.CurrentCustomer.Id;
            _companyProfileService.InsertDownloadHistory(model);

            return File(fileBytes, "application/force-download", fileName);
        }

        [HttpPost]
        public IActionResult DeleteNurseDocument(int NurseMasterId, int DocumentId)
        {
            ViewBag.FormName = "Nurse";
            var data = _nurseServices.GetNurseById(NurseMasterId);
            var document = data.NurseDocuments.Where(a => a.Id == DocumentId).FirstOrDefault();

            string filePath = _hostingEnvironment.WebRootPath + "\\NurseDocuments\\" + document.Document;
            string fileName = document.Document;
            //filePath = $"{this.Request.Host}";
            System.IO.File.Delete(filePath);
            data.NurseDocuments.Remove(document);
            _nurseServices.UpdateNurse(data);
            var model = _nurseServices.GetNurseById(NurseMasterId);

            return PartialView("_NurseDocuments", model.NurseDocuments);
        }

        #endregion





        [HttpPost]
        // GET: Nurse/Delete/5
        public virtual IActionResult Delete(int id)
        {
            ResponceModel responceModel = new ResponceModel();
            try
            {

                var nurse = _nurseServices.GetNurseById(id);

                if (nurse != null)
                {
                    //To Check Is it Used In PatientInfo As FK
                    var count = _treatmentRecordservice.GetPatientInfoByNurseId(id).Count();
                    if (count == 0)
                    {
                        _nurseServices.DeleteNurse(nurse);
                        responceModel.Success = true;
                        responceModel.Message = "Deleted.";
                        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgDeleteNurse, NotificationMessage.TypeSuccess);
                        return Json(responceModel);
                    }
                    else
                    {
                        responceModel.Success = false;
                        responceModel.Message = "NotDeleted.";

                        AddNotification(NotificationMessage.TitleError, NotificationMessage.NurseInUser, NotificationMessage.TypeError);
                        return Json(responceModel);
                    }
                }
                else
                {
                    responceModel.Success = false;
                    responceModel.Message = "NotDeleted.";

                    AddNotification(NotificationMessage.TitleError, NotificationMessage.NurseNotFount, NotificationMessage.TypeError);

                    return Json(responceModel);
                }
            }
            catch (Exception e)
            {
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";

                return Json(responceModel);
            }
        }

    }
}