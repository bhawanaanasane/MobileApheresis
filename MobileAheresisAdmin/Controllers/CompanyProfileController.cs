using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core;
using CRM.Core.Domain.Common;
using CRM.Core.Domain.CompanyProfiles;
using CRM.Services.Common;
using CRM.Services.CompanyProfiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAdmin.Models.CompanyProfiles;
using MobileAheresisAdmin.Utils;
using MobileAheresisAdmin.Filters;
using MobileAheresisAdmin.Common;
using DownloadHistory = CRM.Core.Domain.CompanyProfiles.DownloadHistory;
using MobileAheresisAdmin.Models.Common;
using CRM.Services.TreatmentRecords;
using CRM.Services.Security;
using CRM.Services.Common.StoreProcedureServices;

namespace MobileAheresisAdmin.Controllers
{
    //[AuthorizeAdmin]
    public class CompanyProfileController : BaseController
    {
        #region Fields
        private readonly ICompanyProfileService _companyProfileService;
        private readonly IAddressService _addressService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IReportService _reportService;
        private readonly IWorkContext _workContext;
        private readonly ITreatmentRecordServices _treatmentRecordservice;
        private readonly IPermissionService _permissionService;



        #endregion

        #region CTOR
        public CompanyProfileController(
            ICompanyProfileService CompanyProfileService,
            IAddressService addressService,
            IHostingEnvironment hostingEnvironment,
            IReportService reportService,
            IWorkContext workContext,
            ITreatmentRecordServices TreatmentRecordservice,
             IPermissionService permissionService
            )
        {
            this._companyProfileService = CompanyProfileService;
            this._addressService = addressService;
            this._hostingEnvironment = hostingEnvironment;
            this._reportService = reportService;
            this._workContext = workContext;
            this._treatmentRecordservice = TreatmentRecordservice;
            this._permissionService = permissionService;
        }

        #endregion

        #region Json Post Methods
        [HttpPost("CreateGeneral")]
        public IActionResult CreateGeneral(CompanyProfileModel model)
        {
            try
            {

                //address
                var address = _addressService.GetAddressById(model.CompanyAddressId);
                if (address == null)
                {
                    address = model.CompanyAddress;
                    address.CreatedOnUtc = DateTime.UtcNow;

                    _addressService.InsertAddress(address);

                }
                else
                {

                    address.Address1 = model.CompanyAddress.Address1;
                    address.Address2 = model.CompanyAddress.Address2;

                    address.City = model.CompanyAddress.City;
                    address.ZipPostalCode = model.CompanyAddress.ZipPostalCode;
                    address.FirstName = model.CompanyAddress.FirstName;
                    address.LastName = model.CompanyAddress.LastName;
                    address.Email = model.CompanyAddress.Email;


                    _addressService.UpdateAddress(address);
                }
                if (model.Id == 0)
                {
                    //General Data
                    var data = new CompanyProfile();

                    data.Email = model.CompanyAddress.Email;

                    data.License = model.License;
                    data.CreatedOnUtc = DateTime.UtcNow;
                    data.CompanyAddress = address;
                    data.CompanyAddressId = address.Id;
                    data.Companyname = model.Companyname;
                    _companyProfileService.InsertCompanyProfile(data);


                    return Json(data.Id);
                }
                else
                {

                    var data = _companyProfileService.GetCompanyProfileById((int)model.Id);

                    data.Email = model.CompanyAddress.Email;

                    data.License = model.License;
                    data.CreatedOnUtc = DateTime.UtcNow;
                    data.CompanyAddress = address;
                    data.Companyname = model.Companyname;
                    _companyProfileService.UpdateCompanyProfile(data);
                    return Json(data.Id);
                }
            }
            catch (Exception e) {
                return View();
            }


        }

        [HttpPost("CreatePolicyAndProcedure")]
        public IActionResult CreatePolicyAndProcedure(PolicyAndProcedure model)
        {
            var data = _companyProfileService.GetCompanyProfileById(model.CompanyProfileId);
            data.PoliciesAndProcedures.Add(new PolicyAndProcedure()
            {
                Text = model.Text,
                IsPolicy = model.IsPolicy

            });
            _companyProfileService.UpdateCompanyProfile(data);

            
            return Json(data.Id);
        }


       
        //[HttpPost("UploadCompanyDocument")]
        //public IActionResult UploadCompanyDocument(IFormFile documentFile, CompanyDocument model)
        //{
        //    var data = _companyProfileService.GetCompanyProfileById(model.CompanyProfileId);

        //    if (documentFile != null)
        //    {
        //        string saveFilePath = _hostingEnvironment.WebRootPath + "\\CompanyDocuments";

        //        var filePath = Path.Combine(saveFilePath, documentFile.FileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
        //        {
        //            documentFile.CopyToAsync(fileStream);
        //        }
        //        data.CompanyDocuments.Add(new CompanyDocument()
        //        {
        //            DocumentName = model.DocumentName,
        //            DocumentPath = documentFile.FileName
        //        });
        //        _companyProfileService.UpdateCompanyProfile(data);
        //        return Json(data.Id);
        //    }
        //    return Json(data.Id);
        //}

        [HttpPost]
        public IActionResult UploadCompanyDocument()
        {
            var formData = this.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            String[] documentName = formData["DocumentName"].Split(",");
            String[] CompanyProfileIds = formData["CompanyProfileId"].Split(",");


            var data = _companyProfileService.GetCompanyProfileById(Convert.ToInt32(CompanyProfileIds[0]));

            // Checking no of files injected in Request object  
            if (Request.Form.Files.Count > 0)
            {
                var documentFile = Request.Form.Files[0];
                try
                {
                    if (documentFile != null)
                    {
                        string saveFilePath = _hostingEnvironment.WebRootPath + "\\CompanyDocuments";

                        var filePath = Path.Combine(saveFilePath, documentFile.FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            documentFile.CopyToAsync(fileStream);
                        }
                        data.CompanyDocuments.Add(new CompanyDocument()
                        {
                            DocumentName = documentName[0].ToString(),
                            DocumentPath = documentFile.FileName
                        });
                        _companyProfileService.UpdateCompanyProfile(data);
                        //16/09/19 aakansha
                        var model = new DownloadHistory();
                        model.DownloadDateTime = DateTime.UtcNow;
                        model.DocumentName = Path.GetFileName(filePath);

                        model.DocumentPath = filePath;
                        model.DocumentFormat = Path.GetExtension(filePath);
                        model.DocumentType = "CompanyDocuments";
                        model.ProcessTypeId = (int)ProcessType.Upload;
                        model.UserId = _workContext.CurrentCustomer.Id;
                        _companyProfileService.InsertDownloadHistory(model);
                       

                        return Json(data.Id);
                    }
                }
                catch (Exception ex)
                {
                    AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                    return Json(data.Id);
                }
            }
            else
            {

                return Json(data.Id);
            }
            return Json(data.Id);
        }

   
        public FileResult DownloadCompanyDocument(int CompanyProfileId, int DocumentId)
        {
            var data = _companyProfileService.GetCompanyProfileById(CompanyProfileId);
            var document = data.CompanyDocuments.Where(a => a.Id == DocumentId).FirstOrDefault();

            string filePath = _hostingEnvironment.WebRootPath + "\\CompanyDocuments\\" + document.DocumentPath;
            string fileName = document.DocumentPath;
            //filePath = $"{this.Request.Host}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //13/09/19 aakansha
            var model = new DownloadHistory();
            model.DownloadDateTime = DateTime.UtcNow;
            model.DocumentName = Path.GetFileName(filePath);

            model.DocumentPath = filePath;
            model.DocumentFormat = Path.GetExtension(filePath);
            model.DocumentType = "CompanyDocuments";
              model.ProcessTypeId = (int)ProcessType.Upload;
            model.UserId = _workContext.CurrentCustomer.Id;
            _companyProfileService.InsertDownloadHistory(model);
            

            return File(fileBytes, "application/force-download", fileName);
        }

        [HttpPost]
        public IActionResult DeleteCompanyDocument(int CompanyProfileId, int DocumentId)
        {
            var data = _companyProfileService.GetCompanyProfileById(CompanyProfileId);
            var document = data.CompanyDocuments.Where(a => a.Id == DocumentId).FirstOrDefault();

            string filePath = _hostingEnvironment.WebRootPath + "\\CompanyDocuments\\" + document.DocumentPath;
            string fileName = document.DocumentPath;
            //filePath = $"{this.Request.Host}";
             System.IO.File.Delete(filePath);
            data.CompanyDocuments.Remove(document);
            _companyProfileService.UpdateCompanyProfile(data);
            var model = _companyProfileService.GetCompanyProfileById(CompanyProfileId);
            

            return PartialView("_CompanyDocuments", model.CompanyDocuments);
        }


        [HttpPost]
        public IActionResult PoliciesAndProcedures(int CompanyProfileId)
        {
            var model = _companyProfileService.GetCompanyProfileById(CompanyProfileId);

            return PartialView("_PoliciesAndProcedures", model.PoliciesAndProcedures);
        }


        [HttpPost]
        public IActionResult CompanyDocuments(int CompanyProfileId)
        {
            var model = _companyProfileService.GetCompanyProfileById(CompanyProfileId);

            return PartialView("_CompanyDocuments", model.CompanyDocuments);
        }

        #endregion


        public IActionResult Index(DataSourceRequest command)
        {
            if (!(bool)SharedData.isCompanyProfileMenuAccessible)
                return AccessDeniedView();
            ViewBag.FormName = "CompanyProfile";
            var model = new CompanyProfileListModel();

            ViewBag.PageSizeDropdown = SelectListHelper.GetPageSizeDropdown(command.PageSize.ToString());

            var PagedList = _reportService.GetAllCompanyProfiles(
                        keywords: "",
                        page_num: command.Page,
                        page_size: command.PageSize,
                        GetAll: command.PageSize == 0 ? true : false
                    );

            model.List = PagedList.List.GetPaged(command.Page, command.PageSize, PagedList.TotalRecords);
            return View(model);
     }


        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            //10/10/2019 aakansha
            ViewBag.FormName = "CompanyProfile";
            var companyProfile = new CompanyProfileModel();

            try
            {

               
                    var companyProfileFrom = _companyProfileService.GetAllCompanyProfile();
                if(companyProfileFrom != null) { 
                    companyProfile = companyProfileFrom.ToModel();
                   
                    //16/09/19 aakansha
                    var DownloadHistoryListData = _companyProfileService.GetAllDownloadHistory();
                    var downloadhistory = DownloadHistoryListData.Select(a =>
                     new DownloadHistoryModel
                     {
                         DocFormat = a.DocumentFormat,
                         DocType = a.DocumentType,
                         DocName = a.DocumentName,
                         DownloadDateTime = a.DownloadDateTime,
                         UserId = a.UserId,
                         ProcessTypeId = a.ProcessTypeId,
                         ProcessType = (ProcessType)a.ProcessTypeId

                     }).ToList();
                    if (downloadhistory.Count() != 0)
                    {
                        companyProfile.DownloadHistoryList = downloadhistory;
                    }
                    return View(companyProfile);
                }
               

            }
            catch (Exception ex)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
            }

            return View(companyProfile);
        }


        // POST: CompanyProfile/Delete/5
        [HttpPost]
       
        public ActionResult Delete(int id)
        {
            ResponceModel responceModel = new ResponceModel();
            try
            {

                var companyProfileData = _companyProfileService.GetCompanyProfileById(id);

                if (companyProfileData != null)
                {
                    bool IsProcedureIdUsed = false;
                    foreach (var data in companyProfileData.PoliciesAndProcedures.Where(a=>a.IsPolicy == false))
                    {
                        //To Check Is it Used In PatientInfo As FK
                        var count = _treatmentRecordservice.GetPatientInfoByProcedureId(data.Id).Count();
                        if (count != 0)
                        {
                            IsProcedureIdUsed = true;
                        }
                       
                    }
                    if (!IsProcedureIdUsed)
                    {
                        _companyProfileService.DeleteCompanyProfile(companyProfileData);
                        responceModel.Success = true;
                        responceModel.Message = "Deleted.";
                        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgDeleteCompanyProfile, NotificationMessage.TypeSuccess);
                        return Json(responceModel);
                    }
                    else
                    {
                        responceModel.Success = false;
                        responceModel.Message = "NotDeleted.";

                        AddNotification(NotificationMessage.TitleError, NotificationMessage.CompanyProfileInUse, NotificationMessage.TypeError);
                        return Json(responceModel);
                    }
                }
                else
                {
                    responceModel.Success = false;
                    responceModel.Message = "NotDeleted.";

                    AddNotification(NotificationMessage.TitleError, NotificationMessage.CompanyProfileNotFount, NotificationMessage.TypeError);

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