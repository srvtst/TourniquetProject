using MediatR;
using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Update
{
    public class UpdatedTurnstileCommand : IRequest<UpdatedTurnstileResponse>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Status Status => Status.Inactive;
        public int Queue { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
    }
}