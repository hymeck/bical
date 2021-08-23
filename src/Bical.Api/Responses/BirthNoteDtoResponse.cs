using System;

namespace Bical.Api.Responses
{
    public class BirthNoteDtoResponse
    {
        public ulong BirthNoteId { get; set; }
        public string DisplayedName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Added { get; set; }
        public DateTime? Modified { get; set; }
    }
}