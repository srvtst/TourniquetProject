using MediatR;

namespace Tourniquet.Application.Features.Commands.Remove
{
    public class RemovePersonCommand : IRequest<RemovePersonResponse>
    {
        public int Id { get; set; }
    }
}