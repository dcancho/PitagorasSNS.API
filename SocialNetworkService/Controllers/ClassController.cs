
using Microsoft.AspNetCore.Mvc;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;
using System.Collections.Generic;

namespace SocialNetworkService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        // GET api/v1/class
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassResource>>> Get()
        {
            var classes = await _classService.ListAllAsync();
            return Ok(classes);
        }

        // GET api/v1/class/SV51
        [HttpGet("{code}")]
        public async Task<ActionResult<ClassResource>> Get(string code)
        {
            var classResource = await _classService.FindByClassCodeAsync(code);
            return Ok(classResource);
        }

        // POST api/v1/class
        [HttpPost]
        public async Task<ActionResult<ClassResponse>> Post([FromBody] SaveClassResource value)
        {
            var response = await _classService.SaveAsync(value);
            return Ok(response);
        }

        // PUT api/v1/class/SV51
        [HttpPut("{code}")]
        public async Task<ActionResult<ClassResponse>> Put(string code, [FromBody] SaveClassResource value)
        {
            var response = await _classService.UpdateAsync(code, value);
            return Ok(response);
        }

        // DELETE api/class/SV51
        [HttpDelete("{code}")]
        public async Task<ActionResult<ClassResponse>> Delete(string code)
        {
            var response = await _classService.DeleteAsync(code);
            return Ok(response);
        }
    }
}
