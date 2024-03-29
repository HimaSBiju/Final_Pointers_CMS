using Microsoft.AspNetCore.Mvc;
using Pointers_CMS.Models;
using Pointers_CMS.Repository.LabRepository;
using Pointers_CMS.ViewModel.LabTechnicianVM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LlabTestsController : ControllerBase
    {
        private readonly ILabTestsRepository _labTestRepository;
        private readonly ILabReportsRepository _labReportRepository;

        // constructor injection

        public LlabTestsController(ILabTestsRepository labTestRepository, ILabReportsRepository labReportRepository)
        {
            _labTestRepository = labTestRepository;
            _labReportRepository = labReportRepository;
        }

        #region View Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabTestsVM>>> LabTestsVM()
        {
            return await _labTestRepository.GetLabTestPrescriptions();
        }

        #endregion

        #region Listing
        [HttpGet]
        [Route("List")]

        public async Task<ActionResult<IEnumerable<LabReportVM>>> GetViewModelReport()
        {
            return await _labReportRepository.GetViewModelReport();
        }
    #endregion

    #region Add an report
    [HttpPost]
    public async Task<IActionResult> AddReport([FromBody] LabReportVM report)
    {
      //check the validation of code
      if (ModelState.IsValid)
      {
        try
        {
          var ReportId = await _labReportRepository.AddReport(report);
          if (ReportId > 0)
          {
            return Ok(ReportId);
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
      return BadRequest(report);
    }
    #endregion

    [HttpGet]
    [Route("Get")]

    public async Task<ActionResult<GetIDVM>> GetIDViewModel(int AppointmentId)
    {
      var idvm = await _labReportRepository.GetIDViewModel(AppointmentId);
      return Ok(idvm);
    }

    [HttpGet]
    [Route("Bill")]

    public async Task<ActionResult<LabBillVM>> GetLabBillVm(int ReportId)
    {
      var idvm = await _labReportRepository.GetBillVM(ReportId);
      return Ok(idvm);
    }

  }
}
