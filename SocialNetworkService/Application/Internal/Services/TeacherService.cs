using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<TeacherResponse> DeleteAsync(string code)
        {
            var teacher = await _teacherRepository.GetTeacherByCodeAsync(code);
            if (teacher == null)
            {
                return new TeacherResponse("Teacher not found.");
            }
            try
            {
                _teacherRepository.Remove(teacher);
                return new TeacherResponse(_mapper.Map<Teacher, TeacherResource>(teacher));
            }
            catch
            {
                return new TeacherResponse("An error occurred when deleting the teacher.");
            }
        }

        public async Task<TeacherResource> FindByCodeAsync(string code)
        {
            var teacher = await _teacherRepository.GetTeacherByCodeAsync(code);
            return _mapper.Map<Teacher, TeacherResource>(teacher);
        }

        public async Task<IEnumerable<TeacherResource>> ListAllAsync()
        {
            var teachers = await _teacherRepository.ListAsync();
            return _mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherResource>>(teachers);
        }

        public async Task<TeacherResponse> SaveAsync(SaveTeacherResource teacher)
        {
            var newTeacher = _mapper.Map<SaveTeacherResource, Teacher>(teacher);
            try
            {
                await _teacherRepository.AddAsync(newTeacher);
                return new TeacherResponse(_mapper.Map<Teacher, TeacherResource>(newTeacher));
            }
            catch
            {
                return new TeacherResponse("An error occurred when saving the teacher.");
            }
        }

        public async Task<TeacherResponse> UpdateAsync(string code, SaveTeacherResource teacher)
        {
            var existingTeacher = await _teacherRepository.GetTeacherByCodeAsync(code);
            if (existingTeacher == null)
            {
                return new TeacherResponse("Teacher not found.");
            }
            var newTeacher = _mapper.Map<SaveTeacherResource, Teacher>(teacher);
            newTeacher.Id = existingTeacher.Id;
            try
            {
                _teacherRepository.Update(newTeacher);
                return new TeacherResponse(_mapper.Map<Teacher, TeacherResource>(existingTeacher));
            }
            catch
            {
                return new TeacherResponse("An error occurred when updating the teacher.");
            }
        }
    }
}
