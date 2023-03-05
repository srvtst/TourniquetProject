using MediatR;
using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Commands.Update
{
    public class UpdatedPersonCommand : IRequest<UpdatedPersonResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
    }
}