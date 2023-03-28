using AutoMapper;
using Tourniquet.Application.Dtos.Auth;
using Tourniquet.Application.Features.Auth.Commands.Login;
using Tourniquet.Application.Features.Auth.Commands.Register;
using Tourniquet.Application.Features.Commands.Remove;
using Tourniquet.Application.Features.Commands.Update;
using Tourniquet.Application.Features.Queries.GetAllPersons;
using Tourniquet.Domain.Entities;

namespace Tourniquet.Application.Features.Mapping
{
    public class ObjectMappingProfiles : Profile
    {
        public ObjectMappingProfiles()
        {
            CreateMap<Person, UpdatedPersonCommand>().ReverseMap();
            CreateMap<Person, UpdatedPersonResponse>().ReverseMap();
            CreateMap<Person, PersonCreateAndRegister>().ReverseMap();
            CreateMap<Person, PersonForLogin>().ReverseMap();
            CreateMap<Person, PersonLoginCommand>().ReverseMap();
            CreateMap<Person, PersonRegisterCommand>().ReverseMap();
            CreateMap<Person, RemovePersonCommand>().ReverseMap();
            CreateMap<Person, RemovePersonResponse>().ReverseMap();
            CreateMap<Person, GetAllPersonQueryResponse>().ReverseMap();
        }
    }
}