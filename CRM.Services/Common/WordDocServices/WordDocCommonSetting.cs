using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;


namespace CRM.Services.Common.WordDocServices
{
    public class WordDocCommonSetting : IWordDocCommonSetting
    {
        public TableCell GetCell(string text, string Width)
        {
            return new TableCell(new Paragraph(new Run(new Text(text))), new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = Width })); ;
        }
        public TableProperties tableProperties()
        {
            TableProperties props = new TableProperties(
                            new TableBorders(
                            new TopBorder
                            {
                                Val = new EnumValue<BorderValues>(BorderValues.Thick),
                                Color = "CC0000"
                            },
                            new BottomBorder
                            {
                                Val = new EnumValue<BorderValues>(BorderValues.Thick),
                                Color = "CC0000"
                            },

                            new InsideHorizontalBorder
                            {

                                Val = new EnumValue<BorderValues>(BorderValues.Thick),
                                Color = "CC0000"
                            }));
            return props;
        }
    }
}
