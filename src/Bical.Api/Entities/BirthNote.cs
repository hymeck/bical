﻿using System;

namespace Bical.Api.Entities
{
    public class BirthNote : IAuditableDate, IDeletable
    {
        public ulong Id { get; set; }
        public string DisplayedName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Added { get; set; }
        public DateTime? Modified { get; set; }

        public bool IsDeleted { get; set; }
        public override string ToString() => DisplayedName;
    }
}