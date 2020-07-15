using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CRM.Services.Common
{
    public interface IExcelService
    {
        MemoryStream CreateExcel(object list, MemoryStream stream, string FileName);
    }
}
