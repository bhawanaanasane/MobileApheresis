using CRM.Core.Domain.TreatmentRecords;
using CRM.Core.ViewModels.TreatmentRecord;
using CRM.Services.Security;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;

namespace CRM.Services.Common.WordDocServices
{
    public  class WordDocService :IWordDocService
    {
        #region Fields
        private readonly IEncryptionService _encryptionService;
        private readonly IWordDocCommonSetting _wordDocCommonSetting;

        #endregion
        #region Ctor
        public WordDocService(IEncryptionService EncryptionService,
                              IWordDocCommonSetting WordDocCommonSetting) 
        {
            this._encryptionService = EncryptionService;
            this._wordDocCommonSetting = WordDocCommonSetting;
        }
        #endregion
        #region Common
        //protected virtual void PrintHeader(Document doc, Body body, string ReportName)
        //{
        //    var mainTable = new PdfPTable(new float[] { 80F, 30F })
        //    {
        //        RunDirection = PdfWriter.RUN_DIRECTION_LTR,
        //        WidthPercentage = 100f
        //    };
        //    mainTable.SpacingBefore = 4f;
        //    mainTable.HorizontalAlignment = Element.ALIGN_LEFT;

        //    #region Header Left
        //    PdfPCell leftTableCell = new PdfPCell();
        //    leftTableCell.Border = PdfPCell.NO_BORDER;
        //    //header
        //    var headerLeft = new PdfPTable(new float[] { 20F, 90F });
        //    headerLeft.WidthPercentage = 100f;
        //    headerLeft.SpacingAfter = 4f;
        //    headerLeft.DefaultCell.Border = Rectangle.NO_BORDER;

        //    headerLeft.AddCell(_pdfCommonSettings.GetLogoCell());
        //    //doc.Add(headerLeft);

        //    var cellHeader = _pdfCommonSettings.GetHeaderCell("Mobile Apheresis");
        //    cellHeader.MinimumHeight = 10;
        //    headerLeft.AddCell(cellHeader);

        //    var cellHeaderBody = _pdfCommonSettings.GetMainHeaderAddressCell("");
        //    cellHeaderBody.Border = Rectangle.NO_BORDER;

        //    headerLeft.AddCell(cellHeaderBody);

        //    leftTableCell.AddElement(headerLeft);
        //    mainTable.AddCell(leftTableCell);
        //    #endregion

        //    #region Header Right
        //    PdfPCell rightTableCell = new PdfPCell();
        //    rightTableCell.Border = PdfPCell.NO_BORDER;
        //    rightTableCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    var headerRight = new PdfPTable(new float[] { 50F, 50F })
        //    {
        //        RunDirection = PdfWriter.RUN_DIRECTION_RTL,
        //        WidthPercentage = 100f
        //    };

        //    //headerRight.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    //headerRight.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
        //    //headerRight.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    headerRight.DefaultCell.Border = Rectangle.NO_BORDER;
        //    var ReportNameCell = _pdfCommonSettings.GetReportHeaderCell(ReportName);
        //    ReportNameCell.MinimumHeight = 25;
        //    headerRight.AddCell(ReportNameCell);
        //    if (!string.IsNullOrEmpty(BarocdeID))
        //    {
        //        headerRight.AddCell(_pdfCommonSettings.GetBarcodeCell(BarocdeID, writer));
        //        headerRight.AddCell(_pdfCommonSettings.GetReportHeaderCell("    "));
        //        headerRight.AddCell(_pdfCommonSettings.GetBodyCell(text: BarocdeID, columnType: ColumnType.Text, RemoveBorder: true, IsHeader: true, IsTransparentBackground: true));
        //        headerRight.AddCell(_pdfCommonSettings.GetReportHeaderCell("    "));
        //    }

        //    rightTableCell.AddElement(headerRight);
        //    mainTable.AddCell(rightTableCell);
        //    #endregion
        //    doc.Add(mainTable);
        //}
        #endregion

        #region Treatment Record Word
        public void PrintTreatmentRecordToWord(Stream stream, TreatmentRecordsPaginationModel TreatmentReport)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, true))
            {
                wordDoc.AddMainDocumentPart();
                // siga a ordem
                Document doc = new Document();
                Body body = new Body();
               
                TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };
                TableStyle tableStyle = new TableStyle() { Val = "TableGrid", };
                Table table = new Table(tableStyle, tableWidth);
                // Make the table width 100% of the page width.

               

                table.AppendChild<TableProperties>(_wordDocCommonSetting.tableProperties());
                #region Table header
                //Header Table Row
                var headerTr = new TableRow();
                //Header Table column
                var Column1 = _wordDocCommonSetting.GetCell("Patient Name","10");
               
               
                // Add cell shading.
                var shading = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };

                Column1.Append(shading);
                headerTr.Append(Column1);

                var Column2 = _wordDocCommonSetting.GetCell("Nurse Name", "20");
               
                var shading1 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };

                Column2.Append(shading1);
                headerTr.Append(Column2);

                var Column3 = _wordDocCommonSetting.GetCell("Hospital Name", "30");
               
                var shading2 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };

                Column3.Append(shading2);
                headerTr.Append(Column3);

                var Column4 = _wordDocCommonSetting.GetCell("Contact Person", "40");
               
                var shading3 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };
                Column4.Append(shading3);
                headerTr.Append(Column4);

                var Column5 = _wordDocCommonSetting.GetCell("Doctor Name", "50");
                
                var shading5 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };
                Column5.Append(shading5);
                headerTr.Append(Column5);

                var Column6 = _wordDocCommonSetting.GetCell("Room", "10");
                
                var shading6 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };
                Column6.Append(shading6);
                headerTr.Append(Column6);

                var Column7 = _wordDocCommonSetting.GetCell("Equp Serial", "20");
                
                var shading7 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };
                Column7.Append(shading7);
                headerTr.Append(Column7);

                var Column8 = _wordDocCommonSetting.GetCell("Equp Name", "30");
                
                var shading8 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };
                Column8.Append(shading8);
                headerTr.Append(Column8);

                var Column9 = _wordDocCommonSetting.GetCell("PM Date", "40");
                
                var shading9 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };
                Column9.Append(shading9);
                headerTr.Append(Column9);

                var Column10 = _wordDocCommonSetting.GetCell("Treatment status", "50");
               
                var shading10 = new Shading()
                {

                    Color = "auto",
                    Fill = "ABCDEF",
                    Val = ShadingPatternValues.Clear
                };
                Column10.Append(shading10);
                headerTr.Append(Column10);

                table.Append(headerTr);
                #endregion

                #region Body
                

                foreach (var data in TreatmentReport.List)
                {
                    var BodyTr = new TableRow();
                    var BodyColumn1 = new TableCell();
                    BodyColumn1.Append(new Paragraph(new Run(new Text((data.PateintName != null) ? _encryptionService.DecryptText(data.PateintName) : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn1.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn1);

                    var BodyColumn2 = new TableCell();
                    BodyColumn2.Append(new Paragraph(new Run(new Text(((data.NurseFirstName != null) ? _encryptionService.DecryptText(data.NurseFirstName) : "") + ((data.NurseLastName != null) ? _encryptionService.DecryptText(data.NurseLastName) : "")))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn2.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn2);

                    var BodyColumn3 = new TableCell();
                    BodyColumn3.Append(new Paragraph(new Run(new Text((data.HospitalName != null) ? _encryptionService.DecryptText(data.HospitalName) : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn3.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn3);

                    var BodyColumn4 = new TableCell();
                    BodyColumn4.Append(new Paragraph(new Run(new Text((data.ContactPerson != null) ? _encryptionService.DecryptText(data.ContactPerson) : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn4.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn4);

                    var BodyColumn5 = new TableCell();
                    BodyColumn5.Append(new Paragraph(new Run(new Text((data.DoctorName != null) ? data.DoctorName : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn5.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn5);

                    var BodyColumn6 = new TableCell();
                    BodyColumn6.Append(new Paragraph(new Run(new Text((data.Room != null) ? data.Room : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn6.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn6);

                    var BodyColumn7 = new TableCell();
                    BodyColumn7.Append(new Paragraph(new Run(new Text((data.EquipSerial != null) ? _encryptionService.DecryptText(data.EquipSerial) : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn7.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn7);

                    var BodyColumn8 = new TableCell();
                    BodyColumn8.Append(new Paragraph(new Run(new Text((data.EquipmentName != null) ? data.EquipmentName : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn8.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn8);

                    var BodyColumn9 = new TableCell();
                    BodyColumn9.Append(new Paragraph(new Run(new Text((data.PMDate != null) ? Convert.ToDateTime(data.PMDate).ToShortDateString() : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn9.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                    BodyTr.Append(BodyColumn9);

                    var BodyColumn10 = new TableCell();
                    BodyColumn10.Append(new Paragraph(new Run(new Text((data.TreatmentStatusId != 0) ? ((TreatmentStatus)data.TreatmentStatusId).ToString() : ""))));
                    // Assume you want BodyColumns that are automatically sized.
                    BodyColumn10.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));

                    BodyTr.Append(BodyColumn10);
                    table.Append(BodyTr);
                }
                #endregion
                
                

                body.Append(table);

                doc.Append(body);


                wordDoc.MainDocumentPart.Document = doc;

                wordDoc.Close();
            }
        }
        #endregion
    }
}
