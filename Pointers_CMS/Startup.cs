using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pointers_CMS.Models;
using Pointers_CMS.Repository.ReceptionistRepository;
using Pointers_CMS.Repository.A_Repository;
using Pointers_CMS.Repository.LabRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // connectionstring for database, inject as dependency
            services.AddDbContext<DB_CMSContext>(db =>
            db.UseSqlServer(Configuration.GetConnectionString("DB_CMSConnection")));




            //Receptionist
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IRAppointmentRepository, RAppointmentRepository>();


            //Lab Technician
            services.AddScoped<ILabTestsRepository, ILabTestsRepository>();
            services.AddScoped<ILabReportsRepository, ILabReportsRepository>();

            //Admin
            services.AddScoped<A_ILabTestRepository, A_LabTestRepository>();
            services.AddScoped<A_IMedicineRepository, A_MedicineRepository>();
            services.AddScoped<A_IStaffRepository, A_StaffRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
