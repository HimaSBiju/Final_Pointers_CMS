using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointers_CMS.Models;
using Pointers_CMS.Repository.A_Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class A_LabTestsController : ControllerBase
    {
        private readonly A_ILabTestRepository _labRepository;

        // construction Injection
        public A_LabTestsController(A_ILabTestRepository labRepository)
        {
            _labRepository = labRepository;
        }
        
        
        #region GEt all LabTest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabTests>>> GetEmployeeAll()
        {
            return await _labRepository.GetAllTblLabTests();
        }
        #endregion


        #region Add Labtest
        [HttpPost]
        public async Task<IActionResult> AddLab([FromBody] LabTests lab)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    var labId = await _labRepository.AddLabtest(lab);
                    if (labId > 0)
                    {
                        return Ok(labId);
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


        #region Update LabTest
        [HttpPut]
        public async Task<IActionResult> UpdateLabTest([FromBody] LabTests lab)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    await _labRepository.UpdateLabTest(lab);

                    return Ok(lab);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion


        #region GetEmployee By id
        [HttpGet("{id}")]
        public async Task<ActionResult<LabTests>> GetlabById(int? id)
        {
            try
            {
                var lab = await _labRepository.GetLabById(id);
                if (lab == null)
                {
                    return NotFound();
                }
                return Ok(lab);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


    }
}
