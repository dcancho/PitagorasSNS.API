using Microsoft.AspNetCore.Mvc;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;


namespace SocialNetworkService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService StudentService)
        {
            _studentService = StudentService;
        }

        // GET api/v1/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResource>>> Get()
        {
            var Students = await _studentService.ListAllAsync();
            return Ok(Students);
        }

        // GET api/v1/Student/SV51
        [HttpGet("{code}")]
        public async Task<ActionResult<StudentResource>> Get(string code)
        {
            var StudentResource = await _studentService.FindByStudentCodeAsync(code);
            return Ok(StudentResource);
        }

        // POST api/v1/Student
        [HttpPost]
        public async Task<ActionResult<StudentResponse>> Post([FromBody] SaveStudentResource value)
        {
            var response = await _studentService.SaveAsync(value);
            return Ok(response);
        }

        // PUT api/v1/Student/SV51
        [HttpPut("{code}")]
        public async Task<ActionResult<StudentResponse>> Put(string code, [FromBody] SaveStudentResource value)
        {
            var response = await _studentService.UpdateAsync(code, value);
            return Ok(response);
        }

        // DELETE api/Student/SV51
        [HttpDelete("{code}")]
        public async Task<ActionResult<StudentResource>> Delete(string code)
        {
            var response = await _studentService.DeleteAsync(code);
            return Ok(response);
        }
    }
}