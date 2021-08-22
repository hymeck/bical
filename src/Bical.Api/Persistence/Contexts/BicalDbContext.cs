using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Bical.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bical.Api.Persistence.Contexts
{
    public class BicalDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<BirthNote> BirthNotes { get; set; }
        public BicalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbContext Context => this;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // apply implementations of IEntityTypeConfiguration
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditableChanges(ChangeTracker.Entries<IAuditableDate>());
            return await base.SaveChangesAsync(cancellationToken);
        }

        private static void ApplyAuditableChanges(IEnumerable<EntityEntry<IAuditableDate>> auditableEntries)
        {
            foreach (var entry in auditableEntries) 
                MutateEntityDate(entry);
        }

        private static void MutateEntityDate(EntityEntry<IAuditableDate> entry)
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.Modified = DateTime.UtcNow;
                    break;

                case EntityState.Added:
                    entry.Entity.Added = DateTime.UtcNow;
                    break;
            }
        }
    }
}