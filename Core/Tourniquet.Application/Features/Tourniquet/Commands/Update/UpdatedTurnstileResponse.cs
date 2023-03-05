using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Update
{
    public class UpdatedTurnstileResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int Queue { get; set; }
        public Status Status { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
    }
}