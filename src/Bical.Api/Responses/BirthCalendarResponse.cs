using System.Collections.Generic;

namespace Bical.Api.Responses
{
    public class BirthCalendarResponse
    {
        public int Count { get; }
        public IList<BirthNoteDtoResponse> BirthNotes { get; }

        public BirthCalendarResponse(IList<BirthNoteDtoResponse> birthNotes)
        {
            BirthNotes = birthNotes ?? new List<BirthNoteDtoResponse>(0);
            Count = BirthNotes.Count;
        }
    }
}