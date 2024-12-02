using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketHub.Domain.Events;
using TicketHub.Domain.Events.Tickets;
using TicketHub.Domain.Shared;

namespace TicketHub.Infrastructure.Configurations;

internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("tickets");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasConversion(id => id.Value, value => new TicketId(value));

        builder.Property(t => t.Type)
            .HasConversion(type => type.Value, value => Domain.Events.Tickets.Type.FromType(value));

        builder.Property(t => t.Supply)
            .HasConversion(supply => supply.Value, value => Supply.FromSupply(value));

        builder.Property(t => t.Status)
            .HasConversion(status => status.Value, value => Domain.Events.Tickets.Status.FromStatus(value));

        builder.OwnsOne(t => t.Price, priceBuilder => priceBuilder.Property(money => money.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code)));
        
        builder.Property(t => t.Avilable)
            .HasConversion(avilable => avilable.Value, value => new Avilable(value));

        builder.Property(t => t.Sold)
            .HasConversion(sold => sold.Value, value => new Sold(value));

        builder.HasOne<Event>()
            .WithMany()
            .HasForeignKey(e => e.EventId);
    }

}
