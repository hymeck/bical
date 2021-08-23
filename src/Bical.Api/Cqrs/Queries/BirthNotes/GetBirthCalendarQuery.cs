using Bical.Api.Responses;
using MediatR;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetBirthCalendarQuery : IRequest<BirthNoteListDtoResponse>
    {
        // todo: add id of a user
        public GetBirthCalendarQuery()
        {
        }
    }
}