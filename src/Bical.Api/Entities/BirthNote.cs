using System;

namespace Bical.Api.Entities
{
    public class BirthNote : IAuditableDate
    {
        public ushort Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Added { get; set; }
        public DateTime? Modified { get; set; }

        public override string ToString() => string.Join(' ', FirstName, MiddleName, LastName);
    }
}