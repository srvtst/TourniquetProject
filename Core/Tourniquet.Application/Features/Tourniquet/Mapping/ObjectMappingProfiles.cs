using AutoMapper;
using Tourniquet.Application.Dtos.Tourniquet;
using Tourniquet.Application.Features.Tourniquet.Commands.Create;
using Tourniquet.Application.Features.Tourniquet.Commands.Update;
using Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetByIdTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetDayTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetMonthTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetQueueTourniquet;
using Tourniquet.Domain.Entities;

namespace Tourniquet.Application.Features.Tourniquet.Mapping
{
    public class ObjectMappingProfiles : Profile
    {
        public ObjectMappingProfiles()
        {
            CreateMap<Turnstile, CreatedTurnstileCommand>().ReverseMap();
            CreateMap<Turnstile, CreatedTurnstileResponse>().ReverseMap();
            CreateMap<Turnstile, UpdatedTurnstileCommand>().ReverseMap();
            CreateMap<Turnstile, UpdatedTurnstileResponse>().ReverseMap();
            CreateMap<Turnstile, GetDayTurnstileQueryResponse>().ReverseMap();
            CreateMap<Turnstile, GetAllTurnstileQueryResponse>().ReverseMap();
            CreateMap<Turnstile, GetMonthTurnstileQueryResponse>().ReverseMap();
            CreateMap<Turnstile, GetQueueTurnstileQueryResponse>().ReverseMap();
            CreateMap<Turnstile, GetByIdTurnstileQueryResponse>().ReverseMap();
            CreateMap<Turnstile, TurnstileList>().ReverseMap();
        }
    }
}