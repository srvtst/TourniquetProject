using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetDayTourniquet
{
    public class GetDayTurnstileQueryResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int Queue { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
        public Status Status { get; set; }
    }
}