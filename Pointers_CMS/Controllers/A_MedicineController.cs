using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Pointers_CMS.Repository;
using Pointers_CMS.Models;

namespace Pointers_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class A_MedicineController : ControllerBase
    {
        private readonly A_IMedicineRepository _medicineRepository;

        // construction Injection
        public A_MedicineController(A_IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        #region GEt all Medicine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicines>>> GetMedicineAll()
        {
            return await _medicineRepository.GetAllTblMedicines();
        }
        #endregion


        #region Add Medicine
        [HttpPost]
        public async Task<IActionResult> AddMedicine([FromBody] Medicines medicine)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    var medId = await _medicineRepository.AddMedicine(medicine);
                    if (medId > 0)
                    {
                        return Ok(medId);
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



        #region Update Medicine
        public async Task<IActionResult> UpdateEmployee([FromBody] Medicines med)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    await _medicineRepository.UpdateMedicine(med);

                    return Ok(med);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion


        #region GetMedicine By id
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicines>> GetMedicineById(int? id)
        {
            try
            {
                var med = await _medicineRepository.GetMedicineById(id);
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
