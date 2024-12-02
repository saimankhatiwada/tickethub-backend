using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketHub.Domain.Events.Tickets;
using TicketHub.Domain.Events.Tickets.Amenities;

namespace TicketHub.Infrastructure.Configurations;

internal sealed class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.ToTable("amenities");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion(id => id.Value, value => new AmenityId(value));

        builder.Property(a => a.Name)
            .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(a => a.Description)
            .HasConversion(description => description.Value, value => new Description(value));

        builder.HasOne<Ticket>()
            .WithMany()
            .HasForeignKey(a => a.TicketId);
    }

}
