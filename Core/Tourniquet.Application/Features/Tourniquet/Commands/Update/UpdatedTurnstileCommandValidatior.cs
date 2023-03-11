using FluentValidation;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Update
{
    public class UpdatedTurnstileCommandValidatior : AbstractValidator<UpdatedTurnstileCommand>
    {
        public UpdatedTurnstileCommandValidatior()
        {
            //giriş tarihi (date of entry) çıkış tarihinden(exit date) küçük olması gerekiyor.
            RuleFor(x => x.DateOfEntry).LessThan(x => x.ExitDate);
        }
    }
}