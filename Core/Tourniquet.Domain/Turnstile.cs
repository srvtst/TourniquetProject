using Tourniquet.Domain.Common;
using Tourniquet.Domain.Enums;

namespace Tourniquet.Domain
{
    public class Turnstile : BaseEntity
    {
        public int Queue { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
        public Status Status { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}