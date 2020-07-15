
using CRM.Core.Domain.Common;
using CRM.Core.Infrastructure;
using CRM.Services.Common;

using CRM.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.Customers;

using PagedList.Core;
using MobileAheresisAdmin.Models;
using MobileAheresisAdmin.Models.UsersRole;
using MobileAheresisAdmin.Models.Addresses;
using MobileAheresisAdmin.Models.CompanyProfiles;
using CRM.Core.Domain.CompanyProfiles;
using MobileAheresisAdmin.Models.Nurses;
using CRM.Core.Domain.Nurses;
using MobileAheresisAdmin.Models.Equipments;
using CRM.Core.Domain.Equipments;

namespace MobileAheresisAdmin.Utils
{
    public static class MappingExtensions
    {

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region Address

        public static AddressModel ToModel(this Address entity)
        {
            return entity.MapTo<Address, AddressModel>();
        }

        public static Address ToEntity(this AddressModel model)
        {
            return model.MapTo<AddressModel, Address>();
        }

        public static Address ToEntity(this AddressModel model, Address destination)
        {
            return model.MapTo(destination);
        }




        #endregion

        #region Company Profile

        public static CompanyProfileModel ToModel(this CompanyProfile entity)
        {
            return entity.MapTo<CompanyProfile, CompanyProfileModel>();
        }
        public static CompanyProfile ToEntity(this CompanyProfileModel model)
        {
            return model.MapTo<CompanyProfileModel, CompanyProfile>();
        }

        #endregion


        #region Equipment 

        public static EquipmentModel ToModel(this Equipment entity)
        {
            return entity.MapTo<Equipment, EquipmentModel>();
        }
        public static Equipment ToEntity(this EquipmentModel model)
        {
            return model.MapTo<EquipmentModel, Equipment>();
        }

        #endregion

        #region WRPickUpList
        public static NurseModel ToModel(this NurseMaster entity)
        {
            return entity.MapTo<NurseMaster, NurseModel>();
        }

        public static NurseMaster ToEntity(this NurseModel model)
        {
            return model.MapTo<NurseModel, NurseMaster>();
        }

        public static NurseMaster ToEntity(this NurseModel model, NurseMaster destination)
        {
            return model.MapTo(destination);
        }

      

        //public static WRPickupList ToEntity(this PickupListProcessViewModel model)
        //{
        //    return model.MapTo<PickupListProcessViewModel, WRPickupList>();
        //}

        //public static WRPickupList ToEntity(this PickupListProcessViewModel model, WRPickupList destination)
        //{
        //    return model.MapTo(destination);
        //}


        public static NurseDocumentsModel ToModel(this NurseDocuments entity)
        {
            return entity.MapTo<NurseDocuments, NurseDocumentsModel>();
        }

        public static NurseDocuments ToEntity(this NurseDocumentsModel model)
        {
            return model.MapTo<NurseDocumentsModel, NurseDocuments>();
        }

        public static NurseDocuments ToEntity(this NurseDocumentsModel model, NurseDocuments destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        //#region Vendor

        //public static VendorModel ToModel(this Vendor entity)
        //{
        //    return entity.MapTo<Vendor, VendorModel>();
        //}
        //public static Vendor ToEntity(this VendorModel model)
        //{
        //    return model.MapTo<VendorModel, Vendor>();
        //}
        //public static Vendor ToEntity(this VendorModel model, Vendor destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion

        //#region Agent

        //public static AgentMasterModel ToModel(this AgentMaster entity)
        //{
        //    return entity.MapTo<AgentMaster, AgentMasterModel>();
        //}
        //public static AgentMaster ToEntity(this AgentMasterModel model)
        //{
        //    return model.MapTo<AgentMasterModel, AgentMaster>();
        //}
        //public static AgentMaster ToEntity(this AgentMasterModel model, AgentMaster destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion



      

        //#region Inland Carrier

        //public static InlandCarrierModel ToModel(this InlandCarrier entity)
        //{
        //    return entity.MapTo<InlandCarrier, InlandCarrierModel>();
        //}
        //public static InlandCarrier ToEntity(this InlandCarrierModel model)
        //{
        //    return model.MapTo<InlandCarrierModel, InlandCarrier>();
        //}
        //public static InlandCarrier ToEntity(this InlandCarrierModel model, InlandCarrier destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion

        //#region Cargo Type

        //public static CargoTypeModel ToModel(this CargoTypeMaster entity)
        //{
        //    return entity.MapTo<CargoTypeMaster, CargoTypeModel>();
        //}
        //public static CargoTypeMaster ToEntity(this CargoTypeModel model)
        //{
        //    return model.MapTo<CargoTypeModel, CargoTypeMaster>();
        //}
        //public static CargoTypeMaster ToEntity(this CargoTypeModel model, CargoTypeMaster destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion

        //#region Category

        //public static CategoryModel ToModel(this Category entity)
        //{
        //    return entity.MapTo<Category, CategoryModel>();
        //}

        //public static Category ToEntity(this CategoryModel model)
        //{
        //    return model.MapTo<CategoryModel, Category>();
        //}

        //public static Category ToEntity(this CategoryModel model, Category destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion


        //#region Product

        //public static ProductModel ToModel(this Product entity)
        //{
        //    return entity.MapTo<Product, ProductModel>();
        //}
        //public static IList<ProductModel> ToModelList(this IList<Product> entity)
        //{
        //    return entity.MapTo<IList<Product>, IList<ProductModel>>();
        //}
        //public static Product ToEntity(this ProductModel model)
        //{
        //    return model.MapTo<ProductModel, Product>();
        //}

        //public static Product ToEntity(this ProductModel model, Product destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion

        //#region ProductCatalog

        //public static ProductCatalogModel ToModel(this ProductCatalog entity)
        //{
        //    return entity.MapTo<ProductCatalog, ProductCatalogModel>();
        //}

        //public static ProductCatalog ToEntity(this ProductCatalogModel model)
        //{
        //    return model.MapTo<ProductCatalogModel, ProductCatalog>();
        //}

        //public static ProductCatalog ToEntity(this ProductCatalogModel model, ProductCatalog destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion

        //#region Customer
        //public static Customer ToEntity(this CustomerModel model)
        //{
        //    return model.MapTo<CustomerModel, Customer>();
        //}


        //public static CustomerModel ToModel(this Customer entity)
        //{
        //    return entity.MapTo<Customer, CustomerModel>();
        //}
        //public static Customer ToEntity(this CustomerModel model, Customer destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion

        #region Customer roles

        //customer roles
        public static CustomerRoleModel ToModel(this CustomerRole entity)
        {
            return entity.MapTo<CustomerRole, CustomerRoleModel>();
        }

        public static CustomerRole ToEntity(this CustomerRoleModel model)
        {
            return model.MapTo<CustomerRoleModel, CustomerRole>();
        }

        public static CustomerRole ToEntity(this CustomerRoleModel model, CustomerRole destination)
        {
            return model.MapTo(destination);
        }

        #endregion


        //#region Order

        //public static Order ToEntity(this OrderModel model)
        //{
        //    return model.MapTo<OrderModel, Order>();
        //}

        //public static OrderModel ToModel(this Order entity)
        //{
        //    return entity.MapTo<Order, OrderModel>();
        //}

        //#endregion

        //#region Warehouse

        //public static Warehouse ToEntity(this WarehouseModel model)
        //{
        //    return model.MapTo<WarehouseModel, Warehouse>();
        //}

        //public static WarehouseModel ToModel(this Warehouse entity)
        //{
        //    return entity.MapTo<Warehouse, WarehouseModel>();
        //}

        //#endregion

        //#region Tax categories

        //public static TaxCategoryModel ToModel(this TaxCategory entity)
        //{
        //    return entity.MapTo<TaxCategory, TaxCategoryModel>();
        //}
        //public static TaxCategory ToEntity(this TaxCategoryModel model)
        //{
        //    return model.MapTo<TaxCategoryModel, TaxCategory>();
        //}

        //public static TaxCategory ToEntity(this TaxCategoryModel model, TaxCategory destination)
        //{
        //    return model.MapTo(destination);
        //}


        //#endregion
       
        //#region Warehouse Management

        //#region Bins
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

        // #endregion


          
        //#region Line

        //public static LineModel ToModel(this Line entity)
        //{
        //    return entity.MapTo<Line, LineModel>();
        //}

        //public static Line ToEntity(this LineModel model)
        //{
        //    return model.MapTo<LineModel, Line>();
        //}

        //public static Line ToEntity(this LineModel model, Line destination)

        //{
        //    return model.MapTo(destination);
        //}

        //#endregion

        //#region Pallet

        //public static PalletModel ToModel(this Pallet entity)
        //{
        //    return entity.MapTo<Pallet, PalletModel>();
        //}

        //public static Pallet ToEntity(this PalletModel model)
        //{
        //    return model.MapTo<PalletModel, Pallet>();
        //}

        //public static Pallet ToEntity(this PalletModel model, Pallet destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion


        //#region StockIn

        //public static StockInModel ToModel(this StockInPallet entity)
        //{
        //    return entity.MapTo<StockInPallet, StockInModel>();
        //}

        //public static StockInPallet ToEntity(this StockInModel model)
        //{
        //    return model.MapTo<StockInModel, StockInPallet>();
        //}

        //public static StockInPallet ToEntity(this StockInModel model, StockInPallet destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion

        //#region  PalletBarcode
        //public static PalletBarcodeModel ToModel(this PalletBarcodes entity)
        //{
        //    return entity.MapTo<PalletBarcodes, PalletBarcodeModel>();
        //}

        //public static PalletBarcodes ToEntity(this PalletBarcodeModel model)
        //{
        //    return model.MapTo<PalletBarcodeModel, PalletBarcodes>();
        //}

        //public static PalletBarcodes ToEntity(this PalletBarcodeModel model, PalletBarcodes destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion
        //#endregion

        //#region WarehouseTransaction


        //public static WRReceivingLogModel ToModel(this WRReceivingLog entity)
        //{
        //    return entity.MapTo<WRReceivingLog, WRReceivingLogModel>();
        //}

        //public static WRReceivingLog ToEntity(this WRReceivingLogModel model)
        //{
        //    return model.MapTo<WRReceivingLogModel, WRReceivingLog>();
        //}

        //public static WRReceivingLog ToEntity(this WRReceivingLogModel model, WRReceivingLog destination)
        //{
        //    return model.MapTo(destination);
        //}


        //public static WRReceivingProductsModel ToModel(this WRReceivingProducts entity)
        //{
        //    return entity.MapTo<WRReceivingProducts, WRReceivingProductsModel>();
        //}

        //public static WRReceivingProducts ToEntity(this WRReceivingProductsModel model)
        //{
        //    return model.MapTo<WRReceivingProductsModel, WRReceivingProducts>();
        //}

        //public static WRReceivingProducts ToEntity(this WRReceivingProductsModel model, WRReceivingProducts destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#region WRDelivery Request

        //public static WRDeliveryRequestModel ToModel(this WRDeliveryRequest entity)
        //{
        //    return entity.MapTo<WRDeliveryRequest, WRDeliveryRequestModel>();
        //}

        //public static WRDeliveryRequest ToEntity(this WRDeliveryRequestModel model)
        //{
        //    return model.MapTo<WRDeliveryRequestModel, WRDeliveryRequest>();
        //}

        //public static WRDeliveryRequest ToEntity(this WRDeliveryRequestModel model, WRDeliveryRequest destination)
        //{
        //    return model.MapTo(destination);
        //}


        //public static WRDeliveryRequestProductsModel ToModel(this WRDeliveryRequestProducts entity)
        //{
        //    return entity.MapTo<WRDeliveryRequestProducts, WRDeliveryRequestProductsModel>();
        //}

        //public static WRDeliveryRequestProducts ToEntity(this WRDeliveryRequestProductsModel model)
        //{
        //    return model.MapTo<WRDeliveryRequestProductsModel, WRDeliveryRequestProducts>();
        //}

        //public static WRDeliveryRequestProducts ToEntity(this WRDeliveryRequestProductsModel model, WRDeliveryRequestProducts destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion
        //#endregion

        //#region WRPickUpList
        //public static WRPickupListModel ToModel(this WRPickupList entity)
        //{
        //    return entity.MapTo<WRPickupList, WRPickupListModel>();
        //}

        //public static WRPickupList ToEntity(this WRPickupListModel model)
        //{
        //    return model.MapTo<WRPickupListModel, WRPickupList>();
        //}

        //public static WRPickupList ToEntity(this WRPickupListModel model, WRPickupList destination)
        //{
        //    return model.MapTo(destination);
        //}

        //public static PickupListProcessViewModel ToProcessModel(this WRPickupList entity)
        //{
        //    return entity.MapTo<WRPickupList, PickupListProcessViewModel>();
        //}

        ////public static WRPickupList ToEntity(this PickupListProcessViewModel model)
        ////{
        ////    return model.MapTo<PickupListProcessViewModel, WRPickupList>();
        ////}

        ////public static WRPickupList ToEntity(this PickupListProcessViewModel model, WRPickupList destination)
        ////{
        ////    return model.MapTo(destination);
        ////}


        //public static WRPickupListProductsModel ToModel(this WRPickupListProducts entity)
        //{
        //    return entity.MapTo<WRPickupListProducts, WRPickupListProductsModel>();
        //}

        //public static WRPickupListProducts ToEntity(this WRPickupListProductsModel model)
        //{
        //    return model.MapTo<WRPickupListProductsModel, WRPickupListProducts>();
        //}

        //public static WRPickupListProducts ToEntity(this WRPickupListProductsModel model, WRPickupListProducts destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion

        //#region WRShippingRequest
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


        //#region ProductViewModel

        //public static ProductModel ToModel(this ProductVM entity)
        //{
        //    return entity.MapTo<ProductVM, ProductModel>();
        //}
        //public static IList<ProductModel> ToModelList(this IList<ProductVM> entity)
        //{
        //    return entity.MapTo<IList<ProductVM>, IList<ProductModel>>();
        //}

        //#endregion

        //#region Billing

        //public static CustomerBillViewModel ToModel(this CustomerBill entity)
        //{
        //    return entity.MapTo<CustomerBill, CustomerBillViewModel>();
        //}

        //public static CustomerBill ToEntity(this CustomerBillViewModel model)
        //{
        //    return model.MapTo<CustomerBillViewModel, CustomerBill>();
        //}

        //public static CustomerBill ToEntity(this CustomerBillViewModel model, CustomerBill destination)
        //{
        //    return model.MapTo(destination);
        //}
        //public static IList<CustomerBill> ToModelList(this IList<CustomerBillViewModel> entity)
        //{
        //    return entity.MapTo<IList<CustomerBillViewModel>, IList<CustomerBill>>();
        //}

        ////public static BillItemViewModel ToModel(this CustomerBill entity)
        ////{
        ////    return entity.MapTo<CustomerBill, BillItemViewModel>();
        ////}

        ////public static CustomerBill ToEntity(this BillItemViewModel model)
        ////{
        ////    return model.MapTo<BillItemViewModel, CustomerBill>();
        ////}

        ////public static CustomerBill ToEntity(this BillItemViewModel model, CustomerBill destination)
        ////{
        ////    return model.MapTo(destination);
        ////}

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

        ////public static PickupListProcessViewModel ToProcessModel(this WRPickupList entity)
        ////{
        ////    return entity.MapTo<WRPickupList, PickupListProcessViewModel>();
        ////}

        ////public static WRPickupList ToEntity(this PickupListProcessViewModel model)
        ////{
        ////    return model.MapTo<PickupListProcessViewModel, WRPickupList>();
        ////}

        ////public static WRPickupList ToEntity(this PickupListProcessViewModel model, WRPickupList destination)
        ////{
        ////    return model.MapTo(destination);
        ////}


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


        //#region Invoice
        //public static InvoiceModel ToModel(this InvoiceMaster entity)
        //{
        //    return entity.MapTo<InvoiceMaster, InvoiceModel>();
        //}

        //public static InvoiceMaster ToEntity(this InvoiceModel model)
        //{
        //    return model.MapTo<InvoiceModel, InvoiceMaster>();
        //}

        //public static InvoiceMaster ToEntity(this InvoiceModel model, InvoiceMaster destination)
        //{
        //    return model.MapTo(destination);
        //}

       

        //public static InvoiceItemsModel ToModel(this InvoiceItemsMaster entity)
        //{
        //    return entity.MapTo<InvoiceItemsMaster, InvoiceItemsModel>();
        //}

        //public static InvoiceItemsMaster ToEntity(this InvoiceItemsModel model)
        //{
        //    return model.MapTo<InvoiceItemsModel, InvoiceItemsMaster>();
        //}

        //public static InvoiceItemsMaster ToEntity(this InvoiceItemsModel model, InvoiceItemsMaster destination)
        //{
        //    return model.MapTo(destination);
        //}
        //#endregion

    }
}
