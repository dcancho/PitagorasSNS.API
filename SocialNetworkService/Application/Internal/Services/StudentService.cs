using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> DeleteAsync(string studentCode)
        {
            var student = await _studentRepository.GetStudentByCodeAsync(studentCode);
            if (student == null)
            {
                return new StudentResponse("Student not found.");
            }
            try
            {
                _studentRepository.Remove(student);
                return new StudentResponse(_mapper.Map<Student, StudentResource>(student));
            }
            catch
            {
                return new StudentResponse("An error occurred when deleting the student.");
            }
        }

        public async Task<StudentResource> FindByStudentCodeAsync(string studentCode)
        {
            var student = await _studentRepository.GetStudentByCodeAsync(studentCode);
            return _mapper.Map<Student, StudentResource>(student);
        }

        public async Task<IEnumerable<StudentResource>> ListAllAsync()
        {
            var students = await _studentRepository.ListAsync();
            return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);

        }

        public async Task<IEnumerable<string>> ListTopStudentsAsync(int top = 10)
        {
            var students = await _studentRepository.ListAsync();
            var topStudents = students.OrderByDescending(s => s.AverageScore).Take(top);
            var studentCodes = topStudents.Select(s => s.StudentCode);
            return studentCodes;
        }

        public async Task<StudentResponse> SaveAsync(SaveStudentResource studentResource)
        {
            var student = _mapper.Map<SaveStudentResource, Student>(studentResource);
            try
            {
                await _studentRepository.AddAsync(student);
                return new StudentResponse(_mapper.Map<Student, StudentResource>(student));
            }
            catch
            {
                return new StudentResponse("An error occurred when saving the student.");
            }
        }

        public async Task<StudentResponse> UpdateAsync(string studentCode, SaveStudentResource studentResource)
        {
            var existingStudent = await _studentRepository.GetStudentByCodeAsync(studentCode);
            if (existingStudent == null)
            {
                return new StudentResponse("Student not found.");
            }
            var student = _mapper.Map<SaveStudentResource, Student>(studentResource);
            student.Id = existingStudent.Id;
            try
            {
                _studentRepository.Update(student);
                return new StudentResponse(_mapper.Map<Student, StudentResource>(student));
            }
            catch
            {
                return new StudentResponse("An error occurred when updating the student.");
            }
        }
    }
}
