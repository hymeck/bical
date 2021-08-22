using FluentValidation;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class CreateBirthdayNoteCommandValidator : AbstractValidator<CreateBirthdayNoteCommand>
    {
        public CreateBirthdayNoteCommandValidator()
        {
            // todo: validate date
            
            RuleFor(c => c.FirstName)
                .NotNull()
                .MaximumLength(35);
            
            RuleFor(c => c.LastName)
                .MaximumLength(35);
            
            RuleFor(c => c.MiddleName)
                .MaximumLength(35);
            
        }
    }
}