using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.DoctorVM;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public class DPatientDetailsRepository : IDPatientDetailsRepository
    {
        private readonly DB_CMSContext _dBCMSContext;
        public DPatientDetailsRepository(DB_CMSContext dBCMSContext)
        {
            _dBCMSContext = dBCMSContext;
        }

        public async Task<PatientDetailsVM> GetPatientViewAsync(int appointmentId)
        {
            using (var context = new DB_CMSContext()) // Replace YourDbContext with the actual name of your DbContext
            {
                var query = from patient in context.Patients
                            join appointment in context.Appointments on patient.PatientId equals appointment.PatientId
                            where appointment.AppointmentId == appointmentId
                            select new PatientDetailsVM
                            {
                                AppointmentId = appointment.AppointmentId,
                                PatientName = patient.PatientName,
                                Gender = patient.PatientGender,
                                BloodGroup = patient.BloodGrp,
                                PhNo = patient.PhNo,
                                CheckupStatus = appointment.CheckupStatus,
                                PatientAge = (int)Math.Floor((DateTime.Now - patient.PatientDob).TotalDays / 365)
                            };

                return await query.FirstOrDefaultAsync();
            }
        }

    }
}
