using System;

namespace Bical.Api.Entities
{
    public interface IAuditableDate
    {
        public DateTime Added { get; set; }
        public DateTime? Modified { get; set; }
    }
}