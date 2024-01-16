using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pointers_CMS.Repository.DoctorRepository;
using Pointers_CMS.ViewModel.DoctorVM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDAppointmentRepository _appointmentRepository;
        public readonly IDPatientDetailsRepository _patientDetailsRepository;
        public readonly IDDiagnosisRepository _dDiagnosisRepository;
        public readonly IDPatientHistoryRepository _patientHistoryRepository;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDAppointmentRepository appointmentRepository, IDPatientDetailsRepository patientDetailsRepository, IDDiagnosisRepository dDiagnosisRepository, IDPatientHistoryRepository patientHistoryRepository, ILogger<DoctorController> logger)
        {
            _appointmentRepository = appointmentRepository;
            _patientDetailsRepository = patientDetailsRepository;
            _dDiagnosisRepository = dDiagnosisRepository;
            _patientHistoryRepository = patientHistoryRepository;
            _logger = logger;
        }

        [HttpGet("GetAppointmentView")]
        public async Task<ActionResult<IEnumerable<AppointmentsVM>>> GetAppointmentView(int docId)
        {
            var appointments = await _appointmentRepository.GetAppointmentViewAsync(docId);

            if (appointments == null || appointments.Count == 0)
            {
                return NotFound(); 
            }

            return Ok(appointments);
        }

        [HttpGet("GetPatientView")]
        public async Task<ActionResult<DPatientDetailsRepository>> GetPatientView(int appointmentId)
        {
            var patientDetails = await _patientDetailsRepository.GetPatientViewAsync(appointmentId);

            if (patientDetails == null)
            {
                return NotFound(); // Or return an appropriate status code
            }

            return Ok(patientDetails);
        }

        #region Add Diagnosis
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> AddDiagnosis([FromBody] DiagnosisVM diagnosis)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var diagId = await _dDiagnosisRepository.FillDiagForm(diagnosis);
                    if (diagId > 0)
                    {
                        return Ok(diagId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex.StackTrace);
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientHistory(int patientId)
        {
            try
            {
                var patientHistory = await _patientHistoryRepository.GetPatientHistoryAsync(patientId);

                if (patientHistory == null || patientHistory.Count == 0)
                {
                    return NotFound($"No history found for patient with ID {patientId}");
                }

                return Ok(patientHistory);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
