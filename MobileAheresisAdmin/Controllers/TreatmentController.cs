using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.TreatmentMaster;
using CRM.Services.Security;
using CRM.Services.Treatements;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Models.Common;
using MobileAheresisAdmin.Models.Treatments;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    public class TreatmentController : BaseController
    {
        #region Fields
        private readonly ITreatmentServices _treatmentServices;

        private readonly IPermissionService _permissionService;
 private readonly ITreatmentRecordServices _treatmentRecordService;
        #endregion

  
        #region CTOR
        public TreatmentController(ITreatmentServices TreatmentServices,
            ITreatmentRecordServices TreatmentRecordService, IPermissionService permissionService) {
            this._treatmentServices = TreatmentServices;
            this._permissionService = permissionService;
            this._treatmentRecordService = TreatmentRecordService;

        }
        #endregion

        #region Utilities
        protected virtual void PrepareCommentTypeDataModel(AutoTextModel model)
        {
            model.AvailableComments.Add(new SelectListItem { Text = "Select Comment", Value = "0" });

            foreach (var c in _treatmentServices.GetAllCommentType())
            {
                model.AvailableComments.Add(new SelectListItem
                {
                    Text = c.CommentTypeName,
                    Value = c.Id.ToString(),
                    Selected = c.Id == model.Id
                });
            }

        }
        #endregion

        #region Daignosis

        // GET: Treatment
        public IActionResult DaignosisIndex()
        {
            if (!(bool)SharedData.isDiagnosisMenuAccessible)
                return AccessDeniedView();
            //10/10/2019 aakansha
            ViewBag.FormName = "Diagnosis";
            var data = _treatmentServices.GetAllDiagnosis();
            var daignosisData = data.Select(a =>
            new DiagnosisModel
            {
                IsActive = a.IsActive,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                Description = a.Description,
                DiagnosisName = a.DiagnosisName,
                Id = a.Id,
                LastUpdated = a.LastUpdated
            });
            var DiagnosisList = new DiagnosisListModel();
            DiagnosisList.diagnosisList = daignosisData.ToList();
            return View(DiagnosisList);
        }

      
        // GET: Treatment/DaignosisDetails/5
        public ActionResult DaignosisDetails(int id)
        {
            return View();
        }

        // GET: Treatment/DaignosisCreate
        public ActionResult DaignosisCreate(int? Id)
        {//10/10/2019 aakansha
            ViewBag.FormName = "Daignosis";
            var model = new DiagnosisModel();
            if (Id == 0)
            {
                
                return View(model);
            }
            else
            {               
                var data = _treatmentServices.GetDiagnosisById((int)Id);
                model.CreatedOn = data.CreatedOn;
                model.Deleted  = data.Deleted;
                model.Description = data.Description;
                model.DiagnosisName = data.DiagnosisName;
                model.Id = data.Id;
                model.IsActive = data.IsActive;
                model.LastUpdated = data.LastUpdated;               
                return View(model);
            }
        }

        // POST: Treatment/DaignosisCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DaignosisCreate(DiagnosisModel model)
        {
            try
            {
                //10/10/2019 aakansha
                ViewBag.FormName = "Daignosis";
                if (model.Id == 0)
                {
                    //General Data
                    var data = new Diagnosis();

                    data.CreatedOn = model.CreatedOn;
                    data.Deleted = model.Deleted;
                    data.Description = model.Description;
                    data.DiagnosisName = model.DiagnosisName;
                  
                    data.IsActive = model.IsActive;
                    data.LastUpdated = model.LastUpdated;
                    _treatmentServices.InsertDiagnosis(data);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddDiagnosis, NotificationMessage.TypeSuccess);
                    return RedirectToAction("DaignosisIndex");
                  

                   
                }
                else
                {

                    var data = _treatmentServices.GetDiagnosisById((int)model.Id);

                    data.CreatedOn = model.CreatedOn;
                    data.Deleted = model.Deleted;
                    data.Description = model.Description;
                    data.DiagnosisName = model.DiagnosisName;
                    data.Id = model.Id;
                    data.IsActive = model.IsActive;
                    data.LastUpdated = model.LastUpdated;
                    _treatmentServices.UpdateDiagnosis(data);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddDiagnosis, NotificationMessage.TypeSuccess);

                    return RedirectToAction("DaignosisIndex");
                }
            }
            catch
            {
                return View(model);
            }
        }


        //Bhawana(3/10/2019)
        // Post: Treatment/DaignosisDelete/5
        [HttpPost]
        public IActionResult DaignosisDelete(int id)
        {
            //permissions
            if (SharedData.isDiagnosisMenuAccessible == false)
                return AccessDeniedView();
            ResponceModel responceModel = new ResponceModel();
            try
            {


                var daignosis = _treatmentServices.GetDiagnosisById(id);

                if (daignosis == null)
                    //No product found with the specified id
                    return RedirectToAction("List");
               
                    var count = _treatmentRecordService.GetPatientInfoByHospitalId(id).Count();
                    if (count == 0)
                    {
                        _treatmentServices.DeleteDiagnosis(daignosis);
                        responceModel.Success = true;
                        responceModel.Message = "Deleted.";
                        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgDeleteHospital, NotificationMessage.TypeSuccess);
                        return Json(responceModel);
                    }
                    else
                {
                    responceModel.Success = false;
                    responceModel.Message = "NotDeleted.";
                    AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);

                    return Json(responceModel);
                }
                
               
            }
            catch (Exception e)
            {
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);

                return Json(responceModel);
            }
        }


        #endregion

        #region AutoText
        // GET: Treatment
        public ActionResult AutoTextIndex()
        {//10/10/2019 aakansha
            ViewBag.FormName = "AutoText";
            var data = _treatmentServices.GetAllAutoText();
            var autoTextData = data.Select(a =>
            new AutoTextModel
            {
                IsActive = a.IsActive,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                AutoTextName = a.AutoTextName,
                Comment = a.Comment,
                CommentTypeId = a.CommentTypeId,
                CommentTypeName = (a.CommentTypeId != 0)?_treatmentServices.GetCommentTypeById(a.CommentTypeId).CommentTypeName:"",
                Id = a.Id,
                LastUpdated = a.LastUpdated
            });
            var AutoTextList = new AutoTextListModel();
            AutoTextList.autoTextList = autoTextData.ToList();
            return View(AutoTextList);
        }

        

        // GET: Treatment/Create
        public ActionResult AutoTextCreate(int? Id)
        {//10/10/2019 aakansha
            ViewBag.FormName = "AutoText";
            var model = new AutoTextModel();
           
            if (Id == 0)
            {

                PrepareCommentTypeDataModel(model);
                return View(model);
            }
            else
            {
                var data = _treatmentServices.GetAutoTextById((int)Id);
                model.CreatedOn = data.CreatedOn;
                model.Deleted = data.Deleted;
                model.CommentTypeId = data.CommentTypeId;
                model.AutoTextName = data.AutoTextName;
                model.Comment = data.Comment;
                model.Id = data.Id;
                model.IsActive = data.IsActive;
                model.LastUpdated = data.LastUpdated;
                PrepareCommentTypeDataModel(model);
                AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddAutoText, NotificationMessage.TypeSuccess);
                return View(model);
            }
           
        }

        // POST: Treatment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AutoTextCreate(AutoTextModel model)
        {
            try
            {//10/10/2019 aakansha
                ViewBag.FormName = "AutoText";
                if (model.Id == 0)
                {
                    //General Data
                    var data = new AutoText();

                    data.CreatedOn = model.CreatedOn;
                    data.Deleted = model.Deleted;
                    data.CommentTypeId = model.CommentTypeId;
                    data.Comment = model.Comment;
                    data.AutoTextName = model.AutoTextName;
                    data.IsActive = model.IsActive;
                    data.LastUpdated = model.LastUpdated;
                    _treatmentServices.InsertAutoText(data);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddAutoText, NotificationMessage.TypeSuccess);
                    return RedirectToAction("AutoTextIndex");
                }
                else
                {

                    var data = _treatmentServices.GetAutoTextById((int)model.Id);

                    data.CreatedOn = model.CreatedOn;
                    data.Deleted = model.Deleted;
                    data.CommentTypeId = model.CommentTypeId;
                    data.Comment = model.Comment;
                    data.AutoTextName = model.AutoTextName;
                    data.IsActive = model.IsActive;
                    data.LastUpdated = model.LastUpdated;
                    data.Id = model.Id;
                    _treatmentServices.UpdateAutoText(data);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddAutoText, NotificationMessage.TypeSuccess);
                    return RedirectToAction("AutoTextIndex");
                }
            }
            catch
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return View();
            }
        }

      

        // POST: Treatment/Delete/5
        public IActionResult AutoTextDelete(int id)
        {
            //permissions
            if (SharedData.isAuto_TextMenuAccessible == false)
                return AccessDeniedView();
            ResponceModel responceModel = new ResponceModel();
            try
            {


                var autoText = _treatmentServices.GetAutoTextById(id);

                if (autoText == null)
                    //No product found with the specified id
                    return RedirectToAction("List");
               
                    var count = _treatmentRecordService.GetPreTreatmentAssessmentByAutoTextId(id).Count();
                    if (count == 0)
                    {
                        _treatmentServices.DeleteAutoText(autoText);
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
            
        #endregion

        #region CommentType
        // GET: Treatment
        public ActionResult CommentTypeIndex()
        {//10/10/2019 aakansha
            ViewBag.FormName = "CommentType";
            var data = _treatmentServices.GetAllCommentType();
            var commentTypeData = data.Select(a =>
            new CommentTypeModel
            {
                IsActive = a.IsActive,
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                CommentTypeName = a.CommentTypeName,
                
                Id = a.Id,
                LastUpdated = a.LastUpdated
            });
            var commentTypeList = new CommentTypeListModel();
            commentTypeList.commentTypes = commentTypeData.ToList();
            return View(commentTypeList);
        }

        // GET: Treatment/Details/5
        public ActionResult CommentTypeDetails(int id)
        {
            return View();
        }

        // GET: Treatment/Create
        public ActionResult CommentTypeCreate(int? Id)
        {//10/10/2019 aakansha
            ViewBag.FormName = "CommentType";
            var model = new CommentTypeModel();
            if (Id == 0)
            {

                return View(model);
            }
            else
            {
                var data = _treatmentServices.GetCommentTypeById((int)Id);
                model.CreatedOn = data.CreatedOn;
                model.Deleted = data.Deleted;
                model.CommentTypeName = data.CommentTypeName;
               
                model.Id = data.Id;
                model.IsActive = data.IsActive;
                model.LastUpdated = data.LastUpdated;
                return View(model);
            }
        }

        // POST: Treatment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentTypeCreate(CommentTypeModel model)
        {
            try
            {//10/10/2019 aakansha
                ViewBag.FormName = "CommentType";
                if (model.Id == 0)
                {
                    //General Data
                    var data = new CommentType();

                    data.CreatedOn = model.CreatedOn;
                    data.Deleted = model.Deleted;
                    data.CommentTypeName = model.CommentTypeName;
                   

                    data.IsActive = model.IsActive;
                    data.LastUpdated = model.LastUpdated;
                    _treatmentServices.InsertCommentType(data);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddCommenttype, NotificationMessage.TypeSuccess);
                    return RedirectToAction("CommentTypeIndex");
                }
                else
                {

                    var data = _treatmentServices.GetCommentTypeById((int)model.Id);

                    data.CreatedOn = model.CreatedOn;
                    data.Deleted = model.Deleted;
                    data.CommentTypeName = model.CommentTypeName;

                    data.Id = model.Id;
                    data.IsActive = model.IsActive;
                    data.LastUpdated = model.LastUpdated;
                    _treatmentServices.UpdateCommentType(data);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgAddCommenttype, NotificationMessage.TypeSuccess);
                    return RedirectToAction("CommentTypeIndex");
                }
            }
            catch
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return View();
            }
        }
        //Bhawana (3/10/2019)
        [HttpPost]
        // Post: Treatment/Delete/5
        public IActionResult CommentTypeDelete(int id)
        {
            //permissions
            if (SharedData.isCommentTypeMenuAccessible == false)
                return AccessDeniedView();
            ResponceModel responceModel = new ResponceModel();
            try
            {


                var commentType = _treatmentServices.GetCommentTypeById(id);

                if (commentType == null)
                    //No product found with the specified id
                    return RedirectToAction("List");
               
                    var count = _treatmentServices.GetAutoTextByCommentTypeId(id).Count();
                    if (count == 0)
                    {
                        _treatmentServices.DeleteCommentType(commentType);
                        responceModel.Success = true;
                        responceModel.Message = "Deleted.";
                        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgDeleteHospital, NotificationMessage.TypeSuccess);
                        return Json(responceModel);
                    }
                    else
                {
                    responceModel.Success = false;
                    responceModel.Message = "NotDeleted.";
                    AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);

                    return Json(responceModel);
                }
                
               
            }
            catch (Exception e)
            {
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);

                return Json(responceModel);
            }
        }

      
        #endregion

    }
}