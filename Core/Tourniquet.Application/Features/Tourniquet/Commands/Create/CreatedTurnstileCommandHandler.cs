using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Application.Services.RabbitMQ;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Create
{
    public class CreatedTurnstileCommandHandler : IRequestHandler<CreatedTurnstileCommand, CreatedTurnstileResponse>
    {
        private IMapper _mapper;
        private ITurnstileWriteRepository _turnstileWrite;
        private IPublisherService _publisherService;
        private IConsumerService _consumerService;
        private ILogger<CreatedTurnstileCommandHandler> _logger;

        public CreatedTurnstileCommandHandler(IMapper mapper, ITurnstileWriteRepository turnstileWrite, IPublisherService publisherService
            , IConsumerService consumerService, ILogger<CreatedTurnstileCommandHandler> logger)
        {
            _mapper = mapper;
            _turnstileWrite = turnstileWrite;
            _publisherService = publisherService;
            _consumerService = consumerService;
            _logger = logger;
        }

        public async Task<CreatedTurnstileResponse> Handle(CreatedTurnstileCommand request, CancellationToken cancellationToken)
        {
            Turnstile mappedTurnstile = _mapper.Map<Turnstile>(request);
            var createdTrunstile = await _turnstileWrite.AddAsync(mappedTurnstile);
            _logger.LogInformation("Turnikeden giriş yapılmıştır.");
            _publisherService.Publish(createdTrunstile);
            _logger.LogInformation("Turnikeden yapılan giriş verisi rabbit mq ye iletilmiştir.");
            CreatedTurnstileResponse response = _mapper.Map<CreatedTurnstileResponse>(createdTrunstile);
            _consumerService.Start();
            return response;
        }
    }
}