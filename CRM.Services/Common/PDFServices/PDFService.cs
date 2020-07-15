using CRM.Core;
using CRM.Core.Domain.Common;
using CRM.Core.ViewModels.TreatmentRecord;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Customers;
using CRM.Services.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace CRM.Services.Common.PDFServices
{
    public partial class PDFService : IPDFService
    {
        #region field

        private readonly ICustomerService _customerService;

        private readonly IAddressService _addressService;
       
        private readonly IReportService _reportService;
        private IPDFCommonSettings _pdfCommonSettings;
        private IWorkContext _workContext;
        private PageFooter pDFFooter;
        private readonly IEncryptionService _encryptionService;

        private readonly IHostingEnvironment _hostingEnvironment;

        #endregion

        #region Ctor
        public PDFService(
            IReportService ReportService,

IHostingEnvironment HostingEnvironment,

        ICustomerService customerService,
        IAddressService addressService,
        

          IPDFCommonSettings pdfCommonSettings,
          PageFooter pDFFooter,
           IEncryptionService encryptionService,

          IWorkContext WorkContext
            )
        {

            this._reportService = ReportService;
            this._encryptionService = encryptionService;
            this._hostingEnvironment = HostingEnvironment;
            this._workContext = WorkContext;

            this._pdfCommonSettings = pdfCommonSettings;
            this._customerService = customerService;
            this._addressService = addressService;
           
            this.pDFFooter = pDFFooter;

        }

        #endregion

        #region Common

        private PdfPTable PrintAddress(Address address, string Header)
        {
            var CustomerAddress = new PdfPTable(1)
            {
                RunDirection = PdfWriter.RUN_DIRECTION_LTR,
                WidthPercentage = 100f
            };
            CustomerAddress.SpacingBefore = 4f;
            CustomerAddress.HorizontalAlignment = Element.ALIGN_LEFT;

            // Font titleFont = FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK);
            var cellCustomerItem = _pdfCommonSettings.GetBodyCell(text: Header, columnType: ColumnType.Text, IsHeader: true, IsTableHeader: true);

            CustomerAddress.AddCell(cellCustomerItem);

            //Font CustFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK);
            //Font arial = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.LIGHT_GRAY);

            var billingCell = _pdfCommonSettings.GetBodyCell(text: $"{address.FirstName} {address.LastName}", columnType: ColumnType.Text);
            if (address.Address1 != null)
            {
                billingCell.Phrase.Add(new Phrase(Environment.NewLine));
                billingCell.Phrase.Add(_pdfCommonSettings.GetBodyCellItem(address.Address1 + ","));
            }
            if (address.Address2 != null)
            {
                billingCell.Phrase.Add(new Phrase(Environment.NewLine));
                billingCell.Phrase.Add(_pdfCommonSettings.GetBodyCellItem(address.Address2 + ","));
            }

            billingCell.Phrase.Add(new Phrase(Environment.NewLine));
            billingCell.Phrase.Add(_pdfCommonSettings.GetBodyCellItem(address.City + ","));
            billingCell.Phrase.Add(_pdfCommonSettings.GetBodyCellItem(address.StateProvince + ","));

            billingCell.Phrase.Add(_pdfCommonSettings.GetBodyCellItem(Environment.NewLine));
            billingCell.Phrase.Add(_pdfCommonSettings.GetBodyCellItem(address.ZipPostalCode));
            billingCell.HorizontalAlignment = Element.ALIGN_LEFT;
            CustomerAddress.AddCell(billingCell);

            return CustomerAddress;
        }

        private void PrintMultipleAddresses(Document doc, PdfPTable mainTable, string Header, int AddressId, bool isFirst = true)
        {
            PdfPCell firstTableCell = new PdfPCell();
            firstTableCell.Border = PdfPCell.NO_BORDER;
            var addressData = _addressService.GetAddressById(AddressId);
            PdfPTable address = PrintAddress(addressData, Header);
            firstTableCell.AddElement(address);
            mainTable.AddCell(firstTableCell);
            doc.Add(mainTable);
        }

        //private void PrintLine(Document doc)
        //{
        //    LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
        //    doc.Add(line);
        //}

        private void PrintBoldLine(Document doc)
        {
            LineSeparator line = new LineSeparator(2f, 100f, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
            doc.Add(line);
        }

        protected virtual void PrintHeader(Document doc, PdfWriter writer, string ReportName, string BarocdeID = null)
        {
            // Main table
            var mainTable = new PdfPTable(new float[] { 80F, 30F })
            {
                RunDirection = PdfWriter.RUN_DIRECTION_LTR,
                WidthPercentage = 100f
            };
            mainTable.SpacingBefore = 4f;
            mainTable.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Header Left
            PdfPCell leftTableCell = new PdfPCell();
            leftTableCell.Border = PdfPCell.NO_BORDER;
            //header
            var headerLeft = new PdfPTable(new float[] { 20F, 90F });
            headerLeft.WidthPercentage = 100f;
            headerLeft.SpacingAfter = 4f;
            headerLeft.DefaultCell.Border = Rectangle.NO_BORDER;

            headerLeft.AddCell(_pdfCommonSettings.GetLogoCell());
            //doc.Add(headerLeft);

            var cellHeader = _pdfCommonSettings.GetHeaderCell("Mobile Apheresis");
            cellHeader.MinimumHeight =10;
            headerLeft.AddCell(cellHeader);

            var cellHeaderBody = _pdfCommonSettings.GetMainHeaderAddressCell("");
            cellHeaderBody.Border = Rectangle.NO_BORDER;

            headerLeft.AddCell(cellHeaderBody);

            leftTableCell.AddElement(headerLeft);
            mainTable.AddCell(leftTableCell);
            #endregion

            #region Header Right
            PdfPCell rightTableCell = new PdfPCell();
            rightTableCell.Border = PdfPCell.NO_BORDER;
            rightTableCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            var headerRight = new PdfPTable(new float[] { 50F, 50F })
            {
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                WidthPercentage = 100f
            };

            //headerRight.HorizontalAlignment = Element.ALIGN_RIGHT;
            //headerRight.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
            //headerRight.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            headerRight.DefaultCell.Border = Rectangle.NO_BORDER;
            var ReportNameCell = _pdfCommonSettings.GetReportHeaderCell(ReportName);
            ReportNameCell.MinimumHeight = 25;
            headerRight.AddCell(ReportNameCell);
            if (!string.IsNullOrEmpty(BarocdeID))
            {
                headerRight.AddCell(_pdfCommonSettings.GetBarcodeCell(BarocdeID, writer));
                headerRight.AddCell(_pdfCommonSettings.GetReportHeaderCell("    "));
                headerRight.AddCell(_pdfCommonSettings.GetBodyCell(text: BarocdeID, columnType: ColumnType.Text, RemoveBorder: true, IsHeader: true, IsTransparentBackground: true));
                headerRight.AddCell(_pdfCommonSettings.GetReportHeaderCell("    "));
            }

            rightTableCell.AddElement(headerRight);
            mainTable.AddCell(rightTableCell);
            #endregion
            doc.Add(mainTable);
        }

        #endregion
        #region Treatment Record
        //30/10/19 aakansha
        public virtual void PrintTreatmentRecordToPdf(Stream stream, IList<TreatmentRecordVM> TreatmentRecordList)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

    

            var pageSize = PageSize.A4;

            var doc = new Document(pageSize);
            var pdfWriter = PdfWriter.GetInstance(doc, stream);

           

            doc.Open();

            PrintHeader(doc, pdfWriter, "Treatment Record ");
            PrintTreatmentRecordList(doc, TreatmentRecordList);

            //PrintLine(doc);
          


            //PrintTreatmentRecordFooter(pdfWriter: pdfWriter, Comment: TreatmentRecord., TreatmentRecordProducts: TreatmentRecordproduct);
            doc.Close();
        }
        //30/10/19 aakansha
        public virtual void PrintTreatmentRecordList(Document doc, IList<TreatmentRecordVM> TreatmentRecord)
        {
            var table = new PdfPTable(new float[] {25F, 30F, 30F, 50F, 25F, 25F, 35F, 25F, 30F, 30F })
            {
                RunDirection = PdfWriter.RUN_DIRECTION_LTR,
                WidthPercentage = 100f
            };

            table.SpacingBefore = 4f;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Pateint", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Nurse", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Hospital", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Contact Person", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Doctor", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Room", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Equipment", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Serial", columnType: ColumnType.Text, IsHeader: true));
            
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "PMDate", columnType: ColumnType.Text, IsHeader: true));
            table.AddCell(_pdfCommonSettings.GetBodyCell(text: "Status", columnType: ColumnType.Text, IsHeader: true));


            foreach (var item in TreatmentRecord)
            {
                //table.AddCell(_pdfCommonSettings.GetBodyCell(text: item.TreatmentRecord.PateintName + "(" + item.Product.Barcode + ")", columnType: ColumnType.Text, RemoveBorder: true));
                
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: _encryptionService.DecryptText(item.PateintName).ToString(), columnType: ColumnType.Text, RemoveBorder: true));
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: _encryptionService.DecryptText(item.NurseFirstName )+" " + _encryptionService.DecryptText(item.NurseLastName).ToString(), columnType: ColumnType.Text, RemoveBorder: true));
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: _encryptionService.DecryptText(item.HospitalName).ToString(), columnType: ColumnType.Text, RemoveBorder: true));
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: _encryptionService.DecryptText( item.ContactPerson.ToString()), columnType: ColumnType.Text, RemoveBorder: true));
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: item.DoctorName.ToString(), columnType: ColumnType.Text, RemoveBorder: true));
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: item.Room.ToString(), columnType: ColumnType.Text, RemoveBorder: true));
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: item.EquipmentName.ToString(), columnType: ColumnType.Text, RemoveBorder: true));
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: item.EquipSerial.ToString(), columnType: ColumnType.Number, RemoveBorder: true));
                var StringPMDate = "";
                if (item.PMDate != null)
                {
                    var PMDate = Convert.ToDateTime(item.PMDate);

                    StringPMDate = PMDate.ToShortDateString();
                }
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: StringPMDate, columnType: ColumnType.Number, RemoveBorder: true));
                
                table.AddCell(_pdfCommonSettings.GetBodyCell(text: item.TreatmentStatus.ToString(), columnType: ColumnType.Text, RemoveBorder: true));

            }

            doc.Add(table);
        }

    

        #endregion
    }


    #region PageFooter Footer
    public class PageFooter : PdfPageEventHelper
    {
        private IPDFCommonSettings _pdfCommonSettings;
        public PdfPTable table;

        public PageFooter(IPDFCommonSettings pdfCommonSettings)
        {
            this._pdfCommonSettings = pdfCommonSettings;
        }
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            document.SetPageSize(PageSize.A4.Rotate());
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            tabFot.SpacingAfter = 10F;
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase(""));
            cell.Border = Rectangle.NO_BORDER;
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
        }



        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            DateTime horario = DateTime.Now;
            base.OnEndPage(writer, document);


            table.WriteSelectedRows(0, -1, 40, document.Bottom + table.TotalHeight + 10, writer.DirectContent);
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }
    #endregion

}

