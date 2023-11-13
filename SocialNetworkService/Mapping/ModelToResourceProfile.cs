using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Class, ClassResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<ScoresRecord, ScoresRecordResource>();
            CreateMap<Student, StudentResource>();
            CreateMap<Teacher, TeacherResource>();
            CreateMap<Post, PostResource>();
        }
    }
}