using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private ICurriculumVitaeService _curriculumVitaeService;

        public CvController(ICurriculumVitaeService curriculumVitaeService)
        {
            _curriculumVitaeService = curriculumVitaeService;
        }

        [HttpPost("add")]
        public IActionResult AddCv([FromForm] IFormFile file, [FromForm] CurriculumVitae cv)
        {
            var result = _curriculumVitaeService.Add(cv, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpPost("add-async")]
        public async Task<IActionResult> AddAsyncCv([FromForm] IFormFile file, [FromForm] CurriculumVitae cv)
        {
            var result = await _curriculumVitaeService.AddAsync(cv, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CurriculumVitae cv, [FromForm] IFormFile file)
        {
            var result = _curriculumVitaeService.Update(cv, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update-async")]
        public async Task<IActionResult> UpdateAsync([FromForm] CurriculumVitae cv, [FromForm] IFormFile file)
        {
            var result = await _curriculumVitaeService.UpdateAsync(cv, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete-soft")]
        public IActionResult SoftDelete(CurriculumVitae cv)
        {
            var result = _curriculumVitaeService.DeleteSoft(cv);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete-hard")]
        public IActionResult HardDelete(CurriculumVitae cv)
        {
            var result = _curriculumVitaeService.DeleteHard(cv);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete-hard-async")]
        public async Task<IActionResult> HardDeleteAsync(CurriculumVitae cv)
        {
            var result = await _curriculumVitaeService.DeleteHardAsync(cv);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
