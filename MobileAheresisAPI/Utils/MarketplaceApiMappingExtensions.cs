
using CRM.Core.Domain.TreatmentRecords;
using CRM.Core.Infrastructure;

using MobileAheresisAPI.Models;
using MobileAheresisAPI.Models.TreatmentRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Utils
{
    public static class MarketplaceApiMappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }
        #region MachineMaster

        public static MachineModel ToModel(this MachineMaster entity)
        {
            return entity.MapTo<MachineMaster, MachineModel>();
        }
        public static List<MachineModel> ToModel(this List<MachineMaster> entity)
        {
            return entity.MapTo<List<MachineMaster>, List<MachineModel>>();
        }
        public static MachineMaster ToEntity(this MachineModel model)
        {
            return model.MapTo<MachineModel, MachineMaster>();
        }

        public static List<MachineMaster> ToEntity(this List<MachineModel> model, List<MachineMaster> destination)
        {
            return model.MapTo(destination);
        }
        #endregion
       

        #region LabValues
        public static List<LabValuesModel> ToModel(this List<LabValues> entity)
        {

            return entity.MapTo<List<LabValues>, List<LabValuesModel>>();
        }
        public static LabValuesModel ToModel(this LabValues entity)
        {
            return entity.MapTo<LabValues, LabValuesModel>();
        }

        public static LabValues ToEntity(this LabValuesModel model)
        {
            return model.MapTo<LabValuesModel, LabValues>();
        }
        public static LabValues ToEntity(this LabValuesModel model, LabValues destination)
        {
            return model.MapTo(destination);
        }
        #endregion
        #region WrPickupListProduct

        public static OtherLabValuesModel ToModel(this OtherLabValues entity)
        {
            return entity.MapTo<OtherLabValues, OtherLabValuesModel>();
        }

        public static OtherLabValues ToEntity(this OtherLabValuesModel model)
        {
            return model.MapTo<OtherLabValuesModel, OtherLabValues>();
        }

        public static List<OtherLabValues> ToEntity(this List<OtherLabValuesModel> model, List<OtherLabValues> destination)
        {
            return model.MapTo(destination);
        }
        #endregion


        //#region Product Report
        //public static List<WRReceivingLogReportResponseViewModel> ToModelReport(this List<WRReceivingLog> entity)
        //{

        //    return entity.MapTo<List<WRReceivingLog>, List<WRReceivingLogReportResponseViewModel>>();
        //}
        //public static WRReceivingLogReportResponseViewModel ToModelReport(this WRReceivingLog entity)
        //{
        //    return entity.MapTo<WRReceivingLog, WRReceivingLogReportResponseViewModel>();
        //}

        //public static WRReceivingLog ToEntity(this WRReceivingLogReportResponseViewModel model)
        //{
        //    return model.MapTo<WRReceivingLogReportResponseViewModel, WRReceivingLog>();
        //}
        //public static WRReceivingLog ToEntity(this WRReceivingLogReportResponseViewModel model, WRReceivingLog destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion


        //#region Pallet Report
        //public static List<PalletItemResponseModelByTag> ToModelReport(this List<Pallet> entity)
        //{
        //    return entity.MapTo<List<Pallet>, List<PalletItemResponseModelByTag>>();
        //}
        //public static PalletItemResponseModelByTag ToModelReport(this Pallet entity)
        //{
        //    return entity.MapTo<Pallet, PalletItemResponseModelByTag>();
        //}

        //public static Pallet ToEntity(this PalletItemResponseModelByTag model)
        //{
        //    return model.MapTo<PalletItemResponseModelByTag, Pallet>();
        //}
        //public static Pallet ToEntity(this PalletItemResponseModelByTag model, Pallet destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion

        //#region binsModel
        //public static List<BinsModel> ToModel(this List<Bins> entity)
        //{

        //    return entity.MapTo<List<Bins>, List<BinsModel>>();
        //}
        //public static BinsModel ToModel(this Bins entity)
        //{
        //    return entity.MapTo<Bins, BinsModel>();
        //}

        //public static Bins ToEntity(this BinsModel model)
        //{
        //    return model.MapTo<BinsModel, Bins>();
        //}
        //public static Bins ToEntity(this BinsModel model, Bins destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion

        //#region WrShippingModel
        //public static WRShippingRequestModel ToModel(this WRShippingRequest entity)
        //{
        //    return entity.MapTo<WRShippingRequest, WRShippingRequestModel>();
        //}

        //public static WRShippingRequest ToEntity(this WRShippingRequestModel model)
        //{
        //    return model.MapTo<WRShippingRequestModel, WRShippingRequest>();
        //}

        //public static WRShippingRequest ToEntity(this WRShippingRequestModel model, WRShippingRequest destination)
        //{
        //    return model.MapTo(destination);
        //}


        //public static WRShippingRequestProductsModel ToModel(this WRShippingRequestProducts entity)
        //{
        //    return entity.MapTo<WRShippingRequestProducts, WRShippingRequestProductsModel>();
        //}

        //public static WRShippingRequestProducts ToEntity(this WRShippingRequestProductsModel model)
        //{
        //    return model.MapTo<WRShippingRequestProductsModel, WRShippingRequestProducts>();
        //}

        //public static WRShippingRequestProducts ToEntity(this WRShippingRequestProductsModel model, WRShippingRequestProducts destination)
        //{
        //    return model.MapTo(destination);
        //}




        //#endregion
        //#region Picking
        //public static PickupListProcessViewModel ToProcessModel(this WRPickupList entity)
        //{
        //    return entity.MapTo<WRPickupList, PickupListProcessViewModel>();
        //}
        //#endregion



        //#region Warehouse Receipt
        //public static WarehouseReceiptModel ToModel(this WarehouseReceipt entity)
        //{
        //    return entity.MapTo<WarehouseReceipt, WarehouseReceiptModel>();
        //}

        //public static WarehouseReceipt ToEntity(this WarehouseReceiptModel model)
        //{
        //    return model.MapTo<WarehouseReceiptModel, WarehouseReceipt>();
        //}

        //public static WarehouseReceipt ToEntity(this WarehouseReceiptModel model, WarehouseReceipt destination)
        //{
        //    return model.MapTo(destination);
        //}


        //public static WarehouseDetailsModel ToModel(this WarehouseDetails entity)
        //{
        //    return entity.MapTo<WarehouseDetails, WarehouseDetailsModel>();
        //}

        //public static WarehouseDetails ToEntity(this WarehouseDetailsModel model)
        //{
        //    return model.MapTo<WarehouseDetailsModel, WarehouseDetails>();
        //}

        //public static WarehouseDetails ToEntity(this WarehouseDetailsModel model, WarehouseDetails destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion


        //#region  
        //public static List<WRPickupProductBinsModel> ToModel(this List<WRPickupProductBins> entity)
        //{

        //    return entity.MapTo<List<WRPickupProductBins>, List<WRPickupProductBinsModel>>();
        //}
        //#endregion 
    }
}
