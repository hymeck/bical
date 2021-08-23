using Bical.Api.Responses;
using LanguageExt;
using MediatR;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetBirthNoteByIdQuery: IRequest<Option<BirthNoteDtoResponse>>
    {
        public ushort Id { get; }

        public GetBirthNoteByIdQuery(ushort id)
        {
            Id = id;
        }
    }
}