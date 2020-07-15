using System;
using System.Collections.Generic;
using System.Text;
using CRM.Data.Interfaces;
using System.Linq;
using CRM.Core.Domain.Printers;

namespace CRM.Services.Printers
{
    public class PrinterCloudSettingService : IPrinterCloudSettingService
    {


        #region fields


        private readonly IRepository<PrinterCloudSetting> _printerCloudSetting;
     

        #endregion

        #region ctor
        public PrinterCloudSettingService(
            IRepository<PrinterCloudSetting> printerCloudSetting
          

          )

        {
            this._printerCloudSetting = printerCloudSetting;
         

        }
        #endregion
       

        public void DeletePrinterCloudSetting(PrinterCloudSetting printerCloudSetting)
        {

            if (printerCloudSetting == null)
                throw new ArgumentNullException("printer Cloud Setting");

            _printerCloudSetting.Delete(printerCloudSetting);
        }

        public PrinterCloudSetting GetPrinterCloudSetting()
        {
            var query = _printerCloudSetting.Table;
           return  query.FirstOrDefault();
        }

        public PrinterCloudSetting GetPrinterCloudSettingByUserId(int userid)
        {
            var query = from data in _printerCloudSetting.Table
                        where data.UserId == userid
                        select data;
           return  query.FirstOrDefault();
        }
        public PrinterCloudSetting GetPrinterCloudSettingById(int Id)
        {
            var query = from data in _printerCloudSetting.Table
                        where data.Id == Id
                        select data;
            return query.FirstOrDefault();
        }

        public void InsertPrinterCloudSetting(PrinterCloudSetting printerCloudSetting)
        {
            if (printerCloudSetting == null)
                throw new ArgumentNullException(nameof(printerCloudSetting));

            //insert
            _printerCloudSetting.Insert(printerCloudSetting);
        }

        public void UpdatePrinterCloudSetting(PrinterCloudSetting printerCloudSetting)
        {
            if (printerCloudSetting == null)
                throw new ArgumentNullException(nameof(printerCloudSetting));

            //update
            _printerCloudSetting.Update(printerCloudSetting);
        }
    }
}
