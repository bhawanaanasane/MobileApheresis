using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core;
using CRM.Core.Domain.CompanyProfiles;
using CRM.Core.Domain.Equipments;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.CompanyProfiles;
using CRM.Services.Equipments;

using CRM.Services.Security;

using CRM.Services.TreatmentRecords;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Models.Common;
using MobileAheresisAdmin.Models.Equipments;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    public class EquipmentController : BaseController
    {

        #region Fields
        private readonly IEquipmentServices _equipmentService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IReportService _reportService;
        private readonly IWorkContext _workContext;
        private readonly ICompanyProfileService _companyProfileService;

        private readonly IPermissionService _permissionService;



        private readonly ITreatmentRecordServices _treatmentRecordService;

        #endregion

        #region CTOR
        public EquipmentController(
            IEquipmentServices equipmentService,
              IHostingEnvironment hostingEnvironment,
              IReportService reportService, IWorkContext workContext, 
              ICompanyProfileService CompanyProfileService,

              IPermissionService permissionService,

              ITreatmentRecordServices TreatmentRecordService

            )
        {
            this._equipmentService = equipmentService;
            this._hostingEnvironment = hostingEnvironment;
            this._reportService = reportService;
            this._workContext = workContext;
            this._permissionService = permissionService;
            _companyProfileService = CompanyProfileService;
            this._treatmentRecordService = TreatmentRecordService;
        }

        #endregion

        #region Json Post Methods
        [HttpPost("CreateEquipment")]
        public IActionResult CreateEquipment(EquipmentModel model)
        {

            if (model.Id == 0)
            {
                //General Data
                var data = new Equipment();
                data.MachineName = model.MachineName;
                data.SerialNo = model.SerialNo;
                _equipmentService.InsertEquipment(data);
                return Json(data.Id);
            }
            else
            {

                var data = _equipmentService.GetEquiipmentInfoById((int)model.Id);
                data.MachineName = model.MachineName;
                data.SerialNo = model.SerialNo;
                _equipmentService.Updateequipment(data);
                return Json(data.Id);
            }


        }


        [HttpPost]
        public IActionResult UploadDocument()
        {
            var formData = this.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            String[] EqpDocumentIds = formData["EqpDocumentId"].Split(",");
            String[] EquipmentIds = formData["EquipmentId"].Split(",");


            var data = _equipmentService.GetEquiipmentInfoById(Convert.ToInt32(EquipmentIds[0]));

            // Checking no of files injected in Request object  
            if (Request.Form.Files.Count > 0)
            {
                var documentFile = Request.Form.Files[0];
                try
                {
                    if (documentFile != null)
                    {
                        string saveFilePath = _hostingEnvironment.WebRootPath + "\\EquipmentDocuments";

                        var filePath = Path.Combine(saveFilePath, documentFile.FileName);
                        
                        
                        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            documentFile.CopyToAsync(fileStream);
                        }
                        data.EquipmentDocuments.Add(new EquipmentDocuments()
                        {
                            Document = documentFile.FileName,
                            EqpDocumentId = Convert.ToInt32(EqpDocumentIds[0])
                        });
                        _equipmentService.Updateequipment(data);
                        //16/09/19 aakansha
                        var model = new DownloadHistory();
                        model.DownloadDateTime = DateTime.UtcNow;
                        model.DocumentName = Path.GetFileName(filePath);

                        model.DocumentPath = filePath;
                        model.DocumentFormat = Path.GetExtension(filePath);
                        model.DocumentType = "EquipmentDocuments";
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


        public FileResult DownloadDocument(int EquipmentId, int DocumentId)
        {
            var data = _equipmentService.GetEquiipmentInfoById(EquipmentId);
            var document = data.EquipmentDocuments.Where(a => a.Id == DocumentId).FirstOrDefault();

            string filePath = _hostingEnvironment.WebRootPath + "\\EquipmentDocuments\\" + document.Document;
            string fileName = document.Document;
            //filePath = $"{this.Request.Host}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //16/09/19 aakansha
            var model = new DownloadHistory();
            model.DownloadDateTime = DateTime.UtcNow;
            model.DocumentName = Path.GetFileName(filePath);

            model.DocumentPath = filePath;
            model.DocumentFormat = Path.GetExtension(filePath);
            model.DocumentType = "EquipmentDocuments";
            model.ProcessTypeId = (int)ProcessType.Download;
            model.UserId = _workContext.CurrentCustomer.Id;
            _companyProfileService.InsertDownloadHistory(model);

            return File(fileBytes, "application/force-download", fileName);
        }

        [HttpPost]
        public IActionResult DeleteDocument(int EquipmentId, int DocumentId)
        {
            var data = _equipmentService.GetEquiipmentInfoById(EquipmentId);
            var document = data.EquipmentDocuments.Where(a => a.Id == DocumentId).FirstOrDefault();

            string filePath = _hostingEnvironment.WebRootPath + "\\CompanyDocuments\\" + document.Document;
            string fileName = document.Document;
            //filePath = $"{this.Request.Host}";
            System.IO.File.Delete(filePath);
            data.EquipmentDocuments.Remove(document);
            _equipmentService.Updateequipment(data);
            var model = _equipmentService.GetEquiipmentInfoById(EquipmentId);

            return PartialView("_EquipmentDocuments", model.EquipmentDocuments);
        }


        [HttpPost]
        public IActionResult EquipmentDocuments(int EquipmentId)
        {
            var data = _equipmentService.GetEquiipmentInfoById(EquipmentId);
            return PartialView("_EquipmentDocuments", data.EquipmentDocuments);
        }


        #endregion

        
        public IActionResult Index(DataSourceRequest command)
        {
            if (!(bool)SharedData.isEquipmentMenuAccessible)
                return AccessDeniedView();
            ViewBag.FormName = "Equipment";
            var model = new EquipmentListModel();

            ViewBag.PageSizeDropdown = SelectListHelper.GetPageSizeDropdown(command.PageSize.ToString());

            var PagedList = _reportService.GetAllEquipments(
                        keywords: "",
                        page_num: command.Page,
                        page_size: command.PageSize,
                        GetAll: command.PageSize == 0 ? true : false
                    );

            model.List = PagedList.List.GetPaged(command.Page, command.PageSize, PagedList.TotalRecords);

            return View(model);
        }


        // GET: CompanyProfile/Create
        public ActionResult Create(int? Id)
        {
            ViewBag.FormName = "Equipment";
            var equipmentModel = new EquipmentModel();

            try
            {

                if (Id != null)
                {
                    var equipmentFromData = _equipmentService.GetEquiipmentInfoById((int)Id);
                    equipmentModel = equipmentFromData.ToModel();
                }
                else
                {
                    equipmentModel.EquipmentDocuments = new List<EquipmentDocuments>();
                   
                }
            }
            catch (Exception ex)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
            }

            return View(equipmentModel);
        }

        // POST: Equipment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ViewBag.FormName = "Equipment";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Equipment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ViewBag.FormName = "Equipment";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Bhawana(3/10/2019)
        // Post: Treatment/DaignosisDelete/5
        [HttpPost]
        public IActionResult EquipmentDelete(int id)
        {
            //permissions
            if (SharedData.isDiagnosisMenuAccessible == false)
                return AccessDeniedView();
            ResponceModel responceModel = new ResponceModel();
            try
            {
                var equipment = _equipmentService.GetEquiipmentInfoById(id);

                if (equipment == null)
                    //No product found with the specified id
                    return RedirectToAction("List");

                var count = _treatmentRecordService.GetMachineInfoByEquipmentId(id).Count();
                if (count == 0)
                {
                    _equipmentService.DeleteEquipment(equipment);
                    responceModel.Success = true;
                    responceModel.Message = "Deleted.";
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgDeleteHospital, NotificationMessage.TypeSuccess);
                    return Json(responceModel);
                }
                else
                {
                    responceModel.Success = false;
                    responceModel.Message = "NotDeleted.";
                    AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrormsgDeleteHospital, NotificationMessage.TypeError);

                    return Json(responceModel);
                }


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