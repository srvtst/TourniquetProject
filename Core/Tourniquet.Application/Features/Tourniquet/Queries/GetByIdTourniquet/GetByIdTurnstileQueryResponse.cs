using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetByIdTourniquet
{
    public class GetByIdTurnstileQueryResponse
    {
        public int Id { get; set; }
        public int Queue { get; set; }
        public int PersonId { get; set; }
        public Status Status { get; set; }
        public DateTime DateOfEnty { get; set; }
        public DateTime ExitDate { get; set; }
    }
}