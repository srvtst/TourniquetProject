using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryResponse
    {
        public int Queue { get; set; }
        public int PersonId { get; set; }
        public DateTime DateOfEnty { get; set; }
        public DateTime ExitDate { get; set; }
        public Status  Status { get; set; }
    }
}