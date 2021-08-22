using Bical.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bical.Api.Persistence.Configurations
{
    public class BirthNoteConfiguration : IEntityTypeConfiguration<BirthNote>
    {
        public void Configure(EntityTypeBuilder<BirthNote> builder)
        {
            builder
                .ToTable("birth")
                .HasCharSet("utf8mb4")
                .HasComment("contains birth data of people");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("birth_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(e => e.FirstName)
                .HasColumnName("firstname")
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(e => e.MiddleName)
                .HasColumnName("middlename")
                .IsRequired(false)
                .HasMaxLength(40);
            
            builder
                .Property(e => e.LastName)
                .HasColumnName("lastname")
                .IsRequired(false)
                .HasMaxLength(40);
            
            builder
                .Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("dob")
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("date of birth");
            
            builder
                .Property(e => e.Added)
                .HasColumnType("datetime")
                .HasColumnName("added")
                .IsRequired();
            
            builder
                .Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified")
                .IsRequired(false);
        }
    }
}