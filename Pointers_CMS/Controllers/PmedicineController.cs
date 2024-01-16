using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointers_CMS.Models;
using Pointers_CMS.Repository.DPharmacistRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pointers_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PmedicineController : ControllerBase
    {
        private readonly IPmedicineRepository _medicineRepository;

        // construction Injection
        public PmedicineController(IPmedicineRepository employeeRepository)
        {
            _medicineRepository = employeeRepository;
        }
        #region GEt all Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicines>>> GetAllMedicine()
        {
            return await _medicineRepository.GetAllMedicine();
        }
        #endregion

        #region GetDetails By id
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicines>> GetDetailsById(long? id)
        {
            try
            {
                var med = await _medicineRepository.GetDetailsById(id);
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

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Medicines>>> SearchMedicineByName([FromQuery] string name)
        {
            try
            {
                var medicines = await _medicineRepository.SearchMedicineByName(name);
                return Ok(medicines);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
