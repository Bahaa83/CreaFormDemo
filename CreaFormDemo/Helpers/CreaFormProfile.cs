using AutoMapper;
using CreaFormDemo.DtoModel.ClientDtoModel;
using CreaFormDemo.DtoModel.GeneralQuesDtoModel;
using CreaFormDemo.DtoModel.MedicineDtoModel;
using CreaFormDemo.DtoModel.SymtomDtoModel;
using CreaFormDemo.DtoModel.UserDtoModel;
using CreaFormDemo.DtoModel.WellBeingDtoModel;
using CreaFormDemo.Entitys.Clientprofile;
using CreaFormDemo.Entitys.Symptoms;
using CreaFormDemo.Entitys.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel
{
    public class CreaFormProfile : Profile
    {
        public CreaFormProfile()
        {
            CreateMap<AdvisorDto, CreateAdvisorDto>().ForMember(des => des.ConfirmEmail, opt => opt.MapFrom(scr => scr.Email));
            CreateMap<CreateAdvisorDto, AdvisorDto>();
            CreateMap<CreateAdvisorDto, Advisor>().ReverseMap();
            CreateMap<Advisor, AdvisorDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreatedUserDto>().ReverseMap();
            CreateMap<Client, ClientToReturnDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientDto, CompletionClientDto>().ReverseMap();
            CreateMap<Client, CompletionClientDto>().ReverseMap();
            CreateMap<GeneralQuesDto, CreateGeneralQuesDto>().ReverseMap();
            CreateMap<GeneralQuesDto, GeneralQuestions>().ReverseMap();
            CreateMap<GeneralQuestions, CreateGeneralQuesDto>().ReverseMap();
            CreateMap<CreateMedicineDto, MedicineDto>().ReverseMap();
            CreateMap<Medicine, MedicineDto>().ReverseMap();
            CreateMap<Medicine, CreateMedicineDto>().ReverseMap();
            CreateMap<Well_being,CreateWellBeing >().ReverseMap();
            CreateMap<Well_being, WellBeingToReturn>().ReverseMap();
            CreateMap<ClientSymptom,SymtomAnswer>().ReverseMap();
            CreateMap<ClientSymtomOverview,ClientSymptom>().ReverseMap();



        }

    }
}
