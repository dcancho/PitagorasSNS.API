using Microsoft.AspNetCore.Mvc;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScoresRecordController : ControllerBase
    {
        private readonly IScoresRecordService _scoresRecordService;

        public ScoresRecordController(IScoresRecordService scoresRecordService)
        {
            _scoresRecordService = scoresRecordService;
        }
        
        // GET api/v1/scoresrecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoresRecordResource>>> Get()
        {
            var scoresRecords = await _scoresRecordService.ListAllAsync();
            return Ok(scoresRecords);
        }

        // GET api/v1/scoresrecord/SV51?studentCode=U20201F479
        [HttpGet("{classCode}")]
        public async Task<ActionResult<ScoresRecordResource>> Get(string classCode, [FromQuery] string studentCode)
        {
            var scoresRecordResource = await _scoresRecordService.FindByStudentCodeAndCourseCodeAsync(studentCode, classCode);
            return Ok(scoresRecordResource);
        }

        // POST api/v1/scoresrecord
        [HttpPost]
        public async Task<ActionResult<ScoresRecordResponse>> Post([FromBody] SaveScoresRecordResource value)
        {
            var response = await _scoresRecordService.SaveAsync(value);
            return Ok(response);
        }

        // PUT api/v1/scoresrecord/SV51?studentCode=U20201F479
        [HttpPut("{classCode}")]
        public async Task<ActionResult<ScoresRecordResponse>> Put(string classCode, [FromQuery] string studentCode, [FromBody] SaveScoresRecordResource value)
        {
            // Get id of the score based con class and student
            var recordId = await _scoresRecordService.FindByStudentCodeAndCourseCodeAsync(studentCode, classCode);
            var response = await _scoresRecordService.UpdateAsync(recordId.Id, value);
            return Ok(response);
        }

        // DELETE api/scoresrecord/SV51?studentCode=U20201F479
        [HttpDelete("{classCode}")]
        public async Task<ActionResult<ScoresRecordResponse>> Delete(string classCode, [FromQuery] string studentCode)
        {
            var recordId = await _scoresRecordService.FindByStudentCodeAndCourseCodeAsync(studentCode, classCode);
            var response = await _scoresRecordService.DeleteAsync(recordId.Id);
            return Ok(response);
        }
    }
}