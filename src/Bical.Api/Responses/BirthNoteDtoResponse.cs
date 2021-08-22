using System;

namespace Bical.Api.Responses
{
    public class BirthNoteDtoResponse
    {
        public ushort BirthNoteId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Added { get; set; }
        public DateTime? Modified { get; set; }
    }
}