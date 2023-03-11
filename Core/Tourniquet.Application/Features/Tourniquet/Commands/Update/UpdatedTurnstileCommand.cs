using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Update
{
    public class UpdatedTurnstileCommand : IRequest<UpdatedTurnstileResponse>
    {
        public int Id { get; set; }
        public int Queue { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
    }
}