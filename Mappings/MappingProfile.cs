using AutoMapper;
using Diary_Server.Dtos.Diarys;
using Diary_Server.Dtos.Users;
using Diary_Server.Models;

namespace Diary_Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Diary, DiaryDto>();
            CreateMap<CreateDiaryDto, Diary>()
               .ForMember(dest => dest.DiaryDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.DiaryDate, DateTimeKind.Utc)));
            CreateMap<UpdateDiaryDto, Diary>();
             
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
