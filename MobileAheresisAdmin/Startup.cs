using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileAheresisAdmin.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CRM.Data;
using CRM.Services.Customers;
using CRM.Data.Interfaces;
using CRM.Services.Directory;
using CRM.Core;
using CRM.Services.Common;
using CRM.Services.Helpers;
using CRM.Services.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using CRM.Services.Security;
using CRM.Services.CompanyProfiles;
using MobileAheresisAdmin.Utils;
using AutoMapper;
using CRM.Core.Infrastructure;
using CRM.Services.Hospitals;
using CRM.Services.Nurses;
using MobileAheresisAdmin.Factories;
using CRM.Core.Domain.Customers;
using CRM.Core.Domain.Security;
using CRM.Services.Treatements;
using CRM.Services.TreatmentRecords;
using CRM.Services.Equipments;
using CRM.Services.Appointment;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Common.PDFServices;
using CRM.Services.Common.WordDocServices;

namespace MobileAheresisAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<dbContextCRM>(options =>
options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //Appointment
            services.AddScoped<IAppointmentServices, AppointmentServices>();
            
            //Current User
            services.AddScoped<IWorkContext, WebWorkContext>();

            //Customer Login
            services.AddScoped<ICustomerModelFactory, CustomerModelFactory>();
            services.AddScoped<CustomerSettings, CustomerSettings>();
            services.AddScoped<ICustomerRegistrationService, CustomerRegistrationService>();
            services.AddScoped<IEncryptionService, EncryptionService>();

            //DateTime Helper
            services.AddScoped<IDateTimeHelper, DateTimeHelper>();
            services.AddScoped<DateTimeSettings, DateTimeSettings>();
            //Captcha
            services.AddScoped<CaptchaSettings, CaptchaSettings>();

            //Security
            services.AddScoped<SecuritySettings, SecuritySettings>();

            //Treatment
            services.AddScoped<ITreatmentServices, TreatmentServices>();
            services.AddScoped<IExcelService, ExcelService>();
            services.AddScoped<IPDFService, PDFService>();
            services.AddScoped<PageFooter>();

            //Address
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<AddressSettings, AddressSettings>();
            services.AddScoped<IStateProvinceService, StateProvinceService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IAddressAttributeParser, AddressAttributeParser>();
            services.AddScoped<IAddressAttributeService, AddressAttributeService>();
            services.AddScoped<ITreatmentRecordServices, TreatmentRecordServices>();
            services.AddScoped<IPDFCommonSettings, PDFCommonSettings>();
            //Passwords
            services.AddScoped<ICustomerPasswordService, CustomerPasswordService>();
            //Nurse
            services.AddScoped<INurseServices, NurseServices>(); 
            //Users
            services.AddScoped<ICustomerService, CustomerService>();
            //ompany Profile
            services.AddScoped<ICompanyProfileService, CompanyProfileService>();
            //Hospitals
            services.AddScoped<IHospitalServices, HospitalServices>();
            //Entity Framework
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            //Authentications
            services.AddScoped<IAuthenticationService, CookieAuthenticationService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Reports permissions
            services.AddScoped<IPermissionService, PermissionService>();
            services.TryAddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IUserAgentHelper, UserAgentHelper>();
            services.AddScoped<IEquipmentServices, EquipmentServices>();

         //Stored Procedure
            services.AddScoped<IReportService, ReportService>();
            //Word Document
            services.AddScoped<IWordDocCommonSetting, WordDocCommonSetting>();
            services.AddScoped<IWordDocService, WordDocService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = MobileApheresisCookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = MobileApheresisCookieAuthenticationDefaults.ExternalAuthenticationScheme;
            });

            //add main cookie authentication
            authenticationBuilder.AddCookie(MobileApheresisCookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = MobileApheresisCookieAuthenticationDefaults.CookiePrefix + MobileApheresisCookieAuthenticationDefaults.AuthenticationScheme;
                options.Cookie.HttpOnly = true;
                options.LoginPath = MobileApheresisCookieAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = MobileApheresisCookieAuthenticationDefaults.AccessDeniedPath;
            });

            services.AddMvc();
            AddAutoMapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
          //app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }


        protected virtual void AddAutoMapper(IServiceCollection services)
        {
            //create and sort instances of mapper configurations

            //create AutoMapper configuration
            var mappingProfile = new AdminMapperConfiguration();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(mappingProfile);
            });

            //register AutoMapper
            services.AddAutoMapper();

            //register
            AutoMapperConfiguration.Init(config);
        }
    }
}
