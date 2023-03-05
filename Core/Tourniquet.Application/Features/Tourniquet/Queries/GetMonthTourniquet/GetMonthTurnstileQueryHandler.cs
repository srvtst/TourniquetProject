using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Tourniquet;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetMonthTourniquet
{
    public class GetMonthTurnstileQueryHandler : IRequestHandler<GetMonthTurnstileQueryCommand, IList<GetMonthTurnstileQueryResponse>>
    {
        private ITurnstileReadRepository _turnstileReadRepository;
        private IMapper _mapper;
        public GetMonthTurnstileQueryHandler(ITurnstileReadRepository turnstileReadRepository,IMapper mapper)
        {
            _turnstileReadRepository = turnstileReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetMonthTurnstileQueryResponse>> Handle(GetMonthTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            var monthTurnstile = _turnstileReadRepository.GetWhere(x=>x.DateOfEntry.Month == request.DateTime.Month || x.DateOfEntry.Month == request.DateTime.Month).ToList();
            var response = _mapper.Map<IList<GetMonthTurnstileQueryResponse>>(monthTurnstile);
            return response;
        }
    }
}