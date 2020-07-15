
using CRM.Core.Domain.Printers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Printers
{
   public interface IPrinterCloudSettingService
    {

       
        PrinterCloudSetting GetPrinterCloudSetting();
        PrinterCloudSetting GetPrinterCloudSettingByUserId(int userid);

        PrinterCloudSetting GetPrinterCloudSettingById(int Id);


        void InsertPrinterCloudSetting(PrinterCloudSetting printerCloudSetting);

        void UpdatePrinterCloudSetting(PrinterCloudSetting printerCloudSetting);

        void DeletePrinterCloudSetting(PrinterCloudSetting printerCloudSetting);
    }
}
