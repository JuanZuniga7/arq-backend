using AutoMapper;

namespace arq_backend
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<Entities.User, Models.CreateUser>();
            CreateMap<Models.CreateUser, Entities.User>();
            CreateMap<Entities.User, Models.UserDTO>();
            CreateMap<Models.UserDTO, Entities.User>();
            CreateMap<Entities.User, Models.FullUserDto>();
            CreateMap<Models.FullUserDto, Entities.User>();
            CreateMap<Entities.Role, Models.RoleDTO>();
            CreateMap<Models.RoleDTO, Entities.Role>();
            CreateMap<Entities.Subject, Models.SubjectDTO>();
            CreateMap<Models.SubjectDTO, Entities.Subject>();
            CreateMap<Entities.Material, Models.MaterialDTO>();
            CreateMap<Models.MaterialDTO, Entities.Material>();
            CreateMap<Entities.Subject, Models.CreateSubject>();
            CreateMap<Models.CreateSubject, Entities.Subject>();
        }
    }
}
