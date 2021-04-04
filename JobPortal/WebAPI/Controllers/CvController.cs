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

        [HttpPost("add-cv")]
        public IActionResult AddCv([FromForm] IFormFile file, [FromForm] CurriculumVitae cv)
        {
            var result = _curriculumVitaeService.Add(cv, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
