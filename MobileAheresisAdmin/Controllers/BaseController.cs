using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MobileAheresisAdmin.Controllers
{
	public class BaseController : Controller
	{
		#region Field
		private readonly IExcelService _excelService;
		#endregion

		#region ctor
		public BaseController(
							  IExcelService excelService = null
							  )

		{
			_excelService = excelService;

		}







		#endregion



		public virtual void AddNotification(string title, string message, string type)
		{

			TempData["title"] = title;
			TempData["message"] = message;
			TempData["type"] = type;
		}

		public virtual void SetActiveMenu(string MenuName)
		{
			ViewBag.InventoryMenu = "";
			ViewBag.WarehouseTransactionMenu = "";
			ViewBag.DeliveryRequestsMenu = "";
			ViewBag.LocationMapppingMenu = "";
			ViewBag.UserManagementMenu = "";
			ViewBag.SystemControlsMenu = "";
			switch (MenuName)
			{
				case "InventoryMenu":
					ViewBag.InventoryMenu = "active";
					break;
				case "WarehouseTransactionMenu":
					ViewBag.WarehouseTransactionMenu = "active";
					break;
				case "DeliveryRequestsMenu":
					ViewBag.DeliveryRequestsMenu = "active";
					break;
				case "LocationMapppingMenu":
					ViewBag.LocationMapppingMenu = "active";
					break;
				case "UserManagementMenu":
					ViewBag.UserManagementMenu = "active";
					break;
				case "SystemControlsMenu":
					ViewBag.UserManagementMenu = "active";
					break;
			}
		}
		#region Security
		/// <summary>
		/// Access denied view
		/// </summary>
		/// <returns>Access denied view</returns>
		protected virtual IActionResult AccessDeniedView()
		{

			//return Challenge();
			return RedirectToAction("AccessDenied", "Security");
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{


		}
		#endregion

		#region report
		public FileResult ExportReport(Object list, string FileName)
		{
			var stream = new MemoryStream();
			stream = _excelService.CreateExcel(list, stream, FileName);
			string excelName = $"{FileName}-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
			return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
		}
		#endregion

	}

}