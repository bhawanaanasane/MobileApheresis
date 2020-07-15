using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Models.TreatmentRecords;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteAndReportController : ControllerBase
    {
        #region Fields
        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IReportService _reportService;
        #endregion

        #region CTOR
        public NoteAndReportController(ITreatmentRecordServices TreatmentRecordServices,
            IReportService ReportService)
        {
            this._treatmentRecordServices = TreatmentRecordServices;
            this._reportService = ReportService;
        }
        #endregion

        public IActionResult Index()
        {
            return Ok();
        }
        // POST: NoteAndReport/Create
        [HttpPost("Create")]
        public IActionResult Create(NoteAndReportModel model)
        {
            ResultModel resultModel = new ResultModel();
            try {
                var notedata = new NoteAndReportMaster();
                if (model.Id == 0)
                {
                    notedata.Note = model.Note;
                    notedata.ReportGivenTo = model.ReportGivenTo;
                    notedata.IsTreatmentCompletedWOIncident = model.IsTreatmentCompletedWOIncident;
                    notedata.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    notedata.MarkComplete = model.MarkComplete;
                    notedata.Deleted = false;
                    notedata.CreatedOn = DateTime.UtcNow;
                    _treatmentRecordServices.InsertNoteAndReport(notedata);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)notedata.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.TreatmentRecordMasterId = notedata.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                }
                else
                {
                    notedata = _treatmentRecordServices.GetNoteAndReportById(model.Id);
                    notedata.ReportGivenTo = model.ReportGivenTo;
                    notedata.IsTreatmentCompletedWOIncident = (bool)model.IsTreatmentCompletedWOIncident;
                    notedata.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    notedata.MarkComplete = model.MarkComplete;
                    notedata.LastUpdated = DateTime.UtcNow;
                    _treatmentRecordServices.UpdateNoteAndReport(notedata);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)notedata.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = notedata.Id;
                    model.TreatmentRecordMasterId = notedata.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                }
                return Ok(resultModel);
            }
            catch(Exception e)
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel); }

            
        }



        // GET: NoteAndReport/GetById/5
        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            ResultModel resultModel = new ResultModel();
            var noteData = _treatmentRecordServices.GetNoteAndReportById(Id);
            var model = new NoteAndReportModel();
            model.Id = noteData.Id;
            model.IsTreatmentCompletedWOIncident = noteData.IsTreatmentCompletedWOIncident;
            model.TreatmentRecordMasterId = noteData.TreatmentRecordMasterId;
            model.ReportGivenTo = noteData.ReportGivenTo;
            model.LastUpdated = noteData.LastUpdated;
            model.Note = noteData.Note;
            model.CreatedOn = noteData.CreatedOn;
            model.Deleted = noteData.Deleted;
            if (model != null)
            {
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = model;
                return Ok(resultModel);
            }
            else
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }
        }
    }
}