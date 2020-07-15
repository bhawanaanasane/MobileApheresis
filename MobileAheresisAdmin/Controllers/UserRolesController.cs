using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.Customers;
using CRM.Services.Customers;
using MobileAheresisAdmin.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MobileAheresisAdmin.Models.UsersRole;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Models.Common;
using CRM.Services.Security;

namespace MobileAheresisAdmin.Controllers
{
    public class UserRolesController : BaseController
    {

        #region Field
        private readonly ICustomerService _customerService;
        private readonly IPermissionService _permissionService;


        #endregion
        #region Ctor
        public UserRolesController(

           ICustomerService customerService, IPermissionService permissionService

          )
        {

            
            this._customerService = customerService;
            this._permissionService = permissionService;

        }

        #endregion
        //Create,List,Edit,Delete (Get/Post)Methods
        #region Methods
        // GET: UserRoles
        public IActionResult Index()
        { //PageSize
            //var report = SharedData.UserRoleReport;
            //if (report != null)
            //{
            //    SharedData.RowCount = report.RowCount;
            //    SharedData.ReportName = "UserRole";
            //}
            //else
            //{
            //    SharedData.RowCount = 10;
            //    SharedData.ReportName = "UserRole";
            //}
            //form Name
            ViewBag.FormName = "User Roles ";
            //permissions
            if (SharedData.isAccessAdminPanelMenuAccessible == false)
                return AccessDeniedView();

            var model = new CustomerRoleListModel();
            var customerRole = _customerService.GetAllCustomerRoles().Select(x =>
            {
                var cmodel = new CustomerRoleModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                   
                    Active = x.Active
                    //ignore address for list view (performance optimization)
                };
                return cmodel;
            })
             .ToList();
            model.ListCustomerRole = customerRole;
            return View(model);
        }  

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            if (!(bool)SharedData.isUserRoleMenuAccessible)
                return AccessDeniedView();

            ViewBag.FormName = "User Role";
            //permissions
            //if (SharedData.isUserRolesMenuAccessible == false)
            //    return AccessDeniedView();

            var model = new CustomerRoleModel();
            //default value
            model.Active = true;
            //default value
           
            return View(model);
        }

        // POST: UserRoles/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(CustomerRoleModel model)
        {
            ViewBag.FormName = "User Role";
            //permissions
            if (SharedData.isUserRoleMenuAccessible == false)
                return AccessDeniedView();


            try
            {
                if (ModelState.IsValid)
                {
                    var customerRole = new CustomerRole();
                    customerRole.Description = model.Description;
                    customerRole.Active = model.Active;
                    customerRole.Name = model.Name;
                   
                    _customerService.InsertCustomerRole(customerRole);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgCreateUserRole, NotificationMessage.TypeSuccess);
                    return RedirectToAction("Index");
                }
                else
                {
                    model.Active = true;
                    //default value
                  
                    return View(model);
                }

            }

            catch (Exception e)
            {
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return RedirectToAction("CreateUserRole");
            }
        }

        // GET: UserRoles/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.FormName = "User Role :#" + id;
            //permissions
            if (SharedData.isUserRoleMenuAccessible == false)
                return AccessDeniedView();

            var customerRole = _customerService.GetCustomerRoleById(id);
            //Default Value 

            if (customerRole == null)
                //No vendor found with the specified id
                return RedirectToAction("UserRoleList");
            var model = customerRole.ToModel();


            return View(model);

        }

        // POST: UserRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerRoleModel model)
        {
            ViewBag.FormName = "User Role :#" + model.Id;
            //permissions
            if (SharedData.isUserRoleMenuAccessible == false)
                return AccessDeniedView();

            try
            {
                var customerRole = _customerService.GetCustomerRoleById(model.Id);
                if (ModelState.IsValid && model != null)
                {
                    customerRole.Name = model.Name;
                    customerRole.Description = model.Description;
                    customerRole.Active = model.Active;

                    _customerService.UpdateCustomerRole(customerRole);
                    AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgEditUserRole, NotificationMessage.TypeSuccess);

                    return  RedirectToAction("Index");
                }
                else
                {
                    AddNotification(NotificationMessage.TypeError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);

                    return View(model);
                }

            }

            catch (Exception w)
            {
                AddNotification(NotificationMessage.TypeError, NotificationMessage.ErrorMsg, NotificationMessage.TypeError);
                return RedirectToAction("Edit", "UserRoles", model.Id);
            }
        }

        // POST: UserRoles/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            ResponceModel responceModel = new ResponceModel();
            var deleteUserData = _customerService.GetCustomerRoleById(id);
            var count = _customerService.GetCustomerByCustomerRoleId(id).Count();
            if (count == 0)
            {
                _customerService.DeleteCustomerRole(deleteUserData);
                responceModel.Success = true;
                responceModel.Message = "Deleted.";
                AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgDeleteUserRole, NotificationMessage.TypeSuccess);

                return Json(responceModel);
            }
            else
            {
                responceModel.Success = false;
                responceModel.Message = "NotDeleted.";
                AddNotification(NotificationMessage.TitleError, NotificationMessage.ErrormsgUserRoleDeleted, NotificationMessage.TypeError);

                return Json(responceModel);
            }

            
        }

       
        #endregion
    }
}