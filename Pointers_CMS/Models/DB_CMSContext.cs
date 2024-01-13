using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pointers_CMS.Models
{
    public partial class DB_CMSContext : DbContext
    {
        public DB_CMSContext()
        {
        }

        public DB_CMSContext(DbContextOptions<DB_CMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<ConsultationBill> ConsultationBill { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<LabBillGeneration> LabBillGeneration { get; set; }
        public virtual DbSet<LabPrescriptions> LabPrescriptions { get; set; }
        public virtual DbSet<LabReportGeneration> LabReportGeneration { get; set; }
        public virtual DbSet<LabTests> LabTests { get; set; }
        public virtual DbSet<LoginDetails> LoginDetails { get; set; }
        public virtual DbSet<LoginUsers> LoginUsers { get; set; }
        public virtual DbSet<MedicinePrescriptions> MedicinePrescriptions { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<PatientHistory> PatientHistory { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Qualifications> Qualifications { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Specializations> Specializations { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SJS-AARON\\SQLEXPRESS; Initial Catalog=DB_CMS; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appointm__D06765FEE812BA32");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("appointmentDate")
                    .HasColumnType("date");

                entity.Property(e => e.CheckupStatus)
                    .IsRequired()
                    .HasColumnName("checkupStatus")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('CONFIRMED')");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.TokenNo).HasColumnName("tokenNo");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DocId)
                    .HasConstraintName("FK__Appointme__docId__6B24EA82");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__patie__6C190EBB");
            });

            modelBuilder.Entity<ConsultationBill>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__Consulta__6D903F03F4789976");

                entity.Property(e => e.BillId).HasColumnName("billId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.RegistrationFee)
                    .HasColumnName("registrationFee")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalAmt)
                    .HasColumnName("totalAmt")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.ConsultationBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Consultat__appoi__6EF57B66");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__tbl_Depa__F9B8346DEC8CC715");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("departmentName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.HasIndex(e => e.AppointmentId)
                    .HasName("IX_Diagnosis")
                    .IsUnique();

                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosisId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.Diagnosis1)
                    .HasColumnName("diagnosis")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Symptoms)
                    .IsRequired()
                    .HasColumnName("symptoms")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithOne(p => p.Diagnosis)
                    .HasForeignKey<Diagnosis>(d => d.AppointmentId)
                    .HasConstraintName("FK__Diagnosis__appoi__72C60C4A");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK__tbl_Doct__0639C4229AF2A59F");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.ConsultationFee)
                    .HasColumnName("consultationFee")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SpecializationId).HasColumnName("specializationId");

                entity.Property(e => e.StaffId).HasColumnName("staffId");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__tbl_Docto__speci__44FF419A");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__tbl_Docto__staff__45F365D3");
            });

            modelBuilder.Entity<LabBillGeneration>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__tbl_Bill__6D903F03B4E49266");

                entity.Property(e => e.BillId).HasColumnName("billId");

                entity.Property(e => e.BillDate)
                    .HasColumnName("billDate")
                    .HasColumnType("date");

                entity.Property(e => e.ReportId).HasColumnName("reportId");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.LabBillGeneration)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK__tbl_BillG__repor__17F790F9");
            });

            modelBuilder.Entity<LabPrescriptions>(entity =>
            {
                entity.HasKey(e => e.LabPrescriptionId)
                    .HasName("PK__LabPresc__22C099BA6F73D046");

                entity.Property(e => e.LabPrescriptionId).HasColumnName("labPrescriptionId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.LabNote)
                    .HasColumnName("labNote")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestId).HasColumnName("labTestId");

                entity.Property(e => e.LabTestStatus)
                    .IsRequired()
                    .HasColumnName("labTestStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabPrescriptions)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabPrescr__appoi__797309D9");

                entity.HasOne(d => d.LabTest)
                    .WithMany(p => p.LabPrescriptions)
                    .HasForeignKey(d => d.LabTestId)
                    .HasConstraintName("FK__LabPrescr__labTe__7A672E12");
            });

            modelBuilder.Entity<LabReportGeneration>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__LabRepor__1C9B4E2D3A0A83EC");

                entity.Property(e => e.ReportId).HasColumnName("reportId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDate)
                    .HasColumnName("reportDate")
                    .HasColumnType("date");

                entity.Property(e => e.StaffId).HasColumnName("staffId");

                entity.Property(e => e.TestId).HasColumnName("testId");

                entity.Property(e => e.TestResult)
                    .IsRequired()
                    .HasColumnName("testResult")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabReportGeneration)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabReport__appoi__1332DBDC");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.LabReportGeneration)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__LabReport__staff__151B244E");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.LabReportGeneration)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__LabReport__testI__14270015");
            });

            modelBuilder.Entity<LabTests>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__tbl_LabT__A29BFB884B81866D");

                entity.Property(e => e.TestId).HasColumnName("testId");

                entity.Property(e => e.HighRange)
                    .IsRequired()
                    .HasColumnName("highRange")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LowRange)
                    .IsRequired()
                    .HasColumnName("lowRange")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("testName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginDetails>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginUsers>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__tbl_Logi__1F5EF4CF41271B21");

                entity.Property(e => e.LoginId).HasColumnName("loginId");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleId1).HasColumnName("role_Id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicinePrescriptions>(entity =>
            {
                entity.HasKey(e => e.MedPrescriptionId)
                    .HasName("PK__Medicine__E780C0268A165B3C");

                entity.Property(e => e.MedPrescriptionId).HasColumnName("medPrescriptionId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.Dosage)
                    .HasColumnName("dosage")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DosageDays).HasColumnName("dosageDays");

                entity.Property(e => e.MedicineQuantity).HasColumnName("medicineQuantity");

                entity.Property(e => e.PrescribedMedicineId).HasColumnName("prescribedMedicineId");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicinePrescriptions)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__MedicineP__appoi__282DF8C2");

                entity.HasOne(d => d.PrescribedMedicine)
                    .WithMany(p => p.MedicinePrescriptions)
                    .HasForeignKey(d => d.PrescribedMedicineId)
                    .HasConstraintName("FK__MedicineP__presc__29221CFB");
            });

            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__tbl_Medi__BA9E65EE511CB3B1");

                entity.Property(e => e.MedicineId).HasColumnName("medicineId");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenericName)
                    .IsRequired()
                    .HasColumnName("genericName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineCode)
                    .IsRequired()
                    .HasColumnName("medicineCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("medicineName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StockQuantity).HasColumnName("stockQuantity");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unitPrice")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<PatientHistory>(entity =>
            {
                entity.Property(e => e.PatientHistoryId).HasColumnName("patientHistoryId");

                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosisId");

                entity.Property(e => e.LabPrescriptionId).HasColumnName("labPrescriptionId");

                entity.Property(e => e.LabReportId).HasColumnName("labReportId");

                entity.Property(e => e.MedPrescriptionId).HasColumnName("medPrescriptionId");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("FK__PatientHi__diagn__30C33EC3");

                entity.HasOne(d => d.LabPrescription)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.LabPrescriptionId)
                    .HasConstraintName("FK__PatientHi__labPr__31B762FC");

                entity.HasOne(d => d.LabReport)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.LabReportId)
                    .HasConstraintName("FK__PatientHi__labRe__32AB8735");

                entity.HasOne(d => d.MedPrescription)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.MedPrescriptionId)
                    .HasConstraintName("FK__PatientHi__medPr__339FAB6E");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__Patients__A17005ECDB28B373");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.BloodGrp)
                    .IsRequired()
                    .HasColumnName("bloodGrp")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PatientAddrs)
                    .IsRequired()
                    .HasColumnName("patientAddrs")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PatientDob)
                    .HasColumnName("patientDOB")
                    .HasColumnType("date");

                entity.Property(e => e.PatientEmail)
                    .HasColumnName("patientEmail")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PatientGender)
                    .IsRequired()
                    .HasColumnName("patientGender")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasColumnName("patientName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientStatus)
                    .IsRequired()
                    .HasColumnName("patientStatus")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ACTIVE')");

                entity.Property(e => e.PhNo).HasColumnName("phNo");

                entity.Property(e => e.RegisterNo)
                    .HasColumnName("registerNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Qualifications>(entity =>
            {
                entity.HasKey(e => e.QualificationId)
                    .HasName("PK__tbl_Qual__8EA9F58368FE2B02");

                entity.Property(e => e.QualificationId).HasColumnName("qualificationId");

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasColumnName("qualification")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tbl_Role__CD98462AEAEE7C64");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specializations>(entity =>
            {
                entity.HasKey(e => e.SpecializationId)
                    .HasName("PK__tbl_Spec__7E8C9BE79BDB5EEB");

                entity.Property(e => e.SpecializationId).HasColumnName("specializationId");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.Specialization)
                    .HasColumnName("specialization")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Specializations)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__tbl_Speci__depar__46E78A0C");
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__tbl_Staf__6465E07EEC3DEB0F");

                entity.Property(e => e.StaffId).HasColumnName("staffId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .IsRequired()
                    .HasColumnName("bloodGroup")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("joiningDate")
                    .HasColumnType("date");

                entity.Property(e => e.LoginId).HasColumnName("loginId");

                entity.Property(e => e.MobileNo).HasColumnName("mobileNo");

                entity.Property(e => e.QualificationId).HasColumnName("qualificationId");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SpecializationId).HasColumnName("specializationId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__tbl_Staff__depar__47DBAE45");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.QualificationId)
                    .HasConstraintName("FK__tbl_Staff__quali__49C3F6B7");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__tbl_Staff__roleI__4AB81AF0");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__tbl_Staff__speci__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
