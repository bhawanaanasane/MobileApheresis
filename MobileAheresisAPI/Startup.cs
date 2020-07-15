using System.Text;
using CRM.Core;
using CRM.Core.Domain.Security;
using CRM.Data;
using CRM.Data.Interfaces;
using CRM.Services.Appointment;
using CRM.Services.Authentication;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.CompanyProfiles;
using CRM.Services.Customers;
using CRM.Services.Equipments;
using CRM.Services.Helpers;
using CRM.Services.Hospitals;
using CRM.Services.Nurses;
using CRM.Services.Security;
using CRM.Services.Treatements;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using MobileAheresisAPI.Data;
using MobileAheresisAPI.Helpers;
using MobileAheresisAPI.Services;

namespace MobileAheresisAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<dbContextCRM>(options =>
options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(x =>
          {
              x.RequireHttpsMetadata = false;
              x.SaveToken = true;
              x.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(key),
                  ValidateIssuer = false,
                  ValidateAudience = false
              };
          });
            //Entity Framework
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyProfileService, CompanyProfileService>();
            services.AddScoped<IHospitalServices, HospitalServices>();
            services.AddScoped<INurseServices, NurseServices>();
            services.AddScoped<ITreatmentServices, TreatmentServices>();
            services.AddScoped<ITreatmentRecordServices, TreatmentRecordServices>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IEquipmentServices, EquipmentServices>();
            services.AddScoped<ICustomerRegistrationService, CustomerRegistrationService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<SecuritySettings, SecuritySettings>();
            services.AddScoped<IWorkContext, WebWorkContext>();            
            services.AddScoped<IAppointmentServices,AppointmentServices>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<CRM.Services.Authentication.IAuthenticationService, CookieAuthenticationService>();
            services.TryAddSingleton<IUserAgentHelper, UserAgentHelper>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<HttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Values}/{action=Get}/{id?}");
            });
        }
    }
}
