using System.Collections.Generic;

namespace Bical.Api.Responses
{
    public class BirthNoteListDtoResponse
    {
        public int Count { get; }
        public IList<BirthNoteDtoResponse> BirthNotes { get; }

        public BirthNoteListDtoResponse(IList<BirthNoteDtoResponse> birthNotes)
        {
            BirthNotes = birthNotes ?? new List<BirthNoteDtoResponse>(0);
            Count = BirthNotes.Count;
        }
    }
}