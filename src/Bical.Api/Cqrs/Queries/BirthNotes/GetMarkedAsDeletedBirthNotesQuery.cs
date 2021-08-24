using Bical.Api.Responses;
using MediatR;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetMarkedAsDeletedBirthNotesQuery : IRequest<BirthNoteListDtoResponse>
    {
    }
}