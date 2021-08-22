using Bical.Api.Responses;
using LanguageExt;
using MediatR;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetBirthdayNoteNyIdQuery: IRequest<Option<BirthNoteDtoResponse>>
    {
        public ushort Id { get; }

        public GetBirthdayNoteNyIdQuery(ushort id)
        {
            Id = id;
        }
    }
}