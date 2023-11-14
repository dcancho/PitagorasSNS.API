
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PitagorasSNS.API.SocialNetworkService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET api/v1/course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResource>>> Get()
        {
            var courses = await _courseService.ListAllAsync();
            return Ok(courses);
        }

        // GET api/v1/course/1
        [HttpGet("{code}")]
        public async Task<ActionResult<CourseResource>> Get(string code)
        {
            var courseResource = await _courseService.FindByCourseCodeAsync(code);
            return Ok(courseResource);
        }

        // POST api/v1/course
        [HttpPost]
        public async Task<ActionResult<CourseResponse>> Post([FromBody] SaveCourseResource value)
        {
            var response = await _courseService.SaveAsync(value);
            return Ok(response);
        }

        // PUT api/v1/course/1
        [HttpPut("{code}")]
        public async Task<ActionResult<CourseResponse>> Put(string code, [FromBody] SaveCourseResource value)
        {
            var response = await _courseService.UpdateAsync(code, value);
            return Ok(response);
        }

        // DELETE api/v1/course/1
        [HttpDelete("{code}")]
        public async Task<ActionResult<CourseResponse>> Delete(string code)
        {
            var response = await _courseService.DeleteAsync(code);
            return Ok(response);
        }
    }
}
