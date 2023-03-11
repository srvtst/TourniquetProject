using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Dtos.Auth
{
    public class PersonCreateAndRegister
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
    }
}