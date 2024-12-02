using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketHub.Domain.Users;

namespace TicketHub.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(id => id.Value, value => new UserId(value));

        builder.Property(u => u.FirstName)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(u => u.LastName)
            .HasConversion(firstName => firstName.Value, value => new LastName(value));

        builder.Property(u => u.Email)
            .HasConversion(email => email.Value, value => new Email(value));

        builder.Property(u => u.Bio)
            .HasConversion(bio => bio.Value, value => new Bio(value));

        builder.Property(u => u.MobileNumber)
            .HasConversion(mobileNumber => mobileNumber.Value, value => new MobileNumber(value));

        builder.Property(u => u.ImageUrl)
            .HasConversion(imageUrl => imageUrl.Value, value => new ImageUrl(value));

        builder.Property(u => u.IsEmailVerified)
            .HasConversion(isEmailVerified => isEmailVerified.Value, value => new IsEmailVerified(value));

        builder.Property(u => u.IsMobileNumberVerified)
            .HasConversion(isMobileNumberVerified => isMobileNumberVerified.Value, value => new IsMobileNumberVerified(value));

        builder.Property(u => u.IsTermsAndCondition)
            .HasConversion(isTermAndCondition => isTermAndCondition.Value, value => new IsTermsAndCondition(value));

        builder.Property(u => u.IsSuspended)
            .HasConversion(isSuspended => isSuspended.Value, value => new IsSuspended(value));
        
        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasIndex(u => u.MobileNumber).IsUnique();

        builder.HasIndex(u => u.IdentityId).IsUnique();
    }
}
