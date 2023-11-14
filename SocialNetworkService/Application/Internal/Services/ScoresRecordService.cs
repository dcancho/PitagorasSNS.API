using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class ScoresRecordService : IScoresRecordService
    {
        private readonly IScoresRecordRepository _scoresRecordRepository;
        private readonly IMapper _mapper;

        public async Task<ScoresRecordResponse> DeleteAsync(string id)
        {
            var scoresRecord = await _scoresRecordRepository.FindByIdAsync(id);
            if (scoresRecord == null)
            {
                return new ScoresRecordResponse("Scores record not found.");
            }
            try
            {
                _scoresRecordRepository.Remove(scoresRecord);
                return new ScoresRecordResponse(_mapper.Map<ScoresRecord, ScoresRecordResource>(scoresRecord));
            }
            catch
            {
                return new ScoresRecordResponse("An error occurred when deleting the scores record.");
            }
        }

        public async Task<ScoresRecordResource?> FindByStudentCodeAndCourseCodeAsync(string studentCode, string courseCode)
        {
            var courseScoresRecords = await _scoresRecordRepository.FindRecordsByCourseCode(courseCode);
            var studentScoresRecord = courseScoresRecords.FirstOrDefault(c => c.StudentCode == studentCode);
            return studentScoresRecord == null ? new ScoresRecordResource() : _mapper.Map<ScoresRecord, ScoresRecordResource>(studentScoresRecord);
        }

        public async Task<IEnumerable<ScoresRecordResource>> ListAllAsync()
        {
            var scoresRecords = await _scoresRecordRepository.ListAsync();
            return _mapper.Map<IEnumerable<ScoresRecord>, IEnumerable<ScoresRecordResource>>(scoresRecords);
        }

        public async Task<IEnumerable<ScoresRecordResource>> ListByClassCodeAsync(string classCode)
        {
            var scoresRecords = await _scoresRecordRepository.FindRecordsByClassCode(classCode);
            return _mapper.Map<IEnumerable<ScoresRecord>, IEnumerable<ScoresRecordResource>>(scoresRecords);
        }

        public async Task<IEnumerable<ScoresRecordResource>> ListByCourseCodeAsync(string courseCode)
        {
            var scoresRecords = await _scoresRecordRepository.FindRecordsByCourseCode(courseCode);
            return _mapper.Map<IEnumerable<ScoresRecord>, IEnumerable<ScoresRecordResource>>(scoresRecords);
        }

        public async Task<IEnumerable<ScoresRecordResource>> ListByStudentCodeAsync(string studentCode)
        {
            var scoresRecords = await _scoresRecordRepository.FindRecordsByStudentCode(studentCode);
            return _mapper.Map<IEnumerable<ScoresRecord>, IEnumerable<ScoresRecordResource>>(scoresRecords);
        }

        public async Task<ScoresRecordResponse> SaveAsync(SaveScoresRecordResource scoresRecord)
        {
            var newScoresRecord = _mapper.Map<SaveScoresRecordResource, ScoresRecord>(scoresRecord);
            try
            {
                await _scoresRecordRepository.AddAsync(newScoresRecord);
                return new ScoresRecordResponse(_mapper.Map<ScoresRecord, ScoresRecordResource>(newScoresRecord));
            }
            catch
            {
                return new ScoresRecordResponse("An error occurred when saving the scores record.");
            }
        }

        public async Task<ScoresRecordResponse> UpdateAsync(string id, SaveScoresRecordResource scoresRecord)
        {
            var existingScoresRecord = await _scoresRecordRepository.FindByIdAsync(id);
            if (existingScoresRecord == null)
            {
                return new ScoresRecordResponse("Scores record not found.");
            }

            if (existingScoresRecord.StudentCode != scoresRecord.StudentCode || existingScoresRecord.CourseCode != scoresRecord.CourseCode)
            {
                return new ScoresRecordResponse("Student code and course code do not match.");
            }

            var newScoresRecord = _mapper.Map<SaveScoresRecordResource, ScoresRecord>(scoresRecord);
            existingScoresRecord.Score = newScoresRecord.Score;

            try
            {
                _scoresRecordRepository.Update(existingScoresRecord);
                return new ScoresRecordResponse(_mapper.Map<ScoresRecord, ScoresRecordResource>(existingScoresRecord));
            }
            catch
            {
                return new ScoresRecordResponse("An error occurred when updating the scores record.");
            }
        }
    }
}
