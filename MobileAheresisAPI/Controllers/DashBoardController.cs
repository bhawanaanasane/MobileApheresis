using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Result;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        #region Fields

        
        private IReportService _reportService;
        #endregion


        #region CTOR
        public DashBoardController(
            IReportService ReportService)
        {
            
            this._reportService = ReportService;
        }
        #endregion
        [HttpGet("GetCalender")]
        public IActionResult GetCalender()
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                string[] SelectedDate = DateTime.UtcNow.ToString("MM/dd/yyyy").Split('/');
                int Month = Convert.ToInt32(SelectedDate[0]);
                int Day = Convert.ToInt32(SelectedDate[1]);
                int Year = Convert.ToInt32(SelectedDate[2]);

                DateTime ss = new DateTime(Year, Month, 1);
                var date = ss.AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy");
                var result = _reportService.GetDashboardDetails(Convert.ToString(DateTime.Now.Year) + "-1-1", Convert.ToString(DateTime.Now.Year) + "-12-31", ss.ToString("MM/dd/yyyy"), date);
                resultModel.Status = 1;
                resultModel.Message = ValidationMessages.Success;
                resultModel.Response = result.CalendarDatas;
                return Ok(resultModel);
            }
            catch (Exception ex)

            {
                resultModel.Status = 0;
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Response = ex.ToString();
                return Ok(resultModel);
            }
        }

        [HttpGet("GetCalenderByDate")]
        public IActionResult GetCalenderByDate(string date)
        {
            string datevalue = null;
            datevalue = date;
            ResultModel resultModel = new ResultModel();
            try
            {

                string[] SelectedDate = datevalue.Split('-');
                int Month = Convert.ToInt32(SelectedDate[0]);
                int Day = Convert.ToInt32(SelectedDate[1]);
                int Year = Convert.ToInt32(SelectedDate[2]);

                DateTime ss = new DateTime(Year, Month, 1);
                var dateTest = ss.AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy");

                var result = _reportService.GetDastboardCalendarData(ss.ToString("MM/dd/yyyy"), dateTest);
                resultModel.Status = 1;
                resultModel.Message = ValidationMessages.Success;
                resultModel.Response = result;
                return Ok(resultModel);
            }
            catch (Exception ex)

            {
                resultModel.Status = 0;
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Response = ex.ToString();
                return Ok(resultModel);
            }
        }

    }
}