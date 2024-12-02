using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketHub.Domain.Events;
using TicketHub.Domain.Users;

namespace TicketHub.Infrastructure.Configurations;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("events");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new EventId(value));

        builder.Property(e => e.Name)
            .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(e => e.Description)
            .HasConversion(description => description.Value, value => new Description(value));

        builder.Property(e => e.BannerUrl)
            .HasConversion(bannerUrl => bannerUrl.Value, value => new BannerUrl(value));

        builder.OwnsOne(e => e.Address);

        builder.Property(e => e.Venu)
            .HasConversion(venu => venu.Value, value => new Venu(value));

        builder.Property(e => e.Type)
            .HasConversion(type => type.Value, value => Domain.Events.Type.FromType(value));

        builder.Property(e => e.Progress)
            .HasConversion(progress => progress.Value, value => Progress.FromProgress(value));

        builder.Property(e => e.Status)
            .HasConversion(status => status.Value, value => Status.FromStatus(value));

        builder.Property(e => e.Tags)
            .HasConversion(tags => tags.Select(t => t.Value).ToList(), values => values.Select(v => new Tag(v)).ToList());

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId);
    }
}
