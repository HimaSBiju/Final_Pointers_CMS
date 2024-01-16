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
using Pointers_CMS.Repository.DPharmacistRepository;
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


            //Lab Technician 
            services.AddScoped<ILabTestsRepository, LabTestsRepository>();
            services.AddScoped<ILabReportsRepository, LabReportsRepository>();

            //Pharmacist
            services.AddScoped<IPmedicineRepository, PmedicineRepository>();
            services.AddScoped<IpharmPatientPrescriptionRepository, pharmPatientPrescriptionRepository>();

            //json resolved
            services.AddControllers().AddNewtonsoftJson(Options =>
            {
                Options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            //enable cors
            services.AddCors();

        



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            // Enable CORS
            app.UseCors(options =>
            options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



            app.UseCors(Options =>
                 Options.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 );


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                
               
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
