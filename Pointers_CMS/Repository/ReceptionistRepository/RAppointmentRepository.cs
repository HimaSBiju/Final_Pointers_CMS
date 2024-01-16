using Microsoft.Extensions.Logging;
using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.ReceptionistVM;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using static Pointers_CMS.Repository.ReceptionistRepository.RAppointmentRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Pointers_CMS.Repository.ReceptionistRepository
{
    public class RAppointmentRepository : IRAppointmentRepository
    {
  
            private readonly DB_CMSContext _dbContext;


            public RAppointmentRepository(DB_CMSContext dbContext)
            {
                _dbContext = dbContext;
            }
        #region get all departments

        //Get all Departments

        public async Task<List<Departments>> GetAllDepartment()
        {
            if (_dbContext != null)
            {
                return await _dbContext.Departments.ToListAsync();
            }
            return null;
        }
        #endregion


        #region Get all Specialization By Department Id
        public async Task<List<Specializations>> GetAllSpecializationByDepartmentId(int? departmentId)
        {
            if (_dbContext != null)
            {
                return await _dbContext.Specializations.Where(s => s.DepartmentId == departmentId).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Get Doctor by Specializaton Id
        public async Task<List<DoctorViewModel>> GetAllDoctorBySpecializationId(int? specializationId)
        {
            if (_dbContext != null)
            {
                var doctors = await _dbContext.Doctors
            .Where(d => d.SpecializationId == specializationId)
            .Include(d => d.Staff)
            .Include(d => d.Staff.Specialization)
            .Select(d => new DoctorViewModel
            {
                DoctorId = d.DocId,
                ConsultationFee = d.ConsultationFee,
                StaffId = d.StaffId,
                SpecializationId = d.SpecializationId,
                QualificationId = d.Staff.QualificationId,
                LoginId = d.Staff.LoginId,
                FullName = d.Staff.FullName,
                Dob = d.Staff.Dob,
                Gender = d.Staff.Gender,

                Bloodgroup = d.Staff.BloodGroup,
                JoiningDate = d.Staff.JoiningDate,
                Salary = d.Staff.Salary,
                MobileNo = d.Staff.MobileNo,
                DepartmentId = d.Staff.DepartmentId,
                Email = d.Staff.Email,
                RoleId = d.Staff.RoleId
            })
            .ToListAsync();

                return doctors;

            }
            return null;
        }
        #endregion

        #region Book Appointment and Bill Genereation
        public async Task<AppointmentViewModel> BookAppointment(AppointmentViewModel viewModel, bool isNewPatient)
        {
            var existingAppointment = await _dbContext.Appointments.Where(a => a.PatientId == viewModel.PatientId
            && a.DocId == viewModel.DocId && a.AppointmentDate == viewModel.AppointmentDate).FirstOrDefaultAsync();
            if (existingAppointment != null)
            {
                throw new InvalidOperationException("Appointment already exists for the same doctor and same date");
            }
            if (_dbContext != null)
            {
                var lastTokenNumber = await _dbContext.Appointments.Where(a => a.DocId == viewModel.DocId && a.AppointmentDate == viewModel.AppointmentDate).OrderByDescending(a => a.TokenNo).Select(a => a.TokenNo).FirstOrDefaultAsync();

                int newTokenNumber;
                if (lastTokenNumber > -1 && lastTokenNumber < 100)
                {
                    newTokenNumber = lastTokenNumber + 1;
                }
                else
                {
                    throw new InvalidOperationException("No more token is available for today");
                }
                viewModel.TokenNo = newTokenNumber;
                var newAppointment = new Appointments()
                {
                    TokenNo = viewModel.TokenNo,
                    PatientId = viewModel.PatientId,
                    AppointmentDate = viewModel.AppointmentDate,
                    DocId = viewModel.DocId,

                };
                _dbContext.Appointments.Add(newAppointment);
                await _dbContext.SaveChangesAsync();

                viewModel.AppointmentId = newAppointment.AppointmentId;
                viewModel.CheckUpStatus = viewModel.CheckUpStatus;
                decimal registerFee;
                if (isNewPatient)
                {
                    registerFee = viewModel.RegisterFees ?? 150;

                }
                else
                {
                    registerFee = viewModel.RegisterFees ?? 0;
                }

                decimal consultFees = viewModel.ConsultationFee ?? _dbContext.Doctors.Where(d => d.DocId == viewModel.DocId).Select(d => (decimal?)d.ConsultationFee).FirstOrDefault() ?? 0;
                decimal totalAmount = registerFee + consultFees + (0.18m * registerFee) + (0.18m * consultFees);

                viewModel.RegisterFees = registerFee;
                viewModel.ConsultationFee = (int?)consultFees;
                viewModel.TotalAmount = totalAmount;
                var newConsultBill = new ConsultationBill()
                {
                    AppointmentId = viewModel.AppointmentId,
                    RegistrationFee = registerFee,
                    TotalAmt = totalAmount
                };


                _dbContext.ConsultationBill.Add(newConsultBill);
                await _dbContext.SaveChangesAsync();
                viewModel.BillId = newConsultBill.BillId;
                return viewModel;
            }
            return null;
        }
        #endregion

        #region Display Bill Details
        public async Task<BillViewModel> BillDetails(int? billId)
        {
            if (_dbContext == null)
                return null;

            var bill = await _dbContext.ConsultationBill.FindAsync(billId);
            if (bill == null)
                return null;

            var appointment = await GetAppointmentDetails(bill.AppointmentId);



            if (appointment == null)
                return null;

            var patient = await GetPatientDetails(appointment.PatientId);
            var doctor = await GetDoctorDetails(appointment.DocId);
            if (doctor == null)
                return null;

            var specialization = await GetSpecializationDetails(doctor.SpecializationId);
            var department = await GetDepartmentDetails(specialization.DepartmentId);
            var staff = await GetStaffDetails(doctor.StaffId);

            if (staff == null || specialization == null || department == null)
                return null;

            return CreateBillViewModel(patient, doctor, staff, specialization, department, appointment, bill);
        }

        private async Task<Appointments> GetAppointmentDetails(int? appointmentId)
        {
            return await _dbContext.Appointments.FindAsync(appointmentId);
        }

        private async Task<Patients> GetPatientDetails(int? patientId)
        {
            return await _dbContext.Patients.FindAsync(patientId);
        }

        private async Task<Doctors> GetDoctorDetails(int? doctorId)
        {
            return await _dbContext.Doctors.FindAsync(doctorId);
        }

        private async Task<Specializations> GetSpecializationDetails(int? specializationId)
        {
            return await _dbContext.Specializations.FindAsync(specializationId);
        }

        private async Task<Departments> GetDepartmentDetails(int? departmentId)
        {
            return await _dbContext.Departments.FindAsync(departmentId);
        }

        private async Task<Staffs> GetStaffDetails(int? staffId)
        {
            return await _dbContext.Staffs.FindAsync(staffId);
        }

        private BillViewModel CreateBillViewModel(Patients patient, Doctors doctor, Staffs staff, Specializations specialization, Departments department, Appointments appointment, ConsultationBill bill)
        {
            return new BillViewModel()
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                RegisterNo = patient.RegisterNo,
                DocId = doctor.DocId,
                StaffId = staff.StaffId,
                FullName = staff.FullName,
                RegistrationFee = bill.RegistrationFee,
                ConsultationFee = doctor.ConsultationFee,
                SpecializationId = specialization.SpecializationId,
                TotalAmt = bill.TotalAmt,
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                AppointmentId = appointment.AppointmentId,
                TokenNo = appointment.TokenNo,
                AppointmentDate = appointment.AppointmentDate,
                CheckupStatus = appointment.CheckupStatus,
                BillId = bill.BillId,
            };
        }

        #endregion

        #region Get All Appointments with BillViewModel
        public async Task<List<BillViewModel>> GetAllAppointmentsWithBillViewModel()
        {
            if (_dbContext != null)
            {
                var appointments = await _dbContext.Appointments
             .Include(a => a.Patient)
             .Include(a => a.Doc).ThenInclude
             (d => d.Staff).Include(a => a.Doc).ThenInclude(d => d.Specialization).ThenInclude(s => s.Department).Where(a => a.CheckupStatus == "CONFIRMED")
             .ToListAsync();
                // Enable logging to console
                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                        .AddConsole();
                });

                /* _dbContext.Database.SetCommandTimeout(180);
                 _dbContext.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());*/

                // Your actual query to retrieve Staff with Department
                var staffWithDepartment = await _dbContext.Staffs
                    .Include(s => s.Department)
                    .FirstOrDefaultAsync(s => s.DepartmentId == s.Department.DepartmentId);

                //// Disable logging after the query (optional)
                /* _dbContext.Database.SetCommandTimeout(30); // Set the timeout to its original value
                 _dbContext.GetService<ILoggerFactory>().Dispose();*/

                var appointmentsWithViewModel = new List<BillViewModel>();

                foreach (var appointment in appointments)
                {
                    // Find the ConsultBill for the current appointment
                    var consultBill = await _dbContext.ConsultationBill
                        .FirstOrDefaultAsync(b => b.AppointmentId == appointment.AppointmentId);

                    // Transform Appointment entity and ConsultBill to BillViewModel
                    var appointmentWithViewModel = new BillViewModel
                    {
                        AppointmentId = appointment.AppointmentId,
                        TokenNo = appointment.TokenNo,
                        AppointmentDate = appointment.AppointmentDate,
                        PatientId = appointment.PatientId,
                        DocId = appointment.DocId,
                        CheckupStatus = appointment.CheckupStatus,
                        BillId = consultBill.BillId,
                        RegistrationFee = consultBill?.RegistrationFee,
                        TotalAmt = consultBill.TotalAmt,
                        ConsultationFee = appointment.Doc?.ConsultationFee,
                        StaffId = appointment.Doc?.StaffId,
                        SpecializationId = appointment.Doc?.SpecializationId,
                        DepartmentId = (int)(appointment.Doc?.Specialization?.DepartmentId),
                        DepartmentName = appointment.Doc?.Specialization?.Department?.DepartmentName,
                        FullName = appointment.Doc?.Staff?.FullName,
                        RegisterNo = appointment.Patient?.RegisterNo,
                        PatientName = appointment.Patient?.PatientName
                    };

                    appointmentsWithViewModel.Add(appointmentWithViewModel);
                }


                return appointmentsWithViewModel;
            }
            return null;
        }
        #endregion

        #region Get the appointment details by Appointment Id
        public async Task<BillViewModel> GetAppointmentDetailsById(int? appointmentId)
        {
            if (_dbContext != null)
            {
                var appointments = await _dbContext.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Doc).ThenInclude
                    (d => d.Staff).Include(a => a.Doc).ThenInclude(d => d.Specialization).ThenInclude(s => s.Department).Where(a => a.CheckupStatus == "CONFIRMED").FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);

                var ConsultBill = await _dbContext.ConsultationBill.FirstOrDefaultAsync(b => b.AppointmentId == appointmentId);
                var billViewModel = new BillViewModel
                {
                    AppointmentId = appointments.AppointmentId,
                    TokenNo = appointments.TokenNo,
                    AppointmentDate = appointments.AppointmentDate,
                    PatientId = appointments.PatientId,
                    DocId = appointments.DocId,
                    CheckupStatus = appointments.CheckupStatus,
                    BillId = ConsultBill.BillId,
                    RegistrationFee = ConsultBill?.RegistrationFee,
                    TotalAmt = ConsultBill.TotalAmt,
                    ConsultationFee = appointments.Doc?.ConsultationFee,
                    StaffId = appointments.Doc?.StaffId,
                    SpecializationId = appointments.Doc?.SpecializationId,
                    DepartmentId = (int)(appointments.Doc?.Specialization?.DepartmentId),
                    DepartmentName = appointments.Doc?.Specialization?.Department?.DepartmentName,
                    FullName = appointments.Doc?.Staff?.FullName,
                    RegisterNo = appointments.Patient?.RegisterNo,
                    PatientName = appointments.Patient?.PatientName
                };
                return billViewModel;
            }
            return null;
        }
        #endregion

        #region Cancel Appointment
        public async Task<Appointments> CancelAppointment(int? appointmentId)
        {
            if (_dbContext != null)
            {
                var appointment = await _dbContext.Appointments.FindAsync(appointmentId);
                if (appointment != null)
                {
                    appointment.CheckupStatus = "CANCELLED";
                    await _dbContext.SaveChangesAsync();

                }
                return appointment;
            }
            return null;
        }
        #endregion
    }
}
