using FluentValidation;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class UpdateBirthNoteCommandValidator : AbstractValidator<UpdateBirthNoteCommand>
    {
        public UpdateBirthNoteCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo((ulong) 1);

            RuleFor(x => x.DisplayedName)
                .NotEmpty()
                .MaximumLength(70);
        }
    }
}