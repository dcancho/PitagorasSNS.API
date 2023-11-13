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
        }
    }
}