using Microsoft.AspNetCore.Mvc;
using Pointers_CMS.Models;
using Pointers_CMS.Repository.ReceptionistRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pointers_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpatientsController : Controller
    {



        //data field

        private readonly IPatientRepository _patientRepository;
        // constructor injection

        public RpatientsController(IPatientRepository PatientRepository)
        {
            _patientRepository = PatientRepository;
        }

        #region Listing
        [HttpGet]
        [Route("List")]   // It is used in the case of not specifying the action

        public async Task<ActionResult<IEnumerable<Patients>>> GetAllPatient()
        {
            return await _patientRepository.GetAllPatient();
        }
        #endregion


        #region Adding
        [HttpPost]
        [Route("Insert")]

        public async Task<IActionResult> AddPatient([FromBody] Patients pa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var oid = await _patientRepository.AddPatient(pa);
                    if (oid > 0)
                    {
                        return Ok(oid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Updating

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePatient([FromBody] Patients pa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientRepository.UpdatePatient(pa);
                    return Ok(pa);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region serach patient by name and phone number

        [HttpGet]
        [Route("get-by-phone-and-name")]
        public async Task<ActionResult<Patients>> GetPatientByPhoneNumberAndName(
     [FromQuery] long phoneNumber,
     [FromQuery] string name)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByPhoneNumberAndName(phoneNumber, name);

                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        #endregion

      
        #region Disable PatientRecords
[HttpPatch("{patientId}")]
public async Task<IActionResult> DisableStatus(int patientId)
        {
            try
            {
                var patient = await _patientRepository.DisableStatus(patientId);
                if (patient == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(patient);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Disable: {ex.Message}");
            }

        }
        #endregion

        #region Get All Disabled Patient Records

        [HttpGet]
        [Route("GetDisabledPatient")]
        public async Task<ActionResult<IEnumerable<Patients>>> GetDisabledPatient()
        {
            return await _patientRepository.GetAllDisabledPatients();
        }
        #endregion

        #region Enable PatientRecords
        [HttpPatch("Enable/{patientId}")]
        public async Task<IActionResult> Enable(int patientId)
        {
            try
            {
                var patient = await _patientRepository.EnableStatus(patientId);
                if (patient == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(patient);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Enable: {ex.Message}");
            }

        }
        #endregion

        #region Getpatient By id
        [HttpGet("{id}")]
        public async Task<ActionResult<Patients>> GetPatientById(int? id)
        {
            try
            {
                var med = await _patientRepository.GetPatientById(id);
                if (med == null)
                {
                    return NotFound();
                }
                return Ok(med);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
