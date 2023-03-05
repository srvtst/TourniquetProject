using MediatR;
using Tourniquet.Domain.Enums;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Create
{
    //request yapacağız nesneyi dönecek response bilgisine göre tanımlıyoruz.
    public class CreatedTurnstileCommand : IRequest<CreatedTurnstileResponse>
    {
        public int PersonId { get; set; }
        public int Queue { get; set; }
        public Status Status => Status.Active;
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate => DateTime.Now;
    }
}