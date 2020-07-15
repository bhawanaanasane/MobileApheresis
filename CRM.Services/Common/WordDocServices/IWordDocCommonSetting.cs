using DocumentFormat.OpenXml.Wordprocessing;

namespace CRM.Services.Common.WordDocServices
{
    public interface IWordDocCommonSetting
    {
        TableCell GetCell(string text, string Width);

        TableProperties tableProperties();
    }
}
