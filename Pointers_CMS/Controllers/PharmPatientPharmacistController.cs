using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointers_CMS.ViewModel.PharPatientPrescriptionViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Pointers_CMS.Repository.DPharmacistRepository;

namespace Pointers_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmPatientPharmacistController : ControllerBase
    {
        private readonly IpharmPatientPrescriptionRepository _patientPrescriptionRepository;

        // Construction Injection
        public PharmPatientPharmacistController(IpharmPatientPrescriptionRepository patientPrescriptionRepository)
        {
            _patientPrescriptionRepository = patientPrescriptionRepository;
        }

        #region Get all Patient Prescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharmacistViewModel>>> GetAllPatientPrescriptions()
        {
            try
            {
                var patientPrescriptions = await _patientPrescriptionRepository.GetAllPatientPrescriptions();
                if (patientPrescriptions == null || patientPrescriptions.Count == 0)
                {
                    return NotFound("No Patient Prescriptions found");
                }
                return Ok(patientPrescriptions);
            }
            catch (Exception)
            {
                return BadRequest("Error while fetching Patient Prescriptions");
            }
        }
        #endregion

        #region Search Patient Prescriptions by PatientId
        [HttpGet("search/{id}")]
        public async Task<ActionResult<IEnumerable<PharmacistViewModel>>> SearchPatientPrescriptionsByPatientId([FromQuery] int? patientId)
        {
            try
            {
                var patientPrescriptions = await _patientPrescriptionRepository.SearchPatientPrescriptionsByPatientId(patientId);
                if (patientPrescriptions == null || patientPrescriptions.Count == 0)
                {
                    return NotFound($"No Patient Prescriptions found for PatientId '{patientId}'");
                }
                return Ok(patientPrescriptions);
            }
            catch (Exception)
            {
                return BadRequest("Error while searching Patient Prescriptions");
            }
        }
        #endregion
    }
}
