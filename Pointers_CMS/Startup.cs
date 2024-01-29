using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Pointers_CMS.Models;
using Pointers_CMS.Repository.DoctorRepository;
using Pointers_CMS.Repository.ReceptionistRepository;
using Pointers_CMS.Repository.A_Repository;
using Pointers_CMS.Repository.LabRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pointers_CMS
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
            
            services.AddControllers();
            // connectionstring for database, injection as dependency
            services.AddDbContext<DB_CMSContext>(db =>
            db.UseSqlServer(Configuration.GetConnectionString("DB_CMSConnection")));

            //Doctor
            services.AddScoped<IDAppointmentRepository, DAppointmentRepository>();
            services.AddScoped<IDPatientDetailsRepository, DPatientDetailsRepository>();
            services.AddScoped<IDDiagnosisRepository, DDiagnosisRepository>();
            services.AddScoped<IDPatientHistoryRepository, DPatientHistoryRepository>();
            services.AddLogging();



            //Receptionist
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IRAppointmentRepository, RAppointmentRepository>();


            //Lab Technician
            services.AddScoped<ILabTestsRepository, LabTestsRepository>();
            services.AddScoped<ILabReportsRepository, LabReportsRepository>();

            //Admin
            services.AddScoped<A_ILabTestRepository, A_LabTestRepository>();
            services.AddScoped<A_IMedicineRepository, A_MedicineRepository>();
            services.AddScoped<A_IStaffRepository, A_StaffRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();



            //Json Resolver

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            //Enable Cors
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Clinic Management System", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable Swagger UI only in the development environment
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic Management API Vi"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
