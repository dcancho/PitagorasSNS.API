using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CourseResponse> DeleteAsync(string courseCode)
        {
            Course resource;

            try
            {
                resource = await _courseRepository.GetCourseByCode(courseCode);
            }
            catch {
                return new CourseResponse("An error occurred when deleting the course: " + courseCode + ". Maybe it doesn't exist.");
            }
            var courseResource = _mapper.Map<Course, CourseResource>(resource);

            try
            {
                await _courseRepository.DeleteCourseByCode(courseCode);
                return new CourseResponse(courseResource);
            }
            catch
            {
                return new CourseResponse("An error occurred when deleting the class: " + courseCode);
            }
        }

        public async Task<CourseResource> FindByCourseCodeAsync(string courseCode)
        {
            var courseResource = await _courseRepository.GetCourseByCode(courseCode);
            return _mapper.Map<Course, CourseResource>(courseResource);
        }

        public async Task<IEnumerable<CourseResource>> ListAllAsync()
        {
            var courses = await _courseRepository.ListAsync();
            return _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
        }

        public async Task<IEnumerable<CourseResource>> ListByCreditAmountAsync(int credits)
        {
            var allCourses = await _courseRepository.ListAsync();
            var courses = allCourses.Where(c => c.CourseCredits == credits);
            return _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
        }

        public async Task<CourseResponse> SaveAsync(SaveCourseResource courseResource)
        {
            var courseModel = _mapper.Map<SaveCourseResource, Course>(courseResource);
            try{
                await _courseRepository.AddAsync(courseModel);
                return new CourseResponse(_mapper.Map<Course, CourseResource>(await _courseRepository.GetCourseByCode(courseModel.CourseCode)));
            }
            catch
            {
                return new CourseResponse("An error occurred when saving the course: " + courseModel.CourseCode);
            }
        }

        public async Task<CourseResponse> UpdateAsync(string courseCode, SaveCourseResource courseResource)
        {
            if(courseCode != courseResource.CourseCode)
                return new CourseResponse("Course code does not match.");
                
            var courseModel = _mapper.Map<SaveCourseResource, Course>(courseResource);
            var resource = await _courseRepository.GetCourseByCode(courseCode);
            if (resource == null)
                return new CourseResponse("Course not found.");
            resource.CourseName = courseModel.CourseName;
            resource.CourseCredits = courseModel.CourseCredits;
            try
            {
                _courseRepository.Update(resource);
                return new CourseResponse(_mapper.Map<Course, CourseResource>(resource));
            }
            catch
            {
                return new CourseResponse("An error occurred when updating the course: " + courseCode);
            }
        }
    }
}
