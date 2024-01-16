using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Pointers_CMS.ViewModel.AdminVM;
using Pointers_CMS.Repository.A_Repository;
using Pointers_CMS.Models;

namespace Pointers_CMS.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class A_StaffController : ControllerBase
    {
        private readonly A_IStaffRepository _staffRepository;

        // construction Injection
        public A_StaffController(A_IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;

        }




        #region Get ViewModel Employees
        [HttpGet]
        [Route("ViewModelGetStaff")]
        public async Task<ActionResult<IEnumerable<A_StaffVM>>> GetStaffs()
        {
            return await _staffRepository.GetStaffDetails();
        }

        #endregion





        #region GetStaff By id
        [HttpGet("{staffId}")]
        public async Task<ActionResult<A_StaffVM>> GetStaffDetailsById(int? staffId)
        {
            try
            {
                var staffDetails = await _staffRepository.GetStaffDetailsById(staffId);

                if (staffDetails == null)
                {
                    return NotFound(); // Staff not found, return 404 Not Found
                }

                return Ok(staffDetails); // Return staff details with 200 OK
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // Consider returning a more specific status code or message
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        #endregion



        #region Add Medicine
        [HttpPost]

        public async Task<IActionResult> AddStaffWithRelatedData([FromBody] A_StaffVM staffDetails)
        {
            try
            {
                var StaffId = await _staffRepository.AddStaffWithRelatedData(staffDetails);

                return Ok(StaffId);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal Server Error");
            }



        }
        #endregion



        #region Update Staff
        [HttpPut]
        public async Task<IActionResult> UpdateStaff([FromBody] Staffs staff)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    await _staffRepository.UpdateStaff(staff);

                    return Ok(staff);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

    }
}
