using CRM.Core;
using CRM.Core.Infrastructure;
using CRM.Core.ViewModels.Report;
using CRM.Core.ViewModels.TreatmentRecord;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.IO;


namespace CRM.Services.Common
{
    public partial class ExcelService:IExcelService
    {
        #region field
        private IWorkContext _workContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        #endregion

        #region Ctor
        public ExcelService(IHostingEnvironment HostingEnvironment,
                            IWorkContext WorkContext)
        {
            this._hostingEnvironment = HostingEnvironment;
            this._workContext = WorkContext;
        }

        #endregion

        #region methood
        public MemoryStream CreateExcel(Object list, MemoryStream stream, string FileName)
        {

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("By Patient");
                switch (FileName)
                {
                    case "Treatment Record":
                        workSheet.Cells[1, 1].LoadFromCollectionFiltered(((TreatmentRecordsPaginationModel)list).List);
                        break;
                    case "Treatment Report":
                        if (((TreatmentReportPaginationModel)list).ReportType == "By Patient")
                        {
                            workSheet.Cells.LoadFromCollectionFiltered(((TreatmentReportPaginationModel)list).PatientList);
                        }
                        else if (((TreatmentReportPaginationModel)list).ReportType == "By Hospital")
                        {
                            workSheet.Cells.LoadFromCollectionFiltered(((TreatmentReportPaginationModel)list).HospitalList);
                        }
                        else if (((TreatmentReportPaginationModel)list).ReportType == "By Nurse ")
                        {
                            workSheet.Cells.LoadFromCollectionFiltered(((TreatmentReportPaginationModel)list).NurseList);
                        }
                        else if (((TreatmentReportPaginationModel)list).ReportType == "By Date")
                        {
                            workSheet.Cells.LoadFromCollectionFiltered(((TreatmentReportPaginationModel)list).DateList);
                        }
                        else if (((TreatmentReportPaginationModel)list).ReportType == "By Diagnosis")
                        {
                            workSheet.Cells.LoadFromCollectionFiltered(((TreatmentReportPaginationModel)list).DiagnosisList);
                        }
                        else if (((TreatmentReportPaginationModel)list).ReportType == "By Procedure")
                        {
                            workSheet.Cells.LoadFromCollectionFiltered(((TreatmentReportPaginationModel)list).ProcedureList);
                        }
                        //workSheet.Cells.LoadFromCollectionFiltered(((TreatmentReportPaginationModel)list).List);
                        break;

                }
                

                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                package.Save();

            }
            stream.Position = 0;
            return stream;
        }

        #endregion




    }
}
