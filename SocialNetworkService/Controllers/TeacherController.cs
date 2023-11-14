using Microsoft.AspNetCore.Mvc;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;


namespace SocialNetworkService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET api/v1/teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherResource>>> Get()
        {
            var teachers = await _teacherService.ListAllAsync();
            return Ok(teachers);
        }

        // GET api/v1/teacher/SV51
        [HttpGet("{code}")]
        public async Task<ActionResult<TeacherResource>> Get(string code)
        {
            var teacherResource = await _teacherService.FindByCodeAsync(code);
            return Ok(teacherResource);
        }

        // POST api/v1/teacher
        [HttpPost]
        public async Task<ActionResult<TeacherResponse>> Post([FromBody] SaveTeacherResource value)
        {
            var response = await _teacherService.SaveAsync(value);
            return Ok(response);
        }

        // PUT api/v1/teacher/SV51
        [HttpPut("{code}")]
        public async Task<ActionResult<TeacherResponse>> Put(string code, [FromBody] SaveTeacherResource value)
        {
            var response = await _teacherService.UpdateAsync(code, value);
            return Ok(response);
        }

        // DELETE api/teacher/SV51
        [HttpDelete("{code}")]
        public async Task<ActionResult<TeacherResource>> Delete(string code)
        {
            var response = await _teacherService.DeleteAsync(code);
            return Ok(response);
        }
    }
}