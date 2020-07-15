using CRM.Core.Domain.TreatmentRecords;
using CRM.Core.ViewModels.TreatmentRecord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace CRM.Services.Common.PDFServices
{
    public interface IPDFService
    {
        #region TreatmentRecord


        /// <summary>
        /// List for TreatmentRecord Print
        /// </summary>
        /// <param name="stream"></param>
        /// <param name=""></param>
        void PrintTreatmentRecordToPdf(Stream stream, IList<TreatmentRecordVM> TreatmentRecordList);
        #endregion

    }
}
