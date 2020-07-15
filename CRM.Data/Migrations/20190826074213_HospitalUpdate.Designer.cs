﻿// <auto-generated />
using System;
using CRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM.Data.Migrations
{
    [DbContext(typeof(dbContextCRM))]
    [Migration("20190826074213_HospitalUpdate")]
    partial class HospitalUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM.Core.Domain.Common.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("CustomAttributes");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("FaxNumber");

                    b.Property<string>("FirstName");

                    b.Property<int?>("HospitalMasterId");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("StateProvince");

                    b.Property<string>("ZipPostalCode");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HospitalMasterId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CRM.Core.Domain.Common.ReportSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReportName")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("RowCount");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ReportSetting");
                });

            modelBuilder.Entity("CRM.Core.Domain.CompanyProfiles.CompanyDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyProfileId");

                    b.Property<string>("DocumentName");

                    b.Property<string>("DocumentPath");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProfileId");

                    b.ToTable("CompanyDocument");
                });

            modelBuilder.Entity("CRM.Core.Domain.CompanyProfiles.CompanyProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyAddressId");

                    b.Property<string>("Companyname");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<string>("License");

                    b.HasKey("Id");

                    b.HasIndex("CompanyAddressId");

                    b.ToTable("CompanyProfile");
                });

            modelBuilder.Entity("CRM.Core.Domain.CompanyProfiles.PolicyAndProcedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyProfileId");

                    b.Property<bool>("IsPolicy");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProfileId");

                    b.ToTable("PolicyAndProcedure");
                });

            modelBuilder.Entity("CRM.Core.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("BillingAddressId");

                    b.Property<DateTime?>("CannotLoginUntilDateUtc");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<Guid>("CustomerGuid");

                    b.Property<int>("CustomerRoleId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .HasMaxLength(1000);

                    b.Property<int>("FailedLoginAttempts");

                    b.Property<bool>("IsSystemAccount");

                    b.Property<DateTime>("LastActivityDateUtc");

                    b.Property<string>("LastIpAddress");

                    b.Property<DateTime?>("LastLoginDateUtc");

                    b.Property<bool>("RequireReLogin");

                    b.Property<string>("SystemName")
                        .HasMaxLength(400);

                    b.Property<string>("Username")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("BillingAddressId");

                    b.HasIndex("CustomerRoleId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CRM.Core.Domain.Customers.CustomerPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("PasswordFormat");

                    b.Property<int>("PasswordFormatId");

                    b.Property<string>("PasswordSalt");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerPassword");
                });

            modelBuilder.Entity("CRM.Core.Domain.Customers.CustomerRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("SystemName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerRole");
                });

            modelBuilder.Entity("CRM.Core.Domain.Directory.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowsBilling");

                    b.Property<bool>("AllowsShipping");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("NumericIsoCode");

                    b.Property<bool>("Published");

                    b.Property<bool>("SubjectToVat");

                    b.Property<string>("ThreeLetterIsoCode")
                        .HasMaxLength(3);

                    b.Property<string>("TwoLetterIsoCode")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CRM.Core.Domain.Directory.StateProvince", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(100);

                    b.Property<int>("CountryId");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Published");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("StateProvince");
                });

            modelBuilder.Entity("CRM.Core.Domain.Hospitals.HospitalMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("Deleted");

                    b.Property<int?>("HospitalAddressId");

                    b.Property<string>("HospitalName");

                    b.Property<DateTime>("LastUpdated");

                    b.HasKey("Id");

                    b.HasIndex("HospitalAddressId");

                    b.ToTable("HospitalMaster");
                });

            modelBuilder.Entity("CRM.Core.Domain.Media.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltAttribute");

                    b.Property<string>("MimeType");

                    b.Property<byte[]>("PictureBinary");

                    b.Property<string>("PictureName");

                    b.Property<string>("Picturepath");

                    b.Property<byte[]>("ThumbnailBinary");

                    b.Property<string>("TitleAttribute");

                    b.HasKey("Id");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("CRM.Core.Domain.Printers.Printer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PrinterCloudSettingId");

                    b.Property<string>("PrinterId");

                    b.HasKey("Id");

                    b.HasIndex("PrinterCloudSettingId");

                    b.ToTable("Printer");
                });

            modelBuilder.Entity("CRM.Core.Domain.Printers.PrinterCloudSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KeyFilePath");

                    b.Property<string>("KeyFileSecreat");

                    b.Property<string>("ServiceAccountEmail");

                    b.Property<string>("ServiceName");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("PrinterCloudSetting");
                });

            modelBuilder.Entity("CRM.Core.Domain.Security.PermissionRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PermissionRecord");
                });

            modelBuilder.Entity("CRM.Core.Domain.Security.PermissionRecord_Role_Mapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerRoleId");

                    b.Property<int>("PermissionRecordId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRoleId");

                    b.HasIndex("PermissionRecordId");

                    b.ToTable("PermissionRecord_Role_Mapping");
                });

            modelBuilder.Entity("CRM.Core.Domain.Common.Address", b =>
                {
                    b.HasOne("CRM.Core.Domain.Customers.Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");

                    b.HasOne("CRM.Core.Domain.Hospitals.HospitalMaster")
                        .WithMany("Addresses")
                        .HasForeignKey("HospitalMasterId");
                });

            modelBuilder.Entity("CRM.Core.Domain.CompanyProfiles.CompanyDocument", b =>
                {
                    b.HasOne("CRM.Core.Domain.CompanyProfiles.CompanyProfile", "CompanyProfile")
                        .WithMany("CompanyDocuments")
                        .HasForeignKey("CompanyProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Core.Domain.CompanyProfiles.CompanyProfile", b =>
                {
                    b.HasOne("CRM.Core.Domain.Common.Address", "CompanyAddress")
                        .WithMany()
                        .HasForeignKey("CompanyAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Core.Domain.CompanyProfiles.PolicyAndProcedure", b =>
                {
                    b.HasOne("CRM.Core.Domain.CompanyProfiles.CompanyProfile", "CompanyProfile")
                        .WithMany("PoliciesAndProcedures")
                        .HasForeignKey("CompanyProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Core.Domain.Customers.Customer", b =>
                {
                    b.HasOne("CRM.Core.Domain.Common.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressId");

                    b.HasOne("CRM.Core.Domain.Customers.CustomerRole", "CustomerRole")
                        .WithMany()
                        .HasForeignKey("CustomerRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Core.Domain.Customers.CustomerPassword", b =>
                {
                    b.HasOne("CRM.Core.Domain.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Core.Domain.Customers.CustomerRole", b =>
                {
                    b.HasOne("CRM.Core.Domain.Customers.Customer")
                        .WithMany("CustomerRoles")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("CRM.Core.Domain.Directory.StateProvince", b =>
                {
                    b.HasOne("CRM.Core.Domain.Directory.Country", "Country")
                        .WithMany("StateProvinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Core.Domain.Hospitals.HospitalMaster", b =>
                {
                    b.HasOne("CRM.Core.Domain.Common.Address", "HospitalAddress")
                        .WithMany()
                        .HasForeignKey("HospitalAddressId");
                });

            modelBuilder.Entity("CRM.Core.Domain.Printers.Printer", b =>
                {
                    b.HasOne("CRM.Core.Domain.Printers.PrinterCloudSetting", "PrinterCloudSetting")
                        .WithMany("Printers")
                        .HasForeignKey("PrinterCloudSettingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Core.Domain.Security.PermissionRecord_Role_Mapping", b =>
                {
                    b.HasOne("CRM.Core.Domain.Customers.CustomerRole", "CustomerRole")
                        .WithMany("PermissionRecord_Role_Mapping")
                        .HasForeignKey("CustomerRoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM.Core.Domain.Security.PermissionRecord", "PermissionRecord")
                        .WithMany("PermissionRecord_Role_Mapping")
                        .HasForeignKey("PermissionRecordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
