using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.AdminVM;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Numerics;
using System;

namespace Pointers_CMS.Repository.A_Repository
{
    public class A_StaffRepository:A_IStaffRepository
    {
        private readonly DB_CMSContext _Context;

        public A_StaffRepository(DB_CMSContext context)
        {
            _Context = context;
        }


        public async Task<List<A_StaffVM>> GetStaffDetails()
        {
            if (_Context != null)
            {
                var staffDetails = await (from staff in _Context.Staffs
                                          join department in _Context.Departments on staff.DepartmentId equals department.DepartmentId into deptGroup
                                          from dept in deptGroup.DefaultIfEmpty()
                                          join specialization in _Context.Specializations on dept.DepartmentId equals specialization.DepartmentId into specGroup
                                          from spec in specGroup.DefaultIfEmpty()
                                          join qualification in _Context.Qualifications on staff.QualificationId equals qualification.QualificationId into qualGroup
                                          from qual in qualGroup.DefaultIfEmpty()
                                          join role in _Context.Roles on staff.RoleId equals role.RoleId into roleGroup
                                          from role in roleGroup.DefaultIfEmpty()
                                          join doctor in _Context.Doctors on staff.StaffId equals doctor.StaffId into doctorGroup
                                          from doctor in doctorGroup.DefaultIfEmpty()
                                          join login in _Context.LoginUsers on staff.LoginId equals login.LoginId into loginGroup
                                          from login in loginGroup.DefaultIfEmpty()

                                          select new A_StaffVM
                                          {
                                              StaffId = staff.StaffId,
                                              FullName = staff.FullName,
                                              Dob = staff.Dob,
                                              Gender = staff.Gender,
                                              Address = staff.Address,
                                              BloodGroup = staff.BloodGroup,
                                              JoiningDate = staff.JoiningDate,
                                              Salary = staff.Salary,
                                              MobileNo = staff.MobileNo,
                                              DepartmentName = dept != null ? dept.DepartmentName : null,
                                              Qualification = qual != null ? qual.Qualification : null,
                                              Specialization = spec != null ? spec.Specialization : null,
                                              RoleName = role != null ? role.RoleName : null,
                                              ConsultationFee = doctor != null ? doctor.ConsultationFee : (decimal?)null,
                                              UserName = login.UserName,
                                              Password = login.Password,
                                              SpecializationId = spec != null ? spec.SpecializationId : (int?)null,
                                              RoleId = role != null ? role.RoleId : (int?)null,
                                              LoginId = login.LoginId,
                                              DepartmentId = dept != null ? dept.DepartmentId : (int?)null,
                                              QualificationId = (int)(qual != null ? qual.QualificationId : (int?)null)
                                          }).ToListAsync();

                return staffDetails;
            }

            // If _Context is null, return an empty list or handle it according to your requirements.
            return null;
        }






        public async Task<A_StaffVM> GetStaffDetailsById(int? staffId)
        {
            if (_Context != null)
            {
                var staffDetails = await (from staff in _Context.Staffs
                                          where staff.StaffId == staffId
                                          join department in _Context.Departments on staff.DepartmentId equals department.DepartmentId into deptGroup
                                          from dept in deptGroup.DefaultIfEmpty()
                                          join specialization in _Context.Specializations on dept.DepartmentId equals specialization.DepartmentId into specGroup
                                          from spec in specGroup.DefaultIfEmpty()
                                          join qualification in _Context.Qualifications on staff.QualificationId equals qualification.QualificationId into qualGroup
                                          from qual in qualGroup.DefaultIfEmpty()
                                          join role in _Context.Roles on staff.RoleId equals role.RoleId into roleGroup
                                          from role in roleGroup.DefaultIfEmpty()
                                          join doctor in _Context.Doctors on staff.StaffId equals doctor.StaffId into doctorGroup
                                          from doctor in doctorGroup.DefaultIfEmpty()
                                          join login in _Context.LoginUsers on staff.LoginId equals login.LoginId into loginGroup
                                          from login in loginGroup.DefaultIfEmpty()
                                          select new A_StaffVM
                                          {
                                              StaffId = staff.StaffId,
                                              FullName = staff.FullName,
                                              Dob = staff.Dob,
                                              Gender = staff.Gender,
                                              Address = staff.Address,
                                              BloodGroup = staff.BloodGroup,
                                              JoiningDate = staff.JoiningDate,
                                              Salary = staff.Salary,
                                              MobileNo = staff.MobileNo,
                                              DepartmentName = dept != null ? dept.DepartmentName : null,
                                              Qualification = qual != null ? qual.Qualification : null,
                                              Specialization = spec != null ? spec.Specialization : null,
                                              RoleName = role != null ? role.RoleName : null,
                                              ConsultationFee = doctor != null ? doctor.ConsultationFee : (decimal?)null,
                                              UserName = login.UserName,
                                              Password = login.Password
                                          }).FirstOrDefaultAsync();

                return staffDetails;
            }

            // If _Context is null, return null or handle it according to your requirements.
            return null;
        }





        #region Add Staff


        //--------------------------Adding the Staff-------------------------------

        public async Task<Departments> GetDepartmentId(int departmentId)
        {
            if (_Context != null)
            {

                return await _Context.Departments
                    .Where(q => q.DepartmentId == departmentId)
                    .FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<Specializations>> GetSpecializationsForDepartmentAsync(int departmentId)
        {
            if (_Context != null)
            {
                return await _Context.Specializations
                    .Where(s => s.DepartmentId == departmentId)
                    .ToListAsync();
            }

            return null;
        }



        public async Task UpdateID(int staffId, int specializationId, int departmentId)
        {
            if (_Context != null)
            {
                var staff = await _Context.Staffs.FindAsync(staffId);

                if (staff != null)
                {
                    // Update the properties
                    staff.SpecializationId = specializationId;
                    staff.DepartmentId = departmentId;

                    // Mark the entity as modified
                    _Context.Entry(staff).State = EntityState.Modified;

                    // Save changes
                    await _Context.SaveChangesAsync();
                }
            }
        }






        public async Task<int> AddStaffWithRelatedData(A_StaffVM staffDetails)
        {
            using var transaction = await _Context.Database.BeginTransactionAsync();




            try
            {
                var nelogin = new LoginUsers
                {
                    UserName = staffDetails.UserName,
                    Password = staffDetails.Password,
                    RoleId = staffDetails.RoleId
                };
                _Context.LoginUsers.Add(nelogin);
                await _Context.SaveChangesAsync();
                // Add staff to the staff table
                var newStaff = new Staffs
                {
                    FullName = staffDetails.FullName,
                    Dob = staffDetails.Dob,
                    Gender = staffDetails.Gender,
                    Address = staffDetails.Address,
                    BloodGroup = staffDetails.BloodGroup,
                    JoiningDate = staffDetails.JoiningDate,
                    Salary = staffDetails.Salary,
                    MobileNo = staffDetails.MobileNo,
                    Email = staffDetails.Email,
                    RoleId = staffDetails.RoleId,
                    SpecializationId = staffDetails.SpecializationId,
                    DepartmentId = staffDetails.DepartmentId,
                    QualificationId = staffDetails.QualificationId,
                    LoginId = nelogin.LoginId


                };


                // Add staff to the staff table
                _Context.Staffs.Add(newStaff);
                await _Context.SaveChangesAsync();

                // Retrieve the automatically generated StaffId
                int newStaffId = newStaff.StaffId;




                if (staffDetails.RoleId == 2) // Assuming RoleId 3 corresponds to the doctor role
                {
                    // Retrieve DepartmentId for the given DepartmentName

                    // Add to TblDoctors for doctor role
                    var doctor = new Doctors
                    {
                        StaffId = newStaffId,
                        ConsultationFee = staffDetails.ConsultationFee,
                        SpecializationId = staffDetails.SpecializationId
                    };

                    _Context.Doctors.Add(doctor);
                    await _Context.SaveChangesAsync();
                }






                await transaction.CommitAsync();

                // Return the ID of the newly added staff
                return newStaffId;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log the exception or handle it as needed
                throw;
            }



        }

        #endregion



        #region Update Staff
        public async Task UpdateStaff(Staffs staff)
        {
            if (_Context != null)
            {
                _Context.Entry(staff).State = EntityState.Modified;
                _Context.Staffs.Update(staff);
                await _Context.SaveChangesAsync();
            }
        }
        #endregion


    }
}
