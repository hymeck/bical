using FluentValidation;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class CreateBirthNoteCommandValidator : AbstractValidator<CreateBirthNoteCommand>
    {
        public CreateBirthNoteCommandValidator()
        {
            // todo: validate date
            
            RuleFor(c => c.DisplayedName)
                .NotNull()
                .MaximumLength(70);
        }
    }
}