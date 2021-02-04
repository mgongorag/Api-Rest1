using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;

namespace WebApplication1.Mapper
{
    public class SocialMapper : Profile
    {
        public SocialMapper()
        {
            CreateMap<TypeOfNotifications, TypeOfNotificationDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ListFriend, ListFriendDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}
