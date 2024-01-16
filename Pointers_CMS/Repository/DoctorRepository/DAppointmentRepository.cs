using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.DoctorVM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public class DAppointmentRepository : IDAppointmentRepository
    {
        private readonly DB_CMSContext _dbCMSContext;
        public DAppointmentRepository(DB_CMSContext dbCMSContext)
        {
            _dbCMSContext = dbCMSContext;
        }

        #region GetPatientAppointments

        public async Task<List<AppointmentsVM>> GetAppointmentViewAsync(int docId)
        {
            var todayDate = DateTime.Now.Date;

            var query = from patient in _dbCMSContext.Patients
                        join appointment in _dbCMSContext.Appointments on patient.PatientId equals appointment.PatientId
                        where appointment.DocId == docId && appointment.AppointmentDate.Date == todayDate
                        select new AppointmentsVM
                        {
                            AppointmentDate = appointment.AppointmentDate,
                            TokenNo = appointment.TokenNo,
                            PatientName = patient.PatientName,
                            PatientGender = patient.PatientGender,
                            PatientAge = (int)Math.Floor((todayDate - patient.PatientDob).TotalDays / 365),
                            CheckupStatus = appointment.CheckupStatus,
                            AppointmentId = appointment.AppointmentId
                        };

            return await query.ToListAsync();
            
        }

        #endregion

    }
}
