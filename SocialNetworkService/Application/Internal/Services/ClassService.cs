using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }
        public async Task<ClassResponse> DeleteAsync(string classCode)
        {
            Class resource;

            try
            {
                resource = await _classRepository.GetClassByCode(classCode);
            }
            catch {
                return new ClassResponse("An error occurred when deleting the class: " + classCode + ". Maybe it doesn't exist.");
            }
            // Map Class to ClassResource using ModelToResourceProfile profile

            var classResource = _mapper.Map<Class, ClassResource>(resource);

            try
            {
                await _classRepository.DeleteClassByCode(classCode);
                return new ClassResponse(classResource);
            }
            catch
            {
                return new ClassResponse("An error occurred when deleting the class: " + classCode);
            }
        }

        public async Task<IEnumerable<ClassResource>> ListAllAsync()
        {
            var classes = await _classRepository.ListAsync();
            return _mapper.Map<IEnumerable<Class>, IEnumerable<ClassResource>>(classes);
        }

        public async Task<ClassResource> FindByClassCodeAsync(string classCode)
        {
            var classResource = await _classRepository.GetClassByCode(classCode);
            return _mapper.Map<Class, ClassResource>(classResource);
        }

        public async Task<IEnumerable<ClassResource>> ListByStudentCodeAsync(string studentCode)
        {
            var classes = await _classRepository.GetClassesByStudentCodeAsync(studentCode);
            return _mapper.Map<IEnumerable<Class>, IEnumerable<ClassResource>>(classes);
        }

        public async Task<IEnumerable<ClassResource>> ListByTeacherCodeAsync(string teacherCode)
        {
            var classes = await _classRepository.GetClassesByTeacherCode(teacherCode);
            return _mapper.Map<IEnumerable<Class>, IEnumerable<ClassResource>>(classes);
        }

        public async Task<ClassResponse> SaveAsync(SaveClassResource classResource)
        {
            System.Console.WriteLine(classResource);
            var classModel = _mapper.Map<SaveClassResource, Class>(classResource);
            System.Console.WriteLine(classModel);
            try
            {
                await _classRepository.AddAsync(classModel);
                return new ClassResponse(_mapper.Map<Class, ClassResource>(await _classRepository.GetClassByCode(classModel.ClassCode)));
            }
            catch
            {
                return new ClassResponse("An error occurred when saving the class: " + classResource.ClassCode);
            }
        }

        public async Task<ClassResponse> UpdateAsync(string classCode, SaveClassResource classResource)
        {
            if (classCode != classResource.ClassCode)
            {
                return new ClassResponse("The class code doesn't match the resource code.");
            }

            var classModel = _mapper.Map<SaveClassResource, Class>(classResource);

            try
            {
                _classRepository.Update(classModel);
                return new ClassResponse(_mapper.Map<Class, ClassResource>(await _classRepository.GetClassByCode(classModel.ClassCode)));
            }
            catch
            {
                return new ClassResponse("An error occurred when updating the class: " + classCode);
            }
        }
    }
}
