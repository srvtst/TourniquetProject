using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetMonthTourniquet
{
    public class GetMonthTurnstileQueryResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int Queue { get; set; }
        public Status Status { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
    }
}