using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.Common;
using CRM.Core.Domain.Hospitals;
using CRM.Services.Common;
using CRM.Services.Hospitals;

using CRM.Services.Security;

using CRM.Services.TreatmentRecords;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Models.Addresses;
using MobileAheresisAdmin.Models.Common;
using MobileAheresisAdmin.Models.Hospitals;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    public class HospitalController : BaseController
    {
        #region Fields

        private readonly IHospitalServices _hospitalServices;
        private readonly IAddressService _addressService;
        private readonly IPermissionService _permissionService;
        private readonly ITreatmentRecordServices _treatmentRecordService;
        private readonly IEncryptionService _encryptionService;
        #endregion

        #region CTOR  

        public HospitalController(IHospitalServices HospitalServices,
            IAddressService AddressService,
            ITreatmentRecordServices TreatmentRecordService,
            IPermissionService permissionService, IEncryptionService encryptionService)
        {
            this._hospitalServices = HospitalServices;
            this._addressService = AddressService;
            this._treatmentRecordService = TreatmentRecordService;
            this._permissionService = permissionService;
            this._encryptionService = encryptionService;
        }
        #endregion

        #region Utilites
        protected virtual void PrepareHospitalAddressModel(HospitalModel model, HospitalMaster customer, bool excludeProperties, bool prepareEntireAddressModel)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var address = _addressService.GetAddressById(customer.HospitalAddress != null ? customer.HospitalAddress.Id : 0);
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
                        model.HospitalAddress = Baddress;
                    }
                }
            }
        }
        #endregion
        // GET: Hospital
        public IActionResult Index()
        {
            if (!(bool)SharedData.isHospitalMenuAccessible)
                return AccessDeniedView();
            ViewBag.FormName = "Hospital";
            var hospitaldata = _hospitalServices.GetAllHospital();
            var hospitalaList = hospitaldata.Select(a =>
            new HospitalModel()
            {
                ContactPerson = _encryptionService.DecryptText(a.ContactPerson),
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                HospitalName = _encryptionService.DecryptText(a.HospitalName),    //pratiksha get hospital name in Decrypt format 28/nov/2019
                Id = a.Id,
                LastUpdated = a.LastUpdated
            });
            var hospitalListData = new HospitalListModel();
            hospitalListData.hospitalList = hospitalaList.ToList();
            return View(hospitalListData);
        }

        // GET: Hospital/Create
        public ActionResult Create()
        {//10/10/2019 aakansha
            ViewBag.FormName = "Hospital";
            var model = new HospitalModel();
            return View(model);
        }

        // POST: Hospital/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HospitalModel model)
        {
            ViewBag.FormName = "Hospital :#";
            //permissions
            if (SharedData.isHospitalMenuAccessible == false)
                return AccessDeniedView();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        var Baddress = new Address();
                        //pratiksha post hospital name in Encrypt format 28/nov/2019
                        Baddress.FirstName = _encryptionService.EncryptText(model.HospitalAddress.FirstName);
                        Baddress.LastName = _encryptionService.EncryptText(model.HospitalAddress.LastName);
                        Baddress.Email = _encryptionService.EncryptText(model.HospitalAddress.Email);
                        Baddress.PhoneNumber = _encryptionService.EncryptText(model.HospitalAddress.PhoneNumber);
                        Baddress.StateProvince = _encryptionService.EncryptText(model.HospitalAddress.StateProvince);
                        Baddress.ZipPostalCode = _encryptionService.EncryptText(model.HospitalAddress.ZipPostalCode);
                        Baddress.City = _encryptionService.EncryptText(model.HospitalAddress.City);
                        Baddress.Address1 = _encryptionService.EncryptText(model.HospitalAddress.Address1);
                        Baddress.Address2 = _encryptionService.EncryptText(model.HospitalAddress.Address2);
                        Baddress.CreatedOnUtc = DateTime.UtcNow;

                        var hospital = new HospitalMaster();
                        hospital.HospitalName = _encryptionService.EncryptText(model.HospitalName);
                        hospital.ContactPerson = _encryptionService.EncryptText(model.ContactPerson);
                        hospital.Deleted = false;
                        hospital.CreatedOn = DateTime.UtcNow;
                        hospital.LastUpdated = DateTime.UtcNow;

                        _hospitalServices.InsertHospital(hospital);
                        //customer.CustomerRoles.Add();
                        hospital.HospitalAddress = Baddress;
                        _hospitalServices.UpdateHospital(hospital);

                    }
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddHospital, NotificationMessage.TypeSuccess);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return RedirectToAction("CreateUserCustomer");
            }
        }

        // GET: Hospital/Edit/5
        public IActionResult Edit(int id)
        {//10/10/2019 aakansha
            ViewBag.FormName = "Hospital:#" + id;
            //permissions
            if (SharedData.isHospitalMenuAccessible == false)
                return AccessDeniedView();

            var hospital = _hospitalServices.GetHospitalById(id);
            //var address = _addressService.GetAddressById(id);
            var model = new HospitalModel
            {
                HospitalName = _encryptionService.DecryptText(hospital.HospitalName),//pratiksha gethospital name in Decrypt format 28/nov/2019 
                ContactPerson = _encryptionService.DecryptText(hospital.ContactPerson),
                Deleted = false,
                LastUpdated = DateTime.UtcNow,
            };
            PrepareHospitalAddressModel(model, hospital, false, true);

            return View(model);
        }

        // POST: Hospital/Edit/5
        [HttpPost]


        public IActionResult Edit(HospitalModel model)
        {
            ViewBag.FormName = "Hospital :#" + model.Id;
            //permissions
            if (SharedData.isHospitalMenuAccessible == false)
                return AccessDeniedView();
            try
            {
                var hospital = _hospitalServices.GetHospitalById(model.Id);
                if (hospital == null || hospital.Deleted)
                    //No vendor found with the specified id
                    return RedirectToAction("UserCustomerList");
                if (ModelState.IsValid)
                {
                    hospital.HospitalName = _encryptionService.EncryptText(model.HospitalName);//pratiksha post hospital name in Encrypt format 28/nov/2019
                    hospital.ContactPerson = _encryptionService.EncryptText(model.ContactPerson);
                    hospital.Deleted = false;
                    hospital.CreatedOn = DateTime.UtcNow;
                    hospital.LastUpdated = DateTime.UtcNow;

                    _hospitalServices.UpdateHospital(hospital);

                    //address
                    var address = _addressService.GetAddressById(hospital.HospitalAddress.Id);
                    if (address == null)
                    {
                        address.FirstName = _encryptionService.EncryptText(model.HospitalAddress.FirstName);
                        address.LastName = _encryptionService.EncryptText(model.HospitalAddress.LastName);
                        address.PhoneNumber = _encryptionService.EncryptText(model.HospitalAddress.PhoneNumber);
                        address.StateProvince = _encryptionService.EncryptText(model.HospitalAddress.StateProvince);
                        address.ZipPostalCode = _encryptionService.EncryptText(model.HospitalAddress.ZipPostalCode);
                        address.Email = _encryptionService.EncryptText(model.HospitalAddress.Email);
                        address.City = _encryptionService.EncryptText(model.HospitalAddress.City);
                        address.Address1 = _encryptionService.EncryptText(model.HospitalAddress.Address1);
                        address.Address2 = _encryptionService.EncryptText(model.HospitalAddress.Address2);
                        _addressService.InsertAddress(address);
                        // customer.Id = address.Id;

                        _hospitalServices.UpdateHospital(hospital);
                    }
                    else
                    {
                        address.FirstName = _encryptionService.EncryptText(model.HospitalAddress.FirstName);
                        address.LastName = _encryptionService.EncryptText(model.HospitalAddress.LastName);
                        address.PhoneNumber = _encryptionService.EncryptText(model.HospitalAddress.PhoneNumber);
                        address.StateProvince = _encryptionService.EncryptText(model.HospitalAddress.StateProvince);
                        address.ZipPostalCode = _encryptionService.EncryptText(model.HospitalAddress.ZipPostalCode);
                        address.Email = _encryptionService.EncryptText(model.HospitalAddress.Email);
                        address.City = _encryptionService.EncryptText(model.HospitalAddress.City);
                        address.Address1 = _encryptionService.EncryptText(model.HospitalAddress.Address1);
                        address.Address2 = _encryptionService.EncryptText(model.HospitalAddress.Address2);

                        _addressService.UpdateAddress(address);
                    }

                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgEditHospital, NotificationMessage.TypeSuccess);
                    return RedirectToAction("Index", "Hospital");
                }
                else
                {
                    PrepareHospitalAddressModel(model, hospital, false, true);
                    return View(model);
                }
            }
            catch (Exception e)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return RedirectToAction("Edit", "Hospital", model.Id);
            }
        }

        //Bhawana (3/10/2019)
        [HttpPost]
        //1/10/19 aakansha

        // Post: Hospital/Delete/5
        public virtual IActionResult Delete(int id)
        {
            ResponceModel responceModel = new ResponceModel();
            try
            {
                var hospital = _hospitalServices.GetHospitalById(id);
                if (hospital == null)
                    //No product found with the specified id
                    return RedirectToAction("List");
                if (hospital != null)
                {
                    var count = _treatmentRecordService.GetPatientInfoByHospitalId(id).Count();
                    if (count == 0)
                    {
                        _hospitalServices.DeleteHospital(hospital);
                        responceModel.Success = true;
                        responceModel.Message = "Deleted.";
                        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgDeleteHospital, NotificationMessage.TypeSuccess);
                        return Json(responceModel);
                    }
                    else
                    {
                    }
                }
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrormsgDeleteHospital, NotificationMessage.TypeError);
                return Json(responceModel);
            }
            catch (Exception e)
            {
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrormsgDeleteHospital, NotificationMessage.TypeError);
                return Json(responceModel);
            }
        }
    }
}