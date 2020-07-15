using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CRM.Services.Common.PDFServices
{
    public interface IPDFCommonSettings
    {
        PdfPCell GetCell(string text, Font font);
        Phrase GetBodyCellItem(string text);
        PdfPCell GetMainHeaderAddressCell(string text);
        PdfPCell GetHeaderCell(string text);
        PdfPCell GetHeaderBodyCell(string text);
        PdfPCell GetBodyCell(string text, ColumnType columnType = ColumnType.Text, bool IsHeader = false, bool RemoveBorder = false,bool RemoveLeftBorder = false, bool RemoveRightBorder = false, bool RemoveBottomBorder = false, bool RemoveTopBorder = false, bool KeepTopBorder = false, bool IsTransparentBackground = false, bool IsTableHeader = false, bool IsTableBody = false);
        PdfPCell GetLogoCell();
        PdfPCell GetReportHeaderCell(string text, int Colspan = 2);
        Image GetBarcodeCell(string Code, PdfWriter writer);

        PdfPCell GetCellWithColspan(string text, int columnSpan, bool IsDisclaimerText = false, bool RemoveBorder = false, bool KeepTopBorder = false);

        #region Barcode Print
        PdfPCell GetCellForBarcodePrint(string text, int Size, int FontType, int Align = Element.ALIGN_LEFT,int colspan =0,  bool RemoveBorder = false,
             bool RemoveLeftBorder = false,
            bool RemoveRightBorder = false,
            bool RemoveBottomBorder = false,
            bool RemoveTopBorder = false,
            bool KeepTopBorder = false);
        #endregion

    }
}
