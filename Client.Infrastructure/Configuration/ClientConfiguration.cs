using Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Infrastructure.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<RichClient>
    {
        public void Configure(EntityTypeBuilder<RichClient> builder)
        {
            builder.ToTable("RichClients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Pesel)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.BirthDate)
                .IsRequired();

            // ---------------------------------------------------
            // 1) OwnsMany: RichPhone list
            // ---------------------------------------------------
            builder.OwnsMany(
                x => x.PhoneContacts,
                phoneBuilder =>
                {
                    phoneBuilder.ToTable("RichClientPhones");

                    phoneBuilder.HasKey("Id");
                    phoneBuilder.WithOwner()
                                .HasForeignKey("RichClientId");

                    phoneBuilder.Property(p => p.ClientId)
                        .HasColumnName("ClientId")
                        .IsRequired();

                    phoneBuilder.Property(p => p.Number)
                        .HasColumnName("Number")
                        .HasMaxLength(20)
                        .IsRequired();

                    phoneBuilder.Property(p => p.Prefix)
                        .HasColumnName("Prefix")
                        .HasMaxLength(10)
                        .IsRequired();
                }
            );

            // ---------------------------------------------------
            // 2) OwnsMany: RichEmail list
            // ---------------------------------------------------
            builder.OwnsMany(
                x => x.EmailContacts,
                emailBuilder =>
                {
                    emailBuilder.ToTable("RichClientEmails");
                    emailBuilder.HasKey("Id");
                    emailBuilder.WithOwner().HasForeignKey("RichClientId");

                    // Columns
                    emailBuilder.Property(e => e.ClientId)
                        .HasColumnName("ClientId")
                        .IsRequired();

                    emailBuilder.Property(e => e.Content)
                        .HasColumnName("Content")
                        .HasMaxLength(100)
                        .IsRequired();

                    emailBuilder.Property(e => e.Domain)
                        .HasColumnName("Domain")
                        .HasMaxLength(100)
                        .IsRequired();
                }
            );

            // ---------------------------------------------------
            // 3) OwnsMany: RichAddress list
            // ---------------------------------------------------
            builder.OwnsMany(
                x => x.AddressContacts,
                addressBuilder =>
                {
                    addressBuilder.ToTable("RichClientAddresses");
                    addressBuilder.HasKey("Id");
                    addressBuilder.WithOwner().HasForeignKey("RichClientId");

                    addressBuilder.Property(a => a.ClientId)
                        .HasColumnName("ClientId")
                        .IsRequired();

                    addressBuilder.Property(a => a.Street)
                        .HasColumnName("Street")
                        .HasMaxLength(200)
                        .IsRequired();

                    addressBuilder.Property(a => a.BuildingNumber)
                        .HasColumnName("BuildingNumber")
                        .HasMaxLength(50)
                        .IsRequired();

                    addressBuilder.Property(a => a.ApartmentNumber)
                        .HasColumnName("ApartmentNumber")
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.City)
                        .HasColumnName("City")
                        .HasMaxLength(100)
                        .IsRequired();

                    addressBuilder.Property(a => a.PostCode)
                        .HasColumnName("PostCode")
                        .HasMaxLength(20)
                        .IsRequired();

                    addressBuilder.Property(a => a.Country)
                        .HasColumnName("Country")
                        .HasMaxLength(100)
                        .IsRequired();
                }
            );
        }
    }
}