using Bical.Api.Responses;
using MediatR;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetNearestBirthdaysQuery : IRequest<BirthNoteListDtoResponse>
    {
        public int Days { get; }

        public GetNearestBirthdaysQuery(int days)
        {
            Days = days;
        }
    }
}
