using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Core.ViewModels.Report;
using CRM.Core.ViewModels.TreatmentRecord;
using CRM.Services.Appointment;
using CRM.Services.Common;
using CRM.Services.Common.PDFServices;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Common.WordDocServices;
using CRM.Services.CompanyProfiles;
using CRM.Services.Directory;
using CRM.Services.Hospitals;
using CRM.Services.Nurses;
using CRM.Services.Security;
using CRM.Services.Treatements;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAheresisAdmin.Common;
using MobileAheresisAdmin.Models.Treatments;
using MobileAheresisAdmin.Models.TreatmentsRecord;
using MobileAheresisAdmin.Utils;

namespace MobileAheresisAdmin.Controllers
{
    //18/09/19 aakansha
    public class TreatmentRecordController : BaseController
    {
        #region Fields

        private readonly IReportService _reportService;
        private readonly ITreatmentRecordServices _treatmentRecordServices;
        private readonly IHospitalServices _hospitalServices;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IPermissionService _permissionService;
        private readonly ITreatmentServices _treatmentServices;
        private readonly INurseServices _nurseServices;
        private readonly IPDFService _pDFService;
        private readonly IEncryptionService _encryptionService;
        private readonly IAppointmentServices _appointmentServices;
        private readonly ICompanyProfileService _companyProfileService;
        private readonly IExcelService _excelService;
        private readonly IWordDocService _wordDocService;

        #endregion

        #region ctor
        public TreatmentRecordController(IReportService reportService,
                                         ITreatmentRecordServices TreatmentRecordServices,
                                         IHospitalServices HospitalServices,
                                         IStateProvinceService StateProvinceService,
                                         IPermissionService permissionService,
                                         ITreatmentServices TreatmentServices,
                                         INurseServices NurseServices,
                                         IPDFService pDFService,
                                         ICompanyProfileService CompanyProfileService,
                                         IAppointmentServices AppointmentServices,
                                         IExcelService excelService,
                                         IEncryptionService encryptionService,
                                         IWordDocService WordDocService) : base(excelService: excelService)
        {
            this._reportService = reportService;
            this._treatmentRecordServices = TreatmentRecordServices;
            this._hospitalServices = HospitalServices;
            this._stateProvinceService = StateProvinceService;
            this._permissionService = permissionService;
            this._treatmentServices = TreatmentServices;
            this._nurseServices = NurseServices;
            this._pDFService = pDFService;
            this._appointmentServices = AppointmentServices;
            this._companyProfileService = CompanyProfileService;
            this._encryptionService = encryptionService;
            this._excelService = excelService;
            this._wordDocService = WordDocService;
        }


        #endregion

        #region Utilities
        // POST: Order/Create
        [HttpPost]
        public IActionResult GetStateByCountryId(int Id, int SelectedId)
        {
            if (!(bool)SharedData.isTreatmentRecordMenuAccessible)
                return AccessDeniedView();
            List<SelectListItem> States = new List<SelectListItem>();
            //states
            var states = _stateProvinceService.GetStateProvincesByCountryId(Id).ToList();
            if (states.Any())
            {
                States.Add(new SelectListItem { Text = "Select State", Value = null });

                foreach (var s in states)
                {
                    States.Add(new SelectListItem { Text = s.Name, Value = s.Id.ToString(), Selected = (s.Id == SelectedId) });
                }
            }

            return Json(States);
        }


        protected virtual void PrepareTreatmentRecordModel(TreatmentRecordListModel model)
        {
            //Daignosis Dropdown
            model.AvailableDaignosis.Add(new SelectListItem { Text = "Select Daignosis", Value = "0" });

            foreach (var c in _treatmentServices.GetAllDiagnosis().Where(a => a.Deleted != true))
            {
                model.AvailableDaignosis.Add(new SelectListItem
                {
                    Text = c.DiagnosisName,
                    Value = c.Id.ToString()
                });
            }

            //Patient  Dropdown
            model.AvailablePatient.Add(new SelectListItem { Text = "Select Patient", Value = "0" });

            foreach (var c in _treatmentRecordServices.GetAllPatientMaster().Where(a => a.Deleted != true))
            {
                model.AvailablePatient.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.PatientName),
                    Value = c.Id.ToString()
                });
            }

            //Hospital  Dropdown
            model.AvailableHospital.Add(new SelectListItem { Text = "Select Hospital", Value = "0" });

            foreach (var c in _hospitalServices.GetAllHospital().Where(a => a.Deleted != true))
            {
                model.AvailableHospital.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.HospitalName),
                    Value = c.Id.ToString()
                });
            }

            //Nurse  Dropdown
            model.AvailableNurse.Add(new SelectListItem { Text = "Select Nurse", Value = "0" });

            foreach (var c in _nurseServices.GetAllNurse().Where(a => a.Deleted != true))
            {
                model.AvailableNurse.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.FirstName) + " " + _encryptionService.DecryptText(c.LastName),
                    Value = c.Id.ToString()
                });
            }
        }

        #endregion

        #region Treatment Record
        public IActionResult List(DataSourceRequest command)
        {

            ViewBag.FormName = "TreatmentRecord";
            var model = new TreatmentRecordListModel();

            ViewBag.PageSizeDropdown = SelectListHelper.GetPageSizeDropdown(command.PageSize.ToString());
            var PagedList = _reportService.GetAllTreatmentRecords(
                             page_num: command.Page,
                             page_size: command.PageSize == 0 ? 10 : command.PageSize,
                             GetAll: command.PageSize == 0 ? true : false);

            PagedList.List = PagedList.List.Select(a => {
                a.HospitalName = (a.HospitalName != null) ? _encryptionService.DecryptText(a.HospitalName) : null;
                a.ContactPerson = (a.ContactPerson != null) ? _encryptionService.DecryptText(a.ContactPerson) : null;
                a.NurseFirstName = (a.NurseFirstName != null) ? _encryptionService.DecryptText(a.NurseFirstName) : null;
                a.NurseLastName = (a.NurseLastName != null) ? _encryptionService.DecryptText(a.NurseLastName) : null;
                a.PateintName = (a.PateintName != null) ? _encryptionService.DecryptText(a.PateintName) : null;
                a.MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR) : null;
                return a;
            }).ToList();

            model.List = PagedList.List.GetPaged(command.Page, command.PageSize, PagedList.TotalRecords);
            PrepareTreatmentRecordModel(model);
            return View(model);
        }
        [HttpPost]
        public IActionResult List(DataSourceRequest command, TreatmentRecordListModel model, string submittbutton)
        {

            ViewBag.FormName = "TreatmentRecord";

            switch (submittbutton)
            {
                //25/10/19 aakansha pdf
                case "ExportPDF":
                    var treatmentRecords = _reportService.GetAllTreatmentRecords(

                       page_num: command.Page,
                       page_size: command.PageSize == 0 ? 10 : command.PageSize,
                       GetAll: command.PageSize == 0 ? true : false,
                       HospitalId: model.HospitalId,
                       NurseId: model.NurseId,
                       PatientId: model.PatientId,
                       DaignosisId: model.DaignosisId,
                       StartDate: model.StartDate.ToString(),
                       EndDate: model.EndDate.ToString()
               );
                    return ExportTreatmentRecordList(treatmentRecords.List);
                //31/10/19 aakansha excel
                case "ExportExcel":
                    var treatmentRecordsExcel = _reportService.GetAllTreatmentRecords(
                     page_num: command.Page,
                       page_size: command.PageSize == 0 ? 10 : command.PageSize,
                       GetAll: command.PageSize == 0 ? true : false,
                       HospitalId: model.HospitalId,
                       NurseId: model.NurseId,
                       PatientId: model.PatientId,
                       DaignosisId: model.DaignosisId,
                       StartDate: model.StartDate.ToString(),
                       EndDate: model.EndDate.ToString()
                    );
                    treatmentRecordsExcel.List= treatmentRecordsExcel.List.Select(a =>
                    {
                        a.HospitalName = (a.HospitalName != null) ? _encryptionService.DecryptText(a.HospitalName) : null;
                        a.ContactPerson = (a.ContactPerson != null) ? _encryptionService.DecryptText(a.ContactPerson) : null;
                        a.NurseFirstName = (a.NurseFirstName != null) ? _encryptionService.DecryptText(a.NurseFirstName) : null;
                        a.NurseLastName = (a.NurseLastName != null) ? _encryptionService.DecryptText(a.NurseLastName) : null;
                        a.PateintName = (a.PateintName != null) ? _encryptionService.DecryptText(a.PateintName) : null;
                        a.MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR) : null;
                        return a;
                    }).ToList();

                    return ExportReport(treatmentRecordsExcel, "Treatment Record");

                case "ExprtWord":
                    var treatmentRecordsWord = _reportService.GetAllTreatmentRecords(
                    page_num: command.Page,
                      page_size: command.PageSize == 0 ? 10 : command.PageSize,
                      GetAll: command.PageSize == 0 ? true : false,
                      HospitalId: model.HospitalId,
                      NurseId: model.NurseId,
                      PatientId: model.PatientId,
                      DaignosisId: model.DaignosisId,
                      StartDate: model.StartDate.ToString(),
                      EndDate: model.EndDate.ToString()
                   );

                    return CreateTreatmentRecordDoc(treatmentRecordsWord);
            }

            ViewBag.PageSizeDropdown = SelectListHelper.GetPageSizeDropdown(command.PageSize.ToString());
            var PagedList = _reportService.GetAllTreatmentRecords(
                        page_num: command.Page,
                        page_size: command.PageSize == 0 ? 10 : command.PageSize,
                        GetAll: command.PageSize == 0 ? true : false,
                        HospitalId: model.HospitalId,
                        NurseId: model.NurseId,
                        PatientId: model.PatientId,
                        DaignosisId: model.DaignosisId,
                        StartDate: model.StartDate.ToString(),
                        EndDate: model.EndDate.ToString());

            PagedList.List = PagedList.List.Select(a => {
                a.HospitalName = _encryptionService.DecryptText(a.HospitalName);
                a.ContactPerson = _encryptionService.DecryptText(a.ContactPerson);
                a.NurseFirstName = _encryptionService.DecryptText(a.NurseFirstName);
                a.NurseLastName = _encryptionService.DecryptText(a.NurseLastName);
                a.PateintName = _encryptionService.DecryptText(a.PateintName);
                a.MR = _encryptionService.DecryptText(a.MR);
                return a;
            }).ToList();

            model.List = PagedList.List.GetPaged(command.Page, command.PageSize, PagedList.TotalRecords);
            PrepareTreatmentRecordModel(model);
            return View(model);
        }

        public IActionResult ViewTreatmentRecord(int Id)
        {
            //10/10/2019 aakansha
            ViewBag.FormName = "TreatmentRecord";
            var treatmentRecordData = _reportService.GetAllTreatmentRecordData(Id);
            var AllData = new AllTreatmentRecordDataVM();

            AllData.PatientVM = treatmentRecordData.PatientVM;
            AllData.DoctorsInfo = treatmentRecordData.DoctorsInfo;
            AllData.MachineMaster = treatmentRecordData.MachineMaster;
            AllData.PreTreatmentCheck = treatmentRecordData.PreTreatmentCheck;
            AllData.LabValues = treatmentRecordData.LabValues;
            var otherlabvaluedata = _treatmentRecordServices.GetOtherLabValueByLabValueId(AllData.LabValues.Id);
            foreach (var otherlabValue in otherlabvaluedata)
            {
                var data = new OtherLabValuesVM
                {
                    ContentName = otherlabValue.ContentName,
                    Id = otherlabValue.Id,
                    ContentValue = (decimal)otherlabValue.ContentValue,
                    LabValuesId = otherlabValue.LabValuesId
                };
                AllData.OtherLabValuesVMs.Add(data);
            }
            AllData.SuppliesVM = treatmentRecordData.SuppliesVM;
            AllData.PreTreatmentAssessment = treatmentRecordData.PreTreatmentAssessment;
            AllData.RunValuesVM = treatmentRecordData.RunValuesVM;
            AllData.FinalValuesVM = treatmentRecordData.FinalValuesVM;
            AllData.PostTreatmentVM = treatmentRecordData.PostTreatmentVM;
            AllData.medication = treatmentRecordData.medication;
            var medication = _treatmentRecordServices.GetMedicationByPostTreatmentId(AllData.PostTreatmentVM.Id);
            foreach (var Medication in medication)
            {

                var data = new MedicationVM
                {
                    id = Medication.Id,
                    Name = Medication.Name,
                    Dosage = Medication.Dosage,
                    Route = Medication.Route,
                    Comments = Medication.Comments,
                    PostTreatment = Medication.PostTreatment,
                    PostTreatmentId = Medication.PostTreatmentId,







                };
                AllData.medication.Add(data);
            }
            AllData.NoteAndReportVM = treatmentRecordData.NoteAndReportVM;

            return View(AllData);
        }
        #endregion

        #region Report
        public IActionResult Report(DataSourceRequest command)
        {
            ViewBag.FormName = "Treatment Report";
            ViewBag.SortByReportDropdown = PrepareSortByDropdown();
            var model = new TreatmentsReportListModel();

            ViewBag.PageSizeDropdown = SelectListHelper.GetPageSizeDropdown(command.PageSize.ToString());
            var PagedList = _reportService.GetTreatmentRecordReport(
                                     page_num: command.Page,
                                     page_size: command.PageSize == 0 ? 10 : command.PageSize,
                                     GetAll: command.PageSize == 0 ? true : false,
                                     HospitalId: model.HospitalId,
                                   NurseId: model.NurseId,
                                   PatientId: model.PatientId,
                                   ProcedureId: model.ProcedureId,
                                   ReportType: model.ReportType,
                                   DiagnosisId: model.DiagnosisId,
                                   StartDate: model.StartDate.ToString(),
                                   EndDate: model.EndDate.ToString());






            var report = PagedList.List.GetPaged(command.Page, command.PageSize, PagedList.TotalRecords);

            model.List = report.Results.Select(a =>
            {
                var data = new TreatmentReportModel();
                data.Date = a.Date;
                data.PatientName = (a.PatientName!= null)?_encryptionService.DecryptText(a.PatientName):null;
                data.Diagnosis = a.Diagnosis;
                data.Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital) : null;
                data.MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR) : null;
                data.NurseFirstName = (a.NurseFirstName != null) ? _encryptionService.DecryptText(a.NurseFirstName) : null;
                data.NurseLastName = (a.NurseLastName != null) ? _encryptionService.DecryptText(a.NurseLastName) : null;
                data.procedure = a.procedure;



                return data;
            }).ToList();

            //model.List = report.List.GetPaged(command.Page, command.PageSize, PagedList.TotalRecords);
            PrepareTreatmentReportModel(model);
            return View(model);
        }





        [HttpPost]
        public IActionResult Report(DataSourceRequest command, TreatmentsReportListModel model, string SubmitButton)
        {

            ViewBag.FormName = "Treatment Report";
            ViewBag.SortByReportDropdown = PrepareSortByDropdown();

             


            switch (SubmitButton)
            {

                //31/10/19 aakansha excel
                case "ExportExcel":
                    var listexcel = _reportService.GetTreatmentRecordReport(
                     page_num: command.Page,
                       page_size: command.PageSize == 0 ? 10 : command.PageSize,
                       GetAll: command.PageSize == 0 ? true : false,
                       HospitalId: model.HospitalId,
                       NurseId: model.NurseId,
                       PatientId: model.PatientId,
                       ProcedureId: model.ProcedureId,
                       ReportType: model.ReportType,
                       DiagnosisId: model.DiagnosisId,
                       StartDate: model.StartDate.ToString(),
                       EndDate: model.EndDate.ToString()
                    );
                    listexcel.ReportType = model.ReportType;

                    if (model.ReportType == "By Patient")
                    {
                        listexcel.PatientList = listexcel.List.Select(
                            a => new TreatmentByPatientReport
                            {
                                Date = a.Date,
                                Diagnosis = a.Diagnosis,
                                Hospital =(a.Hospital != null)? _encryptionService.DecryptText(a.Hospital):null,
                                MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR) : null,
                                NurseFirstName = (a.NurseFirstName != null) ? _encryptionService.DecryptText(a.NurseFirstName):null,
                                NurseLastName = (a.NurseLastName != null) ? _encryptionService.DecryptText(a.NurseLastName):null,
                                PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                                procedure = a.procedure


                            }).ToList();
                    }
                    else if (model.ReportType == "By Hospital")
                    {
                        listexcel.HospitalList = listexcel.List.Select(
                            a => new TreatmentByHospitalReport
                            {
                                Date = a.Date,
                                PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                                MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                                procedure = a.procedure,
                                Diagnosis = a.Diagnosis,
                                Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null




                            }).ToList();
                    }
                    else if (model.ReportType == "By Nurse ")
                    {
                        listexcel.NurseList = listexcel.List.Select(
                           a => new TreatmentByNurseReport
                           {
                               Date = a.Date,
                               Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                               PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                               MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                               NurseFirstName = (a.NurseFirstName != null) ? _encryptionService.DecryptText(a.NurseFirstName):null,
                               NurseLastName = (a.NurseLastName != null) ? _encryptionService.DecryptText(a.NurseLastName):null,
                               procedure = a.procedure,
                               Diagnosis = a.Diagnosis,


                           }).ToList();
                    }
                    else if (model.ReportType == "By Date")
                    {
                        listexcel.DateList = listexcel.List.Select(
                            a => new TreatmentByDateReport
                            {
                                Date = a.Date,
                                Diagnosis = a.Diagnosis,
                                Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                                MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                                PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                                procedure = a.procedure


                            }).ToList();
                    }
                    else if (model.ReportType == "By Diagnosis")
                    {
                        listexcel.DiagnosisList = listexcel.List.Select(
                            a => new TreatmentByDiagnosisReport
                            {
                                Date = a.Date,
                                Diagnosis = a.Diagnosis,
                                Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                                MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                                PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                                procedure = a.procedure


                            }).ToList();
                    }
                    else if (model.ReportType == "By Procedure")
                    {
                        listexcel.ProcedureList = listexcel.List.Select(
                            a => new TreatmentByProcedureReport
                            {
                                Date = a.Date,
                                Diagnosis = a.Diagnosis,
                                Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                                MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                                PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                                procedure = a.procedure


                            }).ToList();
                    }
                    return ExportReport(listexcel, "Treatment Report");



            }

            var PagedList = _reportService.GetTreatmentRecordReport(
                       page_num: command.Page,
                       page_size: command.PageSize == 0 ? 10 : command.PageSize,
                       GetAll: command.PageSize == 0 ? true : false,
                       HospitalId: model.HospitalId,
                       NurseId: model.NurseId,
                       PatientId: model.PatientId,
                       ProcedureId: model.ProcedureId,
                       ReportType: model.ReportType,
                       DiagnosisId: model.DiagnosisId,
                       StartDate: model.StartDate.ToString(),
                       EndDate: model.EndDate.ToString());
            var report = PagedList.List.GetPaged(command.Page, command.PageSize, PagedList.TotalRecords);
            if (model.ReportType == "By Patient")
            {
                model.PatientList = report.Results.Select(
                    a =>
                    {
                        var data = new TreatmentByPatientReport();
                        data.Date = a.Date;
                        //Diagnosis = a.Diagnosis,
                        data.Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital) : null;
                        //MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                        data.NurseFirstName = (a.NurseFirstName != null) ? _encryptionService.DecryptText(a.NurseFirstName) : null;
                        data.NurseLastName = (a.NurseLastName != null) ? _encryptionService.DecryptText(a.NurseLastName) : null;
                        data.PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName) : null;
                        //procedure = a.procedure

                        return data;
                    }).ToList();
            }
            else if (model.ReportType == "By Hospital")
            {
                model.HospitalList = report.Results.Select(
                    a => new TreatmentByHospitalReport
                    {
                        Date = a.Date,
                        PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                        MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                        procedure = a.procedure,
                        Diagnosis = a.Diagnosis,
                        Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null




                    }).ToList();
            }
            else if (model.ReportType == "By Nurse ")
            {
                model.NurseList = report.Results.Select(
                   a => new TreatmentByNurseReport
                   {
                       Date = a.Date,
                       Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                       PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                       MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                       NurseFirstName = (a.NurseFirstName != null) ? _encryptionService.DecryptText(a.NurseFirstName):null,
                       NurseLastName = (a.NurseLastName != null) ? _encryptionService.DecryptText(a.NurseLastName):null,
                       procedure = a.procedure,
                       Diagnosis = a.Diagnosis,


                   }).ToList();
            }
            else if (model.ReportType == "By Date")
            {
                model.DateList = report.Results.Select(
                    a => new TreatmentByDateReport
                    {
                        Date = a.Date,
                        Diagnosis = a.Diagnosis,
                        Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                        MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                        PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                        procedure = a.procedure


                    }).ToList();
            }
            else if (model.ReportType == "By Diagnosis")
            {
                model.DiagnosisList = report.Results.Select(
                    a => new TreatmentByDiagnosisReport
                    {
                        Date = a.Date,
                        Diagnosis = a.Diagnosis,
                        Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                        MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                        PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                        procedure = a.procedure


                    }).ToList();
            }
            else if (model.ReportType == "By Procedure")
            {
                model.ProcedureList = report.Results.Select(
                    a => new TreatmentByProcedureReport
                    {
                        Date = a.Date,
                        Diagnosis = a.Diagnosis,
                        Hospital = (a.Hospital != null) ? _encryptionService.DecryptText(a.Hospital):null,
                        MR = (a.MR != null) ? _encryptionService.DecryptText(a.MR):null,
                        PatientName = (a.PatientName != null) ? _encryptionService.DecryptText(a.PatientName):null,
                        procedure = a.procedure


                    }).ToList();
            }

            //model.List = report.Results.Select(a =>
            //            {
            //                var data = new TreatmentReportModel();
            //                data.Date = a.Date;
            //                data.PatientName = _encryptionService.DecryptText(a.PatientName);
            //                data.Diagnosis = a.Diagnosis;
            //                data.Hospital = _encryptionService.DecryptText(a.Hospital);
            //                data.MR = _encryptionService.DecryptText(a.MR);
            //                data.NurseFirstName = _encryptionService.DecryptText(a.NurseFirstName);
            //                data.NurseLastName = _encryptionService.DecryptText(a.NurseLastName);
            //                data.procedure = a.procedure;



            //                return data;
            //            }).ToList();

            PrepareTreatmentReportModel(model);
            return View(model);
        }


        protected virtual void PrepareTreatmentReportModel(TreatmentsReportListModel model)
        {
            //Daignosis Dropdown
            model.AvailableDaignosis.Add(new SelectListItem { Text = "Select Daignosis", Value = "0" });

            foreach (var c in _treatmentServices.GetAllDiagnosis().Where(a => a.Deleted != true))
            {
                model.AvailableDaignosis.Add(new SelectListItem
                {
                    Text = c.DiagnosisName,
                    Value = c.Id.ToString()
                });
            }

            //Patient  Dropdown
            model.AvailablePatient.Add(new SelectListItem { Text = "Select Patient", Value = "0" });

            foreach (var c in _treatmentRecordServices.GetAllPatientMaster().Where(a => a.Deleted != true))
            {
                model.AvailablePatient.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.PatientName),
                    Value = c.Id.ToString()
                });
            }

            //Hospital  Dropdown
            model.AvailableHospital.Add(new SelectListItem { Text = "Select Hospital", Value = "0" });

            foreach (var c in _hospitalServices.GetAllHospital().Where(a => a.Deleted != true))
            {
                model.AvailableHospital.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.HospitalName),
                    Value = c.Id.ToString()
                });
            }

            //Nurse  Dropdown
            model.AvailableNurse.Add(new SelectListItem { Text = "Select Nurse", Value = "0" });

            foreach (var c in _nurseServices.GetAllNurse().Where(a => a.Deleted != true))
            {
                model.AvailableNurse.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(c.FirstName) + " " + _encryptionService.DecryptText(c.LastName),
                    Value = c.Id.ToString()
                });
            }


            model.AvailableProcedure.Add(new SelectListItem { Text = "Select Procedure", Value = "0" });

            foreach (var c in _companyProfileService.GetAllCompanyProfile().PoliciesAndProcedures.Where(a => a.IsPolicy == false))
            {
                model.AvailableProcedure.Add(new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Id.ToString()
                });
            }
        }




        #region Dropdowns
        private IList<SelectListItem> PrepareSortByDropdown(string SelectedText = "", int Id = 0)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "All", Value = "Select Report Type", Selected = (SelectedText == "All") });
            items.Add(new SelectListItem { Text = "By Patient", Value = "By Patient", Selected = (SelectedText == "By Patient") });
            items.Add(new SelectListItem { Text = "By Hospital", Value = "By Hospital", Selected = (SelectedText == "By Hospital") });

            items.Add(new SelectListItem { Text = "By Nurse", Value = "By Nurse", Selected = (SelectedText == "By Nurse") });
            items.Add(new SelectListItem { Text = "By Diagnosis", Value = "By Diagnosis", Selected = (SelectedText == "By Diagnosis") });

            items.Add(new SelectListItem { Text = "By Procedure", Value = "By Procedure", Selected = (SelectedText == "By Procedure") });
            items.Add(new SelectListItem { Text = "By Date", Value = "By Date", Selected = (SelectedText == "By Date") });

            //items.Add(new SelectListItem { Text = "Machine QA", Value = "Machine QA", Selected = (SelectedText == "Machine QA") });


            return items;
        }
        #endregion

        #region Reports Dropdown
        private IList<SelectListItem> PreparePatientDropdown(string SelectedText = "Select Patient", int Id = 0)
        {
            var PatientList = _treatmentRecordServices.GetAllPatientMaster().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var patientdata in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(patientdata.PatientName),
                    Value = patientdata.Id.ToString(),
                    Selected = patientdata.Id == 0 ? true : false
                });
            }



            return items;
        }
        private IList<SelectListItem> PrepareNurseDropdown(string SelectedText = "Select Nurse", int Id = 0)
        {
            var PatientList = _nurseServices.GetAllNurse().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Nursedata in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(Nursedata.FirstName) + " " + _encryptionService.DecryptText(Nursedata.LastName),
                    Value = Nursedata.Id.ToString()
                });
            }



            return items;
        }

        private IList<SelectListItem> PrepareHospitalDropdown(string SelectedText = "Select Hospital", int Id = 0)
        {
            var PatientList = _hospitalServices.GetAllHospital().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Hospitaldata in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = _encryptionService.DecryptText(Hospitaldata.HospitalName),
                    Value = Hospitaldata.Id.ToString()
                });
            }



            return items;
        }


        private IList<SelectListItem> PrepareDiagnosisDropdown(string SelectedText = "Select Diagnosis", int Id = 0)
        {
            var PatientList = _treatmentServices.GetAllDiagnosis().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Diagnosisdata in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = Diagnosisdata.DiagnosisName,
                    Value = Diagnosisdata.Id.ToString()
                });
            }



            return items;
        }
        private IList<SelectListItem> PrepareMRDropdown(string SelectedText = "Select MR", int Id = 0)
        {
            var PatientList = _appointmentServices.GetAllAppointment().Where(a => a.Deleted != true);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var MRData in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = MRData.MR,
                    Value = MRData.Id.ToString()
                });
            }



            return items;
        }

        private IList<SelectListItem> PrepareProcedureDropdown(string SelectedText = "Select Procedure", int Id = 0)
        {
            var PatientList = _companyProfileService.GetAllCompanyProfile().PoliciesAndProcedures.Where(a => a.IsPolicy == false);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var MRData in PatientList)
            {
                items.Add(new SelectListItem
                {
                    Text = MRData.Text,
                    Value = MRData.Id.ToString()
                });
            }



            return items;
        }



        //private IList<SelectListItem> PrepareProDropdown(string SelectedText = "Select Procedure", int Id = 0)
        //{
        //    var PatientList = _companyProfileService.GetAllCompanyProfile().PoliciesAndProcedures.Where(a => a.IsPolicy == false);
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    foreach (var MRData in PatientList)
        //    {
        //        items.Add(new SelectListItem
        //        {
        //            Text = MRData.Text,
        //            Value = MRData.Id.ToString()
        //        });
        //    }



        //    return items;
        //}




        #endregion


















        #endregion
        //25/10/19 aakansha
        #region Export TreatmentRecordPDF file
        // Download TreatmentRecord List
        public FileResult ExportTreatmentRecordList(List<TreatmentRecordVM> treatmentRecords)
        {
            byte[] bytes;
            using (var stream = new MemoryStream())
            {
                _pDFService.PrintTreatmentRecordToPdf(stream, treatmentRecords);
                bytes = stream.ToArray();
            }

            return File(bytes, "application/pdf", $"treatmentRecords{DateTime.UtcNow.ToString("MM-dd-yyyy")}.pdf");
        }


        #endregion

        //31/10/19 aakansha Excel
        #region Excel

        public FileResult ExportTreatmentRecordListExcel(List<TreatmentRecordVM> treatmentRecords)
        {
            DataTable dtExcelData = new DataTable("Treatment Record Report");
            dtExcelData.TableName = "Treatment Record Report";
            dtExcelData.Columns.Add("Pateint Name");
            dtExcelData.Columns.Add("Nurse");
            dtExcelData.Columns.Add("Hospital");
            dtExcelData.Columns.Add("Contact Person");
            dtExcelData.Columns.Add("Doctor");
            dtExcelData.Columns.Add("Room");
            dtExcelData.Columns.Add("Equipment");
            dtExcelData.Columns.Add("Serial");
            dtExcelData.Columns.Add("PMDate");
            dtExcelData.Columns.Add("Status");

            foreach (var item in treatmentRecords)
            {
                int countRow = dtExcelData.Rows.Count;
                dtExcelData.Rows.Add();
                dtExcelData.Rows[countRow]["Pateint Name"] = (item.PateintName != null) ? _encryptionService.DecryptText(item.PateintName).ToString() : "";
                dtExcelData.Rows[countRow]["Nurse"] = (item.NurseFirstName != null) && (item.NurseLastName != null) ? _encryptionService.DecryptText(item.NurseFirstName).ToString() + " " + _encryptionService.DecryptText(item.NurseLastName) : "";
                dtExcelData.Rows[countRow]["Hospital"] = (item.HospitalName != null) ? _encryptionService.DecryptText(item.HospitalName).ToString() : "";
                dtExcelData.Rows[countRow]["Contact Person"] = (item.ContactPerson != null) ? _encryptionService.DecryptText(item.ContactPerson.ToString()) : "";
                dtExcelData.Rows[countRow]["Doctor"] = (item.DoctorName != null) ? item.DoctorName.ToString() : "";
                dtExcelData.Rows[countRow]["Room"] = (item.Room != null) ? item.Room.ToString() : "";
                dtExcelData.Rows[countRow]["Equipment"] = (item.EquipmentName != null) ? item.EquipmentName.ToString() : "";
                dtExcelData.Rows[countRow]["Serial"] = (item.EquipSerial != null) ? item.EquipSerial.ToString() : "";
                var StringPMDate = "";
                if (item.PMDate != null)
                {
                    var PMDate = Convert.ToDateTime(item.PMDate);

                    StringPMDate = PMDate.ToShortDateString();
                }
                dtExcelData.Rows[countRow]["PMDate"] = StringPMDate;
                dtExcelData.Rows[countRow]["Status"] = item.TreatmentStatus.ToString();

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtExcelData);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Treatment Record.xlsx");
                }
            }
        }
        #endregion

        #region Treatment Record Word Document
        // GET verb
        public IActionResult CreateTreatmentRecordDoc(TreatmentRecordsPaginationModel model)
        {

            // open xml sdk - docx
            byte[] bytes;
            using (var stream = new MemoryStream())
            {
                _wordDocService.PrintTreatmentRecordToWord(stream, model);
                bytes = stream.ToArray();
            }
            return File(bytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "TreatmentRecord.docx");
        }




        #endregion
    }
}