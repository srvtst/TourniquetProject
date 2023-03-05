using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Remove
{
    public class RemoveTurnstileCommand : IRequest<RemoveTurnstileResponse>
    {
        public int Id { get; set; }
    }
}