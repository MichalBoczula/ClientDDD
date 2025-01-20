using Client.Domian.RichDomainStyle.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Infrastructure.Configuration
{
    public class VerificationStatusConfiguration : IEntityTypeConfiguration<VerificationStatus>
    {
        public void Configure(EntityTypeBuilder<VerificationStatus> builder)
        {
            builder.ToTable("DC_VerificationStatus");

            builder.Property<int>("Id");
            builder.HasKey("Id");

            builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasData(
            new { Id = 1, Name = "Verified" });
            
            //builder.HasData(
            //new  { Id = 2, Name = "Pending" });

            //builder.HasData(
            //new { Id = 3, Name = "Rejected" });
        }
    }
}
