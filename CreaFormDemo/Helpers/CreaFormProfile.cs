﻿using AutoMapper;
using CreaFormDemo.DtoModel.ClientDtoModel;
using CreaFormDemo.DtoModel.UserDtoModel;
using CreaFormDemo.Entitys.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel
{
    public class CreaFormProfile:Profile
    {
        public CreaFormProfile()
        {
            CreateMap<AdvisorDto, CreateAdvisorDto>().ForMember(des => des.ConfirmEmail, opt => opt.MapFrom(scr => scr.Email));
            CreateMap<CreateAdvisorDto, AdvisorDto>();
            CreateMap<Advisor, EditAdvisorDto>().ReverseMap();
            CreateMap<Advisor, AdvisorDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreatedUserDto>().ReverseMap();
            CreateMap<User,UserLogInDto>().ReverseMap();

            CreateMap<User, UserforRegister>().ReverseMap();
            CreateMap<Client,ClientDto>().ReverseMap();
        }
    }
}
