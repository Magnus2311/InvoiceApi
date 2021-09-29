using AutoMapper;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Username));
            CreateMap<User, UserDTO>()
               .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Username));
        }
    }
}
