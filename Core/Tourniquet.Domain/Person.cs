using Tourniquet.Domain.Common;
using Tourniquet.Domain.Enums;

namespace Tourniquet.Domain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Turnstile? Turnstile { get; set; }
    }
}