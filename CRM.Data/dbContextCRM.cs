using CRM.Core.Domain.Appointment;
using CRM.Core.Domain.Common;
using CRM.Core.Domain.CompanyProfiles;
using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Directory;
using CRM.Core.Domain.Equipments;
using CRM.Core.Domain.Hospitals;
using CRM.Core.Domain.Media;
using CRM.Core.Domain.Nurses;
using CRM.Core.Domain.Printers;
using CRM.Core.Domain.Security;
using CRM.Core.Domain.TreatmentMaster;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Core.ViewModels.CompanyProfiles;
using CRM.Core.ViewModels.Equipments;
using CRM.Core.ViewModels.Report;
using CRM.Core.ViewModels.TreatmentRecord;
using CRM.Data.Mapping.Appointment;
using CRM.Data.Mapping.Common;
using CRM.Data.Mapping.CompanyProfiles;
using CRM.Data.Mapping.Customers;
using CRM.Data.Mapping.Directory;
using CRM.Data.Mapping.Equipments;
using CRM.Data.Mapping.HospitalsMap;
using CRM.Data.Mapping.Nurses;
using CRM.Data.Mapping.Security;
using CRM.Data.Mapping.TreatmentRecords;
using CRM.Data.Mapping.Treatments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace CRM.Data
{
    public class dbContextCRM: DbContext
    {
        public dbContextCRM(DbContextOptions<dbContextCRM> options)
           : base(options)
        {

        }

        //ViewModels
        public DbQuery<CompanyProfileVM> CompanyProfileVM { get; set; }
        public DbQuery<EquipmentsVM> EquipmentsVM { get; set; }
        public DbQuery<TreatmentRecordVM> TreatmentRecordVM { get; set; }
        public DbQuery<TreatmentReportModel> TreatmentReportModel { get; set; }
        public DbQuery<OtherLabValuesVM> OtherLabValuesVM { get; set; }
        public DbQuery<RunValuesVM> RunValuesVM { get; set; }

        public DbQuery<AppointmentVM> AppointmentVM { get; set; }
        public DbQuery<AppoimtmentDateVM> AppoimtmentDateVM { get; set; }
        //Common
        public DbSet<Country> Country { get; set; }
        public DbSet<StateProvince> StateProvince { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ReportSetting> ReportSetting { get; set; }
        //companyprofile
        public DbSet<DownloadHistory> DownloadHistory { get; set; }

        public DbSet<CompanyProfile> CompanyProfile { get; set; }
        //TreatmentRecords
        public DbSet<PatientInfo> PatientInfo { get; set; }
        public DbSet<PatientMaster> PatientMaster { get; set; }

        public DbSet<DoctorInfo> DoctorInfo { get; set; }
        public DbSet<TreatmentRecordMaster> TreatmentRecordMaster { get; set; }
        public DbSet<MachineMaster> MachineMaster { get; set; }
         public DbSet<PreTreatmentCheck> PreTreatmentCheck { get; set; }

        public DbSet<OtherLabValues> OtherLabValues { get; set; }
            public DbSet<LabValues> LabValues { get; set; }
        public DbSet<SuppliesAndAccess> SuppliesAndAccess { get; set; }
       
        public DbSet<PreTreatmentAssessment> PreTreatmentAssessment { get; set; }
        public DbSet<RunValues> RunValues { get; set; }
        public DbSet<FinalValuesAndAccessPostAssessment> FinalValues { get; set; }
      
        public DbSet<Medication> Medication { get; set; }
        public DbSet<PostTreatment> PostTreatment { get; set; }
        public DbSet<NoteAndReportMaster> NoteAndReportMaster { get; set; }
        


        //Treatment
        public DbSet<CommentType> CommentType { get; set; }
        public DbSet<AutoText> AutoText { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }

        public DbSet<AppointmentMaster> AppointmentMaster { get; set; }
        public DbSet<AppointmentDates> AppointmentDates { get; set; }

        
        //Equipments

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<EquipmentDocuments> EquipmentDocuments { get; set; }

        //Picture
        public DbSet<Picture> Picture { get; set; }

  
        //Customer
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerRole> CustomerRole { get; set; }
        public DbSet<CustomerPassword> CustomerPassword { get; set; }

        //Security
        public DbSet<PermissionRecord> PermissionRecord { get; set; }

        //Hospitals
        public DbSet<HospitalMaster> HospitalMaster { get; set; }

        //Nurse
        public DbSet<NurseMaster> NurseMaster { get; set; }
        public DbSet<NurseDocuments> NurseDocuments { get; set; }
        
        //Prineter Setting
        public DbSet<PrinterCloudSetting> PrinterCloudSetting { get; set; }
        public DbSet<Printer> Printer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            // base.OnModelCreating(modelBuilder);
         

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            // modelBuilder.Entity<ProductWarehouseInventory>()
            //.HasOne(p => p.Product)
            // .WithMany(b => b.ProductWarehouseInventory)
            //  .OnDelete(DeleteBehavior.Cascade);
            //CompanyProfile
            modelBuilder.ApplyConfiguration(new DownloadHistoryMap());

            //Nurse
            modelBuilder.ApplyConfiguration(new NurseMasterMap());
            modelBuilder.ApplyConfiguration(new NurseDocumentsMap());

            //TreatmentRecords
            modelBuilder.ApplyConfiguration(new PatientInfoMap());
         
            modelBuilder.ApplyConfiguration(new PatientMasterMap());

            modelBuilder.ApplyConfiguration(new DoctorInfoMap());
            modelBuilder.ApplyConfiguration(new AppointmentMap());
            modelBuilder.ApplyConfiguration(new TreatmentRecordMasterMap());
            modelBuilder.ApplyConfiguration(new MachineMasterMap());
            modelBuilder.ApplyConfiguration(new PreTreatmentCheckMap());
            modelBuilder.ApplyConfiguration(new LabValuesMap());
            modelBuilder.ApplyConfiguration(new OtherLabValuesMap());
            modelBuilder.ApplyConfiguration(new SuppliesAndAccessMap());
            modelBuilder.ApplyConfiguration(new AppointmentDatesMap());

            modelBuilder.ApplyConfiguration(new PreTreatmentAssessmentMap());
            modelBuilder.ApplyConfiguration(new RunValuesMap());
            modelBuilder.ApplyConfiguration(new FinalValuesAndAccessPostAssessmentMap());
           
            modelBuilder.ApplyConfiguration(new PostTreatmentMap());
            modelBuilder.ApplyConfiguration(new MedicationMap());
            modelBuilder.ApplyConfiguration(new NoteAndReportMasterMap());



            //common
            modelBuilder.ApplyConfiguration(new StateProvinceMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new ReportSettingMap());
            modelBuilder.ApplyConfiguration(new GeneralMap());
            modelBuilder.ApplyConfiguration(new HospitalMasterMap());



            //Treatments
            modelBuilder.ApplyConfiguration(new CommentTypeMap());
            modelBuilder.ApplyConfiguration(new AutoTextMap());
            modelBuilder.ApplyConfiguration(new DiagnosisMap());
            //Euipment
            modelBuilder.ApplyConfiguration(new EquipmentMap());
            modelBuilder.ApplyConfiguration(new EquipmentDocumentsMap());

            //Customer
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerRoleMap());

            //security
            modelBuilder.ApplyConfiguration(new PermissionRecordMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
