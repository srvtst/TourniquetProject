using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Tourniquet;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetDayTourniquet
{
    public class GetDayTurnstileQueryHandler : IRequestHandler<GetDayTurnstileQueryCommand, List<GetDayTurnstileQueryResponse>>
    {
        private ITurnstileReadRepository _turnstileReadRepository;
        private IMapper _mapper;
        public GetDayTurnstileQueryHandler(ITurnstileReadRepository turnstileReadRepository, IMapper mapper)
        {
            _turnstileReadRepository = turnstileReadRepository;
            _mapper = mapper;
        }

        public async Task<List<GetDayTurnstileQueryResponse>> Handle(GetDayTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            var dayTurnstile = _turnstileReadRepository.GetWhere(x => x.DateOfEntry.Day == request.DateTime.Day || x.ExitDate.Day == request.DateTime.Day).ToList();
            var response = _mapper.Map<List<GetDayTurnstileQueryResponse>>(dayTurnstile);
            return response;
        }
    }
}