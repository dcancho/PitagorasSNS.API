// Resource to modelprofile
using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<ClassResource, Class>();
            CreateMap<StudentResource, Student>();
            CreateMap<TeacherResource, Teacher>();
            CreateMap<ScoresRecordResource, ScoresRecord>();
            CreateMap<PostResource, Post>();
            CreateMap<CourseResource, Course>();
            CreateMap<SaveClassResource, Class>()
            .ForMember(dest => dest.ClassCode, opt => opt.MapFrom(src => src.ClassCode))
            .ForMember(dest => dest.TeacherCode, opt => opt.MapFrom(src => src.TeacherCode))
            .ForMember(dest => dest.StudentsEnrolledCode, opt => opt.MapFrom(src => src.StudentsEnrolledCode))
            .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode));
            CreateMap<SaveStudentResource, Student>();
            CreateMap<SaveTeacherResource, Teacher>();
            CreateMap<SaveScoresRecordResource, ScoresRecord>();
            CreateMap<SavePostResource, Post>();
            CreateMap<SaveCourseResource, Course>();
        }
    }
}