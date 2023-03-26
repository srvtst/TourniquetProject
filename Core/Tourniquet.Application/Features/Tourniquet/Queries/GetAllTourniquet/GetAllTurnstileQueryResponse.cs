using Tourniquet.Application.Dtos.Tourniquet;
using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryResponse
    {
        public IList<TurnstileList> TurnstileLists { get; set; }
        public int Count { get; set; }
        public string Message => "Turnikeden giriş yapan kişilere ait kayıtlar listelenmiştir.";
    }
}