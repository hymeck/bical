using FluentValidation;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetNearestBirthdaysQueryValidator : AbstractValidator<GetNearestBirthdaysQuery>
    {
        public GetNearestBirthdaysQueryValidator()
        {
            RuleFor(x => x.Days)
                .InclusiveBetween(-365, 365);
        }
    }
}