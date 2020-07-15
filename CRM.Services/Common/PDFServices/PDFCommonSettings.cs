using CRM.Core.Domain.Common;
using CRM.Services.Customers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using System;

namespace CRM.Services.Common.PDFServices
{
    public class PDFCommonSettings : IPDFCommonSettings
    {
        #region Fields
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAddressService _addressService;
        private readonly ICustomerService _cutomerService;
        public static string CommonFont = FontFactory.TIMES;
        public static string ReportNameFont = "Arial Bold";
        public static string ArialFont = "Arial";
        public static string BarcodeFont = "Code 128";

        public static int Small = 10;
        public static int Medium = 12;
        public static int Large = 14;


        public static int XSmall = 8;
        public static int XLarge = 18;

        public static int XXLarge = 22;


        public static BaseColor LightBackgroundColor = new BaseColor(242, 242, 242);
        public static BaseColor LightTextColor = new BaseColor(121, 121, 121);
        public static BaseColor XLightTextColor = new BaseColor(181, 181, 204);
        //181,181,204

        public static BaseColor DarkTextColor = BaseColor.BLACK;

        public static int HeaderBodyFontType = Font.NORMAL;
        public static int HeaderMainFontType = Font.BOLD;

        public static Font HeaderBody = FontFactory.GetFont(fontname: CommonFont, size: Small, style: HeaderBodyFontType, color: DarkTextColor);
        public static Font HeaderLarge = FontFactory.GetFont(fontname: ReportNameFont, size: XLarge, style: HeaderMainFontType, color: DarkTextColor);
        public static Font HeaderSmall = FontFactory.GetFont(fontname: CommonFont, size: Small, style: HeaderMainFontType, color: LightTextColor);
        public static Font Body = FontFactory.GetFont(fontname: CommonFont, size: Small, style: HeaderBodyFontType, color: LightTextColor);
        public static Font TableBody = FontFactory.GetFont(fontname: CommonFont, size: XSmall, style: HeaderBodyFontType, color: LightTextColor);
        public static Font BodyHeader = FontFactory.GetFont(fontname: ReportNameFont, size: Small, style: HeaderMainFontType, color: LightTextColor);
        public static Font DisclaimerText = FontFactory.GetFont(fontname: CommonFont, size: XSmall, style: HeaderMainFontType, color: LightTextColor);
        public static Font ReportHeader = FontFactory.GetFont(fontname: ReportNameFont, size: Large, style: HeaderMainFontType, color: XLightTextColor);
        public static Font CustomerBillingInfo = FontFactory.GetFont(fontname: CommonFont, size: Small, style: HeaderBodyFontType, color: DarkTextColor);

        #endregion

        #region Ctor
        public PDFCommonSettings(IHostingEnvironment HostingEnvironment,

            IAddressService AddressService)
        {
            this._hostingEnvironment = HostingEnvironment;
        }
        #endregion

        #region  methods

        public PdfPCell GetCell(string text, Font font)
        {
            return new PdfPCell(new Phrase(text, font));
        }

        public Phrase GetBodyCellItem(string text)
        {
            return new Phrase(text, Body);
        }
        public PdfPCell GetMainHeaderAddressCell(string text)
        {
            return new PdfPCell(new Phrase(text, HeaderBody));
        }

        public PdfPCell GetHeaderCell(string text)
        {
            var cell = GetCell(text: text, font: HeaderLarge);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Border = Rectangle.NO_BORDER;
            return cell;
        }

        public PdfPCell GetCellForBarcodePrint(string text,
            int Size, int FontType,
            int Align = Element.ALIGN_LEFT,
            int colspan = 0, bool RemoveBorder = false,
             bool RemoveLeftBorder = false,
            bool RemoveRightBorder = false,
            bool RemoveBottomBorder = false,
            bool RemoveTopBorder = false,
            bool KeepTopBorder = false)
        {
            Font TextFont = FontFactory.GetFont(fontname: ArialFont, size: Size, style: FontType, color: DarkTextColor);
            var cell = GetCell(text: text, font: TextFont);
            cell.HorizontalAlignment = Align;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.BorderWidth = 2f;
            if(colspan!=0)
            {
                cell.Colspan = colspan;
            }
            if (RemoveBorder)
            {
                cell.Border = Rectangle.NO_BORDER;
            }
            if (RemoveLeftBorder)
            {
                cell.BorderWidthLeft = Rectangle.NO_BORDER;
            }
            if (RemoveRightBorder)
            {
                cell.BorderWidthRight = Rectangle.NO_BORDER;
            }
            if (RemoveBottomBorder)
            {
                cell.BorderWidthBottom = Rectangle.NO_BORDER;
            }
            if (RemoveTopBorder)
            {
                cell.BorderWidthTop = Rectangle.NO_BORDER;
            }
            if (KeepTopBorder)
            {
                cell.Border = Rectangle.TOP_BORDER;
            }
            return cell;
        }


        public Image GetBarcodeCell(string Code, PdfWriter writer)
        {
            PdfContentByte cb = writer.DirectContent;
            Barcode128 code128 = new Barcode128();
            code128.Font = null;
            code128.Size = 12;
            code128.BarHeight = 20;
            code128.Code = Code;
            code128.StartStopText = true;
            Image image39 = code128.CreateImageWithBarcode(cb, null, null);
            return image39;
        }



        public PdfPCell GetReportHeaderCell(string text, int Colspan = 2)
        {
            var cell = GetCell(text: text, font: ReportHeader);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = Colspan;
            return cell;
        }

        public PdfPCell GetHeaderBodyCell(string text)
        {
            var cell = GetCell(text: text, font: HeaderBody);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            return cell;
        }


        //public PdfPCell GetSmallHeaderBodyCell(string text)
        //{
        //    var cell = GetPdfCell(text, HeaderLarge);
        //    cell.BackgroundColor = LightColor;
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.VerticalAlignment = Element.ALIGN_CENTER;
        //    return cell;
        //}

        public PdfPCell GetBodyCell(
            string text,
            ColumnType columnType = ColumnType.Text,
            bool IsHeader = false,
            bool RemoveBorder = false,
             bool RemoveLeftBorder = false,
            bool RemoveRightBorder = false,
            bool RemoveBottomBorder = false,
            bool RemoveTopBorder = false,
            bool KeepTopBorder = false,
            bool IsTransparentBackground = false,
            bool IsTableHeader = false,
            bool IsTableBody = false)
        {
            Font font;
            if (IsHeader)
            {
                font = BodyHeader;
            }
            else
            {
                if (IsTableBody)
                    font = TableBody;
                else
                    font = Body;
            }
            var cell = GetCell(text: text, font: font);


            switch (columnType)
            {
                case ColumnType.Text:
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingLeft = 5;

                    break;
                case ColumnType.Number:
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingLeft = 5;

                    break;
                default:
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;

                    break;

            }
            if (IsHeader)
            {
                if (!IsTransparentBackground)
                {
                    cell.BackgroundColor = LightBackgroundColor;
                }
            }
            cell.BorderColor = LightTextColor;
            if (RemoveBorder)
            {
                cell.Border = Rectangle.NO_BORDER;
            }
            if (RemoveLeftBorder)
            {
                cell.BorderWidthLeft = Rectangle.NO_BORDER;
            }
            if (RemoveRightBorder)
            {
                cell.BorderWidthRight = Rectangle.NO_BORDER;
            }
            if (RemoveBottomBorder)
            {
                cell.BorderWidthBottom = Rectangle.NO_BORDER;
            }
            if (RemoveTopBorder)
            {
                cell.BorderWidthTop = Rectangle.NO_BORDER;
            }
            if (KeepTopBorder)
            {
                cell.Border = Rectangle.TOP_BORDER;
            }
            if (IsTableHeader)
            {
                cell.BorderColorRight = LightBackgroundColor;
                cell.PaddingBottom = 5;
            }

            return cell;
        }

        public PdfPCell GetCellWithColspan(string text, int columnSpan, bool IsDisclaimerText = false, bool RemoveBorder = true, bool KeepTopBorder = false)
        {
            Font font;
            if (IsDisclaimerText)
            {
                font = DisclaimerText;
            }
            else
            {
                font = Body;
            }
            var cell = GetCell(text: text, font: font);

            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.BorderColor = LightTextColor;
            if (RemoveBorder)
            {
                cell.Border = Rectangle.NO_BORDER;
            }
            if (KeepTopBorder)
            {
                cell.Border = Rectangle.TOP_BORDER;
            }

            cell.Colspan = columnSpan;
            return cell;
        }

        public PdfPCell GetLogoCell()
        {

            var logoFilePath = _hostingEnvironment.WebRootPath + "/assets/img/logo.png";
            Image logo = Image.GetInstance(logoFilePath);
            logo.Alignment = Element.ALIGN_LEFT;
            logo.ScaleToFit(65, 65f);
           

            var cellLogo = new PdfPCell { Border = Rectangle.NO_BORDER };
            cellLogo.AddElement(logo);
            cellLogo.Rowspan = 2;
            return cellLogo;


        }

        #endregion
    }


    public enum ColumnType
    {
        Text,
        Number,
        Default
    }

}
