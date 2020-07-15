using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Result
{
    public static class ValidationMessages
    {
        public static string Success = "Success";
        public static string Failure = "Failure";

        public static string PalletCreateSuccess = "Pallet is Created Successfully";
        public static string PackingPalletCreateSuccess = "Packing Pallet is Created Successfully";
        public static string PalletDeleteSuccess = "Pallet Deleted Successfully";
        public static string PalletCreateFailed = "Error while creating pallet";
        public static string PalletStockInSuccess = "Pallet is Stocked";
        public static string PalletStockInAlreadyExist = "Pallet is already Stocked in Bin";
        public static string PalletStockInFailed = "Error while pallet stock in process";
        public static string PalletClearSuccess = "Pallet is clear";
        public static string PalletClearFailed = "Error while clearing pallet";
        public static string MobileUserError = "Unknown";
        public static string PalletUpdate = "Pallet is Update Successfully";
        public static string BinsTagNotFound = "Bins Tag Not Found";
        public static string PalletTagNotFound = "Pallet Tag Not Found";
    }
}
