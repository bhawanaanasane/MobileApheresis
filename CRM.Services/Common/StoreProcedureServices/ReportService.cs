using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Core.Domain.Common;
using CRM.Core.ViewModels.CompanyProfiles;
using CRM.Core.ViewModels.Equipments;
using CRM.Core.ViewModels.Report;
using CRM.Core.ViewModels.TreatmentRecord;
using CRM.Data;
using CRM.Data.Interfaces;
using CRM.Services.Security;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services.Common.StoreProcedureServices
{
    public class ReportService : IReportService
    {
        #region Fields

        protected readonly dbContextCRM _dbContext;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctor

        public ReportService(dbContextCRM context, IEncryptionService encryptionService)
        {            
            this._dbContext = context;
            this._encryptionService = encryptionService;
        }

        #endregion

        #region Methods
        public CompanyProfilesPaginationModel GetAllCompanyProfiles(
                int page_size,
                int page_num,

                string keywords = null,
                  bool IsExport = false,
                  bool GetAll = false
           )
        {

            try
            {
                CompanyProfilesPaginationModel paginationData = new CompanyProfilesPaginationModel();
                string query = @"exec [GetAllCompanyProfiles] @page_size = '" + page_size + "', @page_num = '" + page_num + "', @keywords='" + keywords + "', @GetAll = '" + GetAll + "'";
                var data = _dbContext.CompanyProfileVM.FromSql(query).ToList();
                paginationData.List = data;
                paginationData.TotalRecords = (GetAll == true) ? data.Count : data.FirstOrDefault().TotalRecords;
                return paginationData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public EquipmentsPaginationModel GetAllEquipments(
        int page_size,
        int page_num,

        string keywords = null,
          bool IsExport = false,
          bool GetAll = false
   )
        {

            try
            {
                EquipmentsPaginationModel paginationData = new EquipmentsPaginationModel();
                string query = @"exec [GetAllEquipments] @page_size = '" + page_size + "', @page_num = '" + page_num + "', @keywords='" + keywords + "', @GetAll = '" + GetAll + "'";
                var data = _dbContext.EquipmentsVM.FromSql(query).ToList();
                paginationData.List = data;
                paginationData.TotalRecords = (GetAll == true) ? data.Count : data.FirstOrDefault().TotalRecords;
                return paginationData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }




        #endregion


        #region TreatmentRecords
        public TreatmentRecordsPaginationModel GetAllTreatmentRecords(
                int page_size,
                int page_num,
               bool GetAll = false,
               int TreatmentRecordStatusId = 0,
               int HospitalMasterId = 0,
                int NurseMasterId = 0,
                int PatientId = 0,
                int DaignosisId = 0,
                string StartDate = null,
                string EndDate = null
       )
        {

            try
            {
                TreatmentRecordsPaginationModel paginationData = new TreatmentRecordsPaginationModel();
                string query = @"exec [GetAllTreatmentRecords] @page_size = '" + page_size + "', @page_num = '" + page_num + "', @GetAll = '" + GetAll + "',@TreatmentRecordStatusId ='" + TreatmentRecordStatusId + "',@HospitalMasterId ='" + HospitalMasterId + "',@NurseMasterId ='" + NurseMasterId + "',@PatientId ='"+ PatientId + "',@DaignosisId ='"+ DaignosisId + "',@StartDate ='"+ StartDate + "',@EndDate ='"+ EndDate + "'";
                var data = _dbContext.TreatmentRecordVM.FromSql(query).ToList();
                paginationData.List = data;
                paginationData.TotalRecords = (GetAll == true) ? data.Count : data.FirstOrDefault().TotalRecords;
                return paginationData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //Changes Treatment Status
        public void UpdateTreatmentStatusID(int TreatmentRecordId = 0)
        {
            string query = @"exec [UpdateTreatmentRecordStatusId] @TreatmentRecordId = '" + TreatmentRecordId + "'";
            var updateCount = _dbContext.Database.ExecuteSqlCommand(query);
        }
        #endregion

        #region Other Lab Values
        public OtherLabValuesPaginationModel GetAllOtherLabValues(
           int LabValuesId
      )
        {

            try
            {
                OtherLabValuesPaginationModel paginationData = new OtherLabValuesPaginationModel();
                string query = @"exec [GetAllOtherLabValues] @LabValuesId = '" + LabValuesId + "'";
                var data = _dbContext.OtherLabValuesVM.FromSql(query).ToList();
                paginationData.List = data;

                return paginationData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region RunValues
        public RunValuesPaginationModel GetAllRunValues(
            int TreatmentRecordId
       )
        {

            try
            {
                RunValuesPaginationModel paginationData = new RunValuesPaginationModel();
                string query = @"exec [GetAllRunValues]  @TreatmentRecordId = '" + TreatmentRecordId + "'";
                var data = _dbContext.RunValuesVM.FromSql(query).ToList();
                paginationData.List = data;
                return paginationData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion


        #region RunValues
        public AllTreatmentRecordDataVM GetAllTreatmentRecordData(
             int TreatmentRecordId
        )
        {

            try
            {
                AllTreatmentRecordDataVM dd = new AllTreatmentRecordDataVM();
                List<RunValuesVM> _RunValues = new List<RunValuesVM>();

                string query = "exec GetAllDataByTreatmentRecordId  @TreatmentRecordId='" + TreatmentRecordId + "'";
                using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    _dbContext.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            //Patient Data
                            dd.PatientVM = new PatientVM
                            {
                                Id = result.GetInt32(0),
                                Deleted = result.GetBoolean(1),
                                Date = result.GetDateTime(2),
                                LastUpdated = result.GetDateTime(3),
                                MR = _encryptionService.DecryptText(result.GetString(4)),
                                HospitalMasterId = result.GetInt32(5),
                                HospitalName = _encryptionService.DecryptText(result.GetString(6)),
                                NurseMasterId = result.GetInt32(7),
                                NurseFirstName = result.GetString(8),
                                NurseLastName = result.GetString(9),
                                ProcedureId = result.GetInt32(10),
                                ProcedureName = result.GetString(11),
                                DiagnosisId = result.GetInt32(12),
                                DaignosisName = result.GetString(13),
                                PatientMasterId = result.GetInt32(14),
                                CreatedOn = result.GetDateTime(15),
                                MarkComplete = result.GetBoolean(16),
                                TreatmentRecordMasterId = result.GetInt32(17),
                                PatientName = _encryptionService.DecryptText(result.GetString(18))
                            };

                        }
                        //Doctor's Data
                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.DoctorsInfo = new DoctorsInfoVM
                                {
                                    Id = result.GetInt32(0),
                                    DoctorName = result.GetString(1),
                                    OrdersReviewed = result.GetBoolean(2),
                                    Room = result.GetString(3),
                                    OutPatient = result.GetBoolean(4),
                                    Comments = result.GetString(5),
                                    EducatioPreTreatmentId = result.GetInt32(6),
                                    TreatmentRecordMasterId = result.GetInt32(7),
                                    MarkComplete = result.GetBoolean(8)

                                };
                            }


                        }

                        //Machine's Data
                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.MachineMaster = new MachineMasterVM
                                {
                                    Id = result.GetInt32(0),
                                    EquipmentId = result.GetInt32(1),
                                    EquipSerial = result.GetString(2),
                                    KitTypeId = result.GetInt32(3),
                                    PMDate = result.GetDateTime(4),
                                    ExpDate = result.GetDateTime(5),
                                    SafetyChkDate = result.GetDateTime(6),
                                    MachineClean = result.GetBoolean(7),
                                    AlarmCheck = result.GetBoolean(8),
                                    CorrectiveAction = result.GetString(9),
                                    PrimeSuccess = result.GetBoolean(10),
                                    CleanedTrackDoors = result.GetBoolean(11),
                                    CleanedSensors = result.GetBoolean(12),
                                    CleanedPressurePODSSeals = result.GetBoolean(13),
                                    CreatedOn = result.GetDateTime(14),
                                    LastUpdated = result.GetDateTime(15),
                                    Deleted = result.GetBoolean(16),
                                    KitTypeSerial = result.GetString(17),
                                    CleanedFrontDoorSensors = result.GetBoolean(18),
                                    TreatmentRecordMasterId = result.GetInt32(19),
                                    EquipmentName = result.GetString(20),
                                    MarkComplete = result.GetBoolean(21)


                                };
                            }


                        }

                        //Pre treatment Check Data
                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.PreTreatmentCheck = new PreTreatmentCheckVM
                                {
                                    Id = result.GetInt32(0),
                                    InformedConsent = result.GetBoolean(1),
                                    BloodConsent = result.GetBoolean(2),
                                    MachinePrimeId = result.GetInt32(3),
                                   
                                    AlarmTest = result.GetBoolean(5),
                                    UniversalPrecautions = result.GetBoolean(6),
                                    TreatmentRecordMasterId = result.GetInt32(7),
                                    MarkComplete = result.GetBoolean(8)

                                };
                            }


                        }
                        //Lab Values
                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.LabValues = new LabValuesVM
                                {
                                    Id = result.GetInt32(0),
                                    TreatmentRecordMasterId = result.GetInt32(1),
                                    Height = result.GetDecimal(2),
                                    Weight = result.GetDecimal(3),
                                    EBV = result.GetDecimal(4),
                                    EPV = result.GetDecimal(5),
                                    ECV10 = result.GetDecimal(6),
                                    ECV15 = result.GetDecimal(7),
                                    HGB = result.GetDecimal(8),
                                    HTC = result.GetDecimal(9),
                                    WBC = result.GetDecimal(10),
                                    PLT = result.GetDecimal(11),
                                    CreatedOn = result.GetDateTime(12),
                                    LastUpdated = result.GetDateTime(13),
                                    Deleted = result.GetBoolean(14),
                                    MarkComplete = result.GetBoolean(15)

                                };
                            }


                        }
                        //Supplies and Access

                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.SuppliesVM = new SuppliesVM
                                {
                                    Id = result.GetInt32(0),
                                    TreatmentRecordId = result.GetInt32(1),
                                    ACDLot = result.GetString(2),
                                    ACDLotExpDate = result.GetDateTime(3),
                                    NSPrimeLot = result.GetString(4),
                                    NSPrimeLotExpDate = result.GetDateTime(5),
                                    Rate = result.GetString(6),
                                    BloodWarmer = result.GetBoolean(7),
                                    ACEInhibitors = result.GetBoolean(8),
                                    MedsReviewed = result.GetBoolean(9),
                                    TEMP = result.GetDecimal(10),
                                    Serial = result.GetString(11),
                                    LastDoseDate = result.GetDateTime(12),
                                    DateDC = result.GetDateTime(13),
                                    CVC = result.GetBoolean(14),
                                    Type = result.GetString(15),
                                    Peripheral = result.GetBoolean(16),
                                    Vortex = result.GetBoolean(17),
                                    Locations = result.GetString(18),
                                    Comments = result.GetString(19),
                                    CreatedOn = result.GetDateTime(20),
                                    LastUpdated = result.GetDateTime(21),
                                    Deleted = result.GetBoolean(22),
                                    MarkComplete = result.GetBoolean(23)
                                };
                            }


                        }
                        //Pre Treatment Assessment

                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.PreTreatmentAssessment = new PreTreatmentAssessmentVM
                                {
                                    Id = result.GetInt32(0),
                                    IsAlert = result.GetBoolean(1),
                                    IsLethargic = result.GetBoolean(2),
                                    IsComatose = result.GetBoolean(3),
                                    OrientedX = result.GetString(4),
                                    IsWeakness = result.GetBoolean(5),
                                    WeaknessAutoTextId = result.GetInt32(6),
                                    IsNumbness = result.GetBoolean(7),
                                    NumbnessAutoTextId = result.GetInt32(8),
                                    PainAutoTextId = result.GetInt32(9),
                                    LocationAutoTextId = result.GetInt32(10),
                                    IsEasy = result.GetBoolean(11),
                                    IsLabored = result.GetBoolean(12),
                                    OSat = result.GetString(13),
                                    IsNC = result.GetBoolean(14),
                                    IsRoomAir = result.GetBoolean(15),
                                    IsMask = result.GetBoolean(16),
                                    IsVent = result.GetBoolean(17),
                                    IsFiO2 = result.GetBoolean(18),
                                    LungSoundsAutoTextId = result.GetInt32(19),
                                    RythmAutoTextId = result.GetInt32(20),
                                    IsEdema = result.GetBoolean(21),
                                    EdemaAutoTextId = result.GetInt32(22),
                                    IsBleeding = result.GetBoolean(23),
                                    BleendAutoTextId = result.GetInt32(24),
                                    SkinAutoTextId = result.GetInt32(25),
                                    TreatmentRecordMasterId = result.GetInt32(26),
                                    IsDeleted = result.GetBoolean(27),
                                    CreatedOn = result.GetDateTime(28),
                                    LastUpdated = result.GetDateTime(29),
                                    MarkComplete = result.GetBoolean(30),
                                    WaeknessAutoTextName = result.GetString(31),
                                    NumbnessAutoTexName =result.GetString(32),
                                    PainAutoTextName =result.GetString(33),
                                    LocationAutoTextName = result.GetString(34),
                                    LungSoundsAutoTextName = result.GetString(35),
                                    RythmAutoTextName = result.GetString(36),
                                    EdemaAutoTextName = result.GetString(37),
                                    BleendAutoTextName = result.GetString(38),
                                    SkinAutoTextName = result.GetString(39),

                                };
                            }


                        }
                        //Final Values
                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.FinalValuesVM = new FinalValuesVM
                                {
                                    Id = result.GetInt32(0),
                                    Time = result.GetInt32(1),
                                    AC = result.GetInt32(2),
                                    Inlet = result.GetInt32(3),
                                    Plasma = result.GetInt32(4),
                                    Collet = result.GetInt32(5),
                                    FluidBalance = result.GetString(6),
                                    BP = result.GetString(7),
                                    T = result.GetInt32(8),
                                    P = result.GetInt32(9),
                                    R = result.GetInt32(10),
                                    TreatmentRecordId = result.GetInt32(11),
                                    NewDressing = result.GetBoolean(12),
                                    Reinforced = result.GetBoolean(13),
                                    Intact = result.GetBoolean(14),
                                    Saline = result.GetBoolean(15),
                                    Heparin = result.GetBoolean(16),
                                    ChlorhexidineCapApplied = result.GetBoolean(17),
                                    Comments = result.GetString(18),
                                    CreatedOn = result.GetDateTime(19),
                                    LastUpdated = result.GetDateTime(20),
                                    Deleted = result.GetBoolean(21),
                                    MarkComplete = result.GetBoolean(22)

                                };
                            }


                        }
                        //Post Treatment
                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.PostTreatmentVM = new PostTreatmentVM
                                {
                                    Id = result.GetInt32(0),
                                    IsRinseBackComplete = result.GetBoolean(1),
                                    IsPostCVCCarePerPolicy = result.GetBoolean(2),
                                    IsEquipmentCleanedAndDisinfected = result.GetBoolean(3),

                                    IsBiohazardWasteDisposed = result.GetBoolean(4),
                                    IsSideRailsUp = result.GetBoolean(5),
                                    TreatmentRecordId = result.GetInt32(6),
                                    MarkComplete = result.GetBoolean(7)

                                };
                            }
                        }
                        //Note and Report

                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                dd.NoteAndReportVM = new NoteAndReportVM
                                {
                                    Id = result.GetInt32(0),
                                     TreatmentRecordMasterId= result.GetInt32(1),
                                    Note = result.GetString(2),
                                    ReportGivenTo = result.GetString(3),

                                    CreatedOn = result.GetDateTime(4),
                                    LastUpdated = result.GetDateTime(5),
                                    Deleted = result.GetBoolean(6),
                                    IsTreatmentCompletedWOIncident = result.GetBoolean(7),
                                    MarkComplete = result.GetBoolean(8)

                                };
                            }
                        }

                    }
                }


                return dd;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region DashbordData 

        public DashboardData GetDashboardDetails(string StartDate = null,
           string EndDate = null,
           string StartDateForCalendar = null,
           string EndDateForCalendar = null, string TodaysDate = null)
        {
            DashboardData dd = new DashboardData();
            List<SliderValues> _sliderValues = new List<SliderValues>();
            List<CalendarData> _CalendarDataList = new List<CalendarData>();

            string query = "exec sp_Dashboard  @StartDate='" + StartDate + "', @EndDate = '" + EndDate + "', @StartDateForCalendar = '" + StartDateForCalendar + "', @EndDateForCalendar = '" + EndDateForCalendar + "',@TodaysDate='" + TodaysDate + "'";
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {

                        _sliderValues.Add(new SliderValues
                        {
                            Id = result.GetInt32(0),
                            PatientName = result.GetString(1),
                            HospitalName = result.GetString(2)
                        });
                        dd.SliderValues = _sliderValues.ToList();

                    }

                    if (result.NextResult())
                    {
                        while (result.Read())
                        {
                            _CalendarDataList.Add(new CalendarData
                            {
                                start = result.GetDateTime(0).ToString("yyyy-MM-dd"),

                                title = Convert.ToString(result.GetString(1)),
                                color = Convert.ToString(result.GetString(2)),
                                url = Convert.ToString(result.GetString(3)),
                                type = Convert.ToString(result.GetString(4)),
                                id = Convert.ToString(result.GetString(5))
                            });
                        }
                        dd.CalendarDatas = _CalendarDataList;

                    }

                    //if (result.NextResult())
                    //{


                    //}
                }

                //Todays date

                //var AppointmentCreatedRecords = GetAllTreatmentRecords(GetAll: true,TreatmentRecordStatusId:10, page_size: 0, page_num: 0);
                //dd.TodaysAppointment = AppointmentCreatedRecords.List;

                //var InProcessRecords = GetAllTreatmentRecords(GetAll: true, TreatmentRecordStatusId: 20, page_size: 0, page_num: 0);
                //dd.INProcessAppointment = InProcessRecords.List;

                //var TreatmentCompletedRecords = GetAllTreatmentRecords(GetAll: true, TreatmentRecordStatusId: 30, page_size: 0, page_num: 0);
                //dd.CompletedTreatment = TreatmentCompletedRecords.List;

                //var AppointmentCancelledRecords = GetAllTreatmentRecords(GetAll: true, TreatmentRecordStatusId: 40, page_size: 0, page_num: 0);
                //dd.CancelledAppointment= AppointmentCancelledRecords.List;

                //Week Date

                //var WeekReceivingLogs = GetAllReceivingLog(GetAll: true, ReceivedFromDate: Convert.ToDateTime(StartDate), ReceivedToDate: Convert.ToDateTime(EndDate), page_size: 0, page_num: 0);

                //dd.WeekReceivingLogs = WeekReceivingLogs.List;

                //var WeekShippingRequests = GetAllShippingRequest(GetAll: true, page_size: 0, page_num: 0, ApprovedFromDate: Convert.ToDateTime(StartDate), ApprovedToDate: Convert.ToDateTime(EndDate));
                //dd.WeekShippingRequests = WeekShippingRequests.List;

                //var WeekDeliveryRequests = GetAllDeliveryRequest(GetAll: true, page_size: 0, page_num: 0, DeliveryFromDate: Convert.ToDateTime(StartDate), DeliveryToDate: Convert.ToDateTime(EndDate));
                //dd.WeekDeliveryRequests = WeekDeliveryRequests.List;

                //var WeekPickupLists = GetAllPickupList(GetAll: true, page_size: 0, page_num: 0, CompletionFromDate: Convert.ToDateTime(StartDate), CompletionToDate: Convert.ToDateTime(EndDate));
                //dd.WeekPickupLists = WeekPickupLists.List;

                return dd;
            }
        }
        public DashboardData GetDastboard(string StartDate = null, string EndDate = null, string StartDateForCalendar = null, string EndDateForCalendar = null)
        {
            try
            {
                var query = "exec sp_Dashboard  @StartDate='" + StartDate + "', @EndDate = '" + EndDate + "', @StartDateForCalendar = '" + StartDateForCalendar + "', @EndDateForCalendar = '" + EndDateForCalendar + "'";
                DashboardData dd = new DashboardData();
                List<SliderValues> _sliderValues = new List<SliderValues>();
                List<CalendarData> _CalendarDataList = new List<CalendarData>();

                using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    _dbContext.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {

                        while (result.Read())
                        {

                            _sliderValues.Add(new SliderValues
                            {
                                Id = result.GetInt32(0),
                                PatientName = result.GetString(1),
                                HospitalName = result.GetString(2)
                            });
                            dd.SliderValues = _sliderValues.ToList();

                        }

                        //if (result.NextResult())
                        //{
                        //    while (result.Read())
                        //    {
                        //        _CalendarValuesList.Add(new CalendarValues
                        //        {
                        //            Date = result.GetDateTime(0),
                        //            WRReceivingLogProducts = Convert.ToString(result.GetInt32(1))
                        //        });
                        //    }
                        //    dd.CalendarValues = _CalendarValuesList;

                        //}

                        if (result.NextResult())
                        {
                            while (result.Read())
                            {
                                _CalendarDataList.Add(new CalendarData
                                {
                                    start = result.GetDateTime(0).ToString("yyyy-MM-dd"),
                                    title = Convert.ToString(result.GetString(1)),
                                    color = Convert.ToString(result.GetString(2)),
                                    url = Convert.ToString(result.GetString(3)),
                                    type = Convert.ToString(result.GetString(4)),
                                    id = Convert.ToString(result.GetString(5))
                                });
                            }
                            dd.CalendarDatas = _CalendarDataList;

                        }
                    }

                }
                return dd;
            }
            catch (Exception ex)
            {
                return null;
            }
        }





        public List<CalendarData> GetDastboardCalendarData(string StartDateForCalendar = null, string EndDateForCalendar = null)
        {
            try
            {
                var query = "exec [sp_dashboardCalendar]   @StartDateForCalendar = '" + StartDateForCalendar + "', @EndDateForCalendar = '" + EndDateForCalendar + "'";
                List<CalendarData> _CalendarDataList = new List<CalendarData>();

                using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    _dbContext.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            _CalendarDataList.Add(new CalendarData
                            {
                                start = result.GetDateTime(0).ToString("yyyy-MM-dd"),
                                title = Convert.ToString(result.GetString(1)),
                                color = Convert.ToString(result.GetString(2)),
                                url = Convert.ToString(result.GetString(3)),
                                type = Convert.ToString(result.GetString(4)),
                                id = Convert.ToString(result.GetString(5))
                            });
                        }

                    }

                }
                return _CalendarDataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<AppointmentVM> GetAllAppointment(
            int page_size,
              int page_num,

              string keywords = null,
                bool IsExport = false,
                bool GetAll = false)
        {

            string query = @"exec [sp_GetAllAppointment]@page_size = '" + page_size + "', @page_num = '" + page_num + "', @keywords='" + keywords + "', @GetAll = '" + GetAll + "'";
            var data = _dbContext.AppointmentVM.FromSql(query).ToList();
            return data;
        }

        //public IList<AppoimtmentDateVM> GetAppointmentDates(int AppointmentDateId)
        //{
        //    string query = @"exec [GetAppointmentDates] @AppointmentId='"+ AppointmentDateId + "'";
        //    var data = _dbContext.AppoimtmentDateVM.FromSql(query).ToList();
        //    return data;
        //}

        List<AppoimtmentDateVM> IReportService.GetAppointmentDates(int AppointmentDateId)
        {
            string query = @"exec [GetAppointmentDates] @AppointmentId='" + AppointmentDateId + "'";
            var data = _dbContext.AppoimtmentDateVM.FromSql(query).ToList();
            return data;
        }

        #endregion

        #region Report

        public TreatmentReportPaginationModel GetTreatmentRecordReport(
            int page_size,
            int page_num,
            bool GetAll = false,
            int ProcedureId = 0,
            int HospitalId = 0,
            int PatientId = 0,
            int NurseId = 0,
            int DiagnosisId = 0,
            string ReportType = null,
            string StartDate = null,
            string EndDate = null
       )
        {

            try
            {
                TreatmentReportPaginationModel paginationData = new TreatmentReportPaginationModel();
                string query = @"exec [GetTreatmentRecordReport] @page_size = '" + page_size + "', @page_num = '" + page_num + "', @GetAll = '" + GetAll + "',@DiagnosisId ='" + DiagnosisId + "',@NurseId ='" + NurseId + "',@PatientId ='" + PatientId + "',@HospitalId ='" + HospitalId + "',@ProcedureId ='" + ProcedureId + "',@ReportType ='" + ReportType + "',@StartDate ='" + StartDate + "',@EndDate ='" + EndDate + "'";
                var data = _dbContext.TreatmentReportModel.FromSql(query).ToList();
                paginationData.List = data;
                paginationData.TotalRecords = (GetAll == true) ? data.Count : data.FirstOrDefault().TotalRecords;
                return paginationData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        #endregion


    }
}
