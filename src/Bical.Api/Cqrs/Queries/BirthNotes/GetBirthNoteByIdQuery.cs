using Bical.Api.Responses;
using LanguageExt;
using MediatR;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetBirthNoteByIdQuery: IRequest<Option<BirthNoteDtoResponse>>
    {
        public ulong Id { get; }

        public GetBirthNoteByIdQuery(ulong id)
        {
            Id = id;
        }
    }
}