using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Common
{
    public class ResponceModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int TotalPickUpQty { get; set; }
        public int ShippingProductId { get; set; }
        public int WarehouseDetailsId { get; set; }
        public int ProductBarcodeId { get; set; }
        public int WarehouseChargesId { get; set; }
        public decimal AverageCubic { get; set; }
        public int RowId { get; set; }
        public string CustomerName { get; set; }

        public object file { get; set; }

      public int AppointmentDateId { get; set; }
    }
}
