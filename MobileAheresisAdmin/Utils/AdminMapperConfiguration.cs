using AutoMapper;

using CRM.Core.Domain.Common;
using CRM.Core.Domain.CompanyProfiles;
using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Equipments;
using CRM.Core.Domain.Nurses;
using MobileAheresisAdmin.Models;
using MobileAheresisAdmin.Models.CompanyProfiles;
using MobileAheresisAdmin.Models.Equipments;
using MobileAheresisAdmin.Models.Nurses;
using MobileAheresisAdmin.Models.UsersRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MobileAheresisAdmin.Utils
{
    public class AdminMapperConfiguration : Profile
    {
        public AdminMapperConfiguration()
        {
            CreateMap<NurseMaster, NurseModel>()



                .ForMember(dest => dest.Document, mo => mo.Ignore())
                .ForMember(dest => dest.DocumentTypeId, mo => mo.Ignore())
                .ForMember(dest => dest.DocumentType, mo => mo.Ignore());


                //.ForMember(dest => dest.FirstNameRequired, mo => mo.Ignore())
                //.ForMember(dest => dest.LastNameEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastNameRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.EmailEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.EmailRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.CompanyEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.CompanyRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.CountryEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.CountryRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.StateProvinceEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.CityEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.CityRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.StreetAddressEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.StreetAddressRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.StreetAddress2Enabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.StreetAddress2Required, mo => mo.Ignore())
            //            .ForMember(dest => dest.ZipPostalCodeEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.ZipPostalCodeRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.PhoneEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.PhoneRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.FaxEnabled, mo => mo.Ignore())
            //            .ForMember(dest => dest.FaxRequired, mo => mo.Ignore())
            //            .ForMember(dest => dest.CountryName,
            //                mo => mo.MapFrom(src => src.Country != null ? src.Country.Name : null))
            //            .ForMember(dest => dest.StateProvinceName,
            //                mo => mo.MapFrom(src => src.StateProvince != null ? src.StateProvince.Name : null));

            //        CreateMap<AddressModel, Address>()
            //            .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
            //            .ForMember(dest => dest.Country, mo => mo.Ignore())

            //            .ForMember(dest => dest.StateProvince, mo => mo.Ignore());


            //        //manufacturer
            //        CreateMap<Manufacturer, ManufacturerModel>();


            //        CreateMap<ManufacturerModel, Manufacturer>()

            //            .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
            //            .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore())
            //            .ForMember(dest => dest.Deleted, mo => mo.Ignore());


            //        //category
            //        CreateMap<Category, CategoryModel>()

            //            .ForMember(dest => dest.AvailableCategories, mo => mo.Ignore());


            //        CreateMap<CategoryModel, Category>()
            //            .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
            //            .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore())
            //            .ForMember(dest => dest.Deleted, mo => mo.Ignore());

            //        //products
            //        CreateMap<Product, ProductModel>()

            //            .ForMember(dest => dest.CreatedOn, mo => mo.Ignore())
            //            .ForMember(dest => dest.UpdatedOn, mo => mo.Ignore())
            //            .ForMember(dest => dest.AvailableManufacturers, mo => mo.Ignore())
            //            .ForMember(dest => dest.CustomerName, mo => mo.Ignore())
            //            .ForMember(dest => dest.ProductWarehouseInventoryModels, mo => mo.Ignore())
            //            .ForMember(dest => dest.SelectedManufacturerIds, mo => mo.Ignore());
            //        // .ForMember(dest => dest.Picture, mo => mo.Ignore());
            //        CreateMap<ProductModel, Product>()

            //            .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
            //            .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore())
            //            .ForMember(dest => dest.Deleted, mo => mo.Ignore())
            //            .ForMember(dest => dest.ProductManufacturers, mo => mo.Ignore())
            //            .ForMember(dest => dest.ProductWarehouseInventory, mo => mo.Ignore())
            //            .ForMember(dest => dest.ManageInventoryMethod, mo => mo.Ignore());
            //        //.ForMember(dest => dest.Picture.PictureName, mo => mo.Ignore())
            //        //  .ForMember(dest => dest.Picture.MimeType, mo => mo.Ignore())
            //        //   .ForMember(dest => dest.Picture.TitleAttribute, mo => mo.Ignore())
            //        //   .ForMember(dest => dest.Picture.AltAttribute, mo => mo.Ignore());


            //       company profile
            CreateMap<CompanyProfile, CompanyProfileModel>()
                .ForMember(dest => dest.Username, mo => mo.Ignore())
                .ForMember(dest => dest.Text, mo => mo.Ignore())
                .ForMember(dest => dest.IsPolicy, mo => mo.Ignore())
                .ForMember(dest => dest.DocumentName, mo => mo.Ignore())
                ;

            CreateMap<Equipment, EquipmentModel>()
               .ForMember(dest => dest.EqpDocumentId, mo => mo.Ignore())
            
               ;

            
            //CreateMap<CompanyProfileModel, CompanyProfile>()

            //   .ForMember(dest => dest.PoliciesAndProcedures, mo => mo.Ignore());


            //        //Bins 
            //        CreateMap<Bins, BinsModel>()

            //            .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        CreateMap<BinsModel, Bins>()

            //            .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        //Warehouse ReceivingLog 
            //        CreateMap<WRReceivingLog, WRReceivingLogModel>()
            //            .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //            .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        CreateMap<WRReceivingLogModel, WRReceivingLog>()
            //             .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //            .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());



            //        //Warehouse Receiving ProductLog 
            //        CreateMap<WRReceivingProducts, WRReceivingProductsModel>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        CreateMap<WRReceivingProductsModel, WRReceivingProducts>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());


            //        //Warehouse ReceivingLog 
            //        CreateMap<WRDeliveryRequest, WRDeliveryRequestModel>()
            //            .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //            .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        CreateMap<WRDeliveryRequestModel, WRDeliveryRequest>()
            //             .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //            .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());



            //        //Warehouse Receiving ProductLog 
            //        CreateMap<WRReceivingProducts, WRReceivingProductsModel>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        CreateMap<WRReceivingProductsModel, WRReceivingProducts>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());


            //        //WRPickupList
            //        CreateMap<WRPickupList, WRPickupListModel>()
            //           .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //            .ForMember(dest => dest.ConsigneeAddress, mo => mo.Ignore())
            //             // .ForMember(dest => dest.ShipperAddress, mo => mo.Ignore())
            //                .ForMember(dest => dest.CustomerAddress, mo => mo.Ignore())
            //           .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //           .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore())
            //          //.ForMember(dest => dest.Shipper, mo => mo.Ignore())
            //          ;

            //        CreateMap<WRPickupList, PickupListProcessViewModel>()

            //.ForMember(dest => dest.ConsigneeAddress, mo => mo.Ignore())
            //  .ForMember(dest => dest.ShipperAddress, mo => mo.Ignore())
            //    .ForMember(dest => dest.CustomerAddress, mo => mo.Ignore())
            //.ForMember(dest => dest.CheckOneByUser, mo => mo.Ignore())
            // .ForMember(dest => dest.CheckTwoByUser, mo => mo.Ignore())

            //    .ForMember(dest => dest.CustomerName, mo => mo.Ignore())
            //    .ForMember(dest => dest.PackingByUser, mo => mo.Ignore())
            //       .ForMember(dest => dest.PickedQty, mo => mo.Ignore())
            //          .ForMember(dest => dest.PickupByUser, mo => mo.Ignore())
            //             .ForMember(dest => dest.PickupProgress, mo => mo.Ignore())
            //              .ForMember(dest => dest.ShipperName, mo => mo.Ignore())
            //              .ForMember(dest => dest.ShipperName, mo => mo.Ignore())
            //  .ForMember(dest => dest.OrderQty, mo => mo.Ignore());

            //        CreateMap<WRPickupListModel, WRPickupList>()
            //             .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //               .ForMember(dest => dest.ConsigneeAddress, mo => mo.Ignore())
            //                //.ForMember(dest => dest.ShipperAddress, mo => mo.Ignore())

            //            .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore())
            //          //.ForMember(dest => dest.Shipper, mo => mo.Ignore())
            //          ;

            //        //Warehouse PickupList ProductLog 
            //        CreateMap<WRPickupListProducts, WRPickupListProductsModel>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        CreateMap<WRPickupListProductsModel, WRPickupListProducts>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());


            //        //WRShippingRequest
            //        CreateMap<WRShippingRequest, WRShippingRequestModel>()
            //           .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //           .ForMember(dest => dest.ConsigneeAddress, mo => mo.Ignore())
            //             .ForMember(dest => dest.CustomerAddress, mo => mo.Ignore())
            //               .ForMember(dest => dest.ShipperAddress, mo => mo.Ignore())

            //           .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore())
            //             .ForMember(dest => dest.Shipper, mo => mo.Ignore());

            //        CreateMap<WRShippingRequestModel, WRShippingRequest>()
            //             .ForMember(dest => dest.Customer, mo => mo.Ignore())
            //               .ForMember(dest => dest.ConsigneeAddress, mo => mo.Ignore())
            //                 .ForMember(dest => dest.ShipperAddress, mo => mo.Ignore())


            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore())
            //             .ForMember(dest => dest.Shipper, mo => mo.Ignore());
            //        //.ForMember(dest => dest.BillingAddress, mo => mo.Ignore())
            //        // .ForMember(dest => dest.ShippingAddress, mo => mo.Ignore())
            //        //   .ForMember(dest => dest.ShipperAddress, mo => mo.Ignore())
            //        //       .ForMember(dest => dest.Customer.BillingAddress, mo => mo.Ignore())
            //        //       .ForMember(dest => dest.Customer.ShippingAddress, mo => mo.Ignore())
            //        //        .ForMember(dest => dest.Shipper.BillingAddress, mo => mo.Ignore())
            //        //       .ForMember(dest => dest.Shipper.ShippingAddress, mo => mo.Ignore());


            //        //Warehouse ShippingRequest ProductLog 
            //        CreateMap<WRShippingRequestProducts, WRShippingRequestProductsModel>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            //        CreateMap<WRShippingRequestProductsModel, WRShippingRequestProducts>()

            //            .ForMember(dest => dest.CreatedDate, mo => mo.Ignore())
            //            .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());



            //        //Vendor

            //        CreateMap<Vendor, VendorModel>()

            //         .ForMember(dest => dest.PictureId, mo => mo.Ignore());


            //        CreateMap<VendorModel, Vendor>()

            //            .ForMember(dest => dest.CustomerId, mo => mo.Ignore());



            //customer role
            CreateMap<CustomerRoleModel, CustomerRole>()
             .ForMember(dest => dest.PermissionRecord_Role_Mapping, mo => mo.Ignore());



            ////Pallet Model 
            //CreateMap<Pallet, PalletModel>()
            //     .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //      .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());

            ////Line Model 
            //CreateMap<Line, LineModel>()
            //     .ForMember(dest => dest.SelectedLines, mo => mo.Ignore());

            //CreateMap<LineModel, Line>()
            //    .ForMember(dest => dest.UserId, mo => mo.Ignore());

            ////Pallet Model 
            //CreateMap<PalletBarcodes, PalletBarcodeModel>()
            //     .ForMember(dest => dest.CreateDate, mo => mo.Ignore())
            //      .ForMember(dest => dest.LastUpdateDate, mo => mo.Ignore());


            ////StockInModel 
            //CreateMap<StockInPallet, StockInModel>()

            // .ForMember(dest => dest.BinName, mo => mo.Ignore());


            ////Customer Bill Model 
            //CreateMap<CustomerBill, CustomerBillViewModel>()
            //     .ForMember(dest => dest.Selected, mo => mo.Ignore())
            //     .ForMember(dest => dest.CustomerName, mo => mo.Ignore())
            //     .ForMember(dest => dest.Term, mo => mo.Ignore())
            //.ForMember(dest => dest.TotalRecords, mo => mo.Ignore());

            ////Customer Bill Model 
            //CreateMap<CustomerBillViewModel, CustomerBill>()
            //     .ForMember(dest => dest.Status, mo => mo.Ignore());


            //CreateMap<WarehouseReceiptModel, WarehouseReceipt>()

            //   .ForMember(dest => dest.HandlingRepositories, mo => mo.Ignore())
            //   .ForMember(dest => dest.Shipper, mo => mo.Ignore())
            //   .ForMember(dest => dest.Consignee, mo => mo.Ignore())
            //   .ForMember(dest => dest.ConsigneeAddress, mo => mo.Ignore())
            //  .ForMember(dest => dest.ShipperAddress, mo => mo.Ignore()) ;

            //CreateMap<WarehouseReceipt, WarehouseReceiptModel>()

            //   .ForMember(dest => dest.AvailableHandlings, mo => mo.Ignore())
            //   .ForMember(dest => dest.SelectedHandelingIds, mo => mo.Ignore());
            //CreateMap<WarehouseDetails, WarehouseDetailsModel>()

            //   .ForMember(dest => dest.RowId, mo => mo.Ignore());
            //CreateMap<WarehouseCharges, WarehouseChargesModel>()

            // .ForMember(dest => dest.RowId, mo => mo.Ignore());
            //CreateMap<InvoiceModel, InvoiceMaster>()

            //.ForMember(dest => dest.InvoiceItemsMaster, mo => mo.Ignore());
            
        }
    }
}
