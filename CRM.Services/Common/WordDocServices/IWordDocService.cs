using CRM.Core.ViewModels.TreatmentRecord;
using System.IO;

namespace CRM.Services.Common.WordDocServices
{
    public interface IWordDocService
    {
        void PrintTreatmentRecordToWord(Stream stream, TreatmentRecordsPaginationModel TreatmentReport);
    }
}
