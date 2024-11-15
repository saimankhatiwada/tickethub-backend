using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketHub.Domain.Users;

namespace TicketHub.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasConversion(id => id.Value, value => new UserId(value));

        builder.Property(user => user.FirstName)
            .HasMaxLength(100)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(user => user.LastName)
            .HasMaxLength(100)
            .HasConversion(firstName => firstName.Value, value => new LastName(value));

        builder.Property(user => user.Email)
            .HasMaxLength(100)
            .HasConversion(email => email.Value, value => new Email(value));

        builder.Property(user => user.Bio)
            .HasConversion(bio => bio.Value, value => new Bio(value));

        builder.Property(user => user.MobileNumber)
            .HasMaxLength(100)
            .HasConversion(mobileNumber => mobileNumber.Value, value => new MobileNumber(value));

        builder.Property(user => user.ImageName)
            .HasMaxLength(100)
            .HasConversion(imageName => imageName.Value, value => new ImageName(value));

        builder.Property(user => user.IsEmailVerified)
            .HasConversion(isEmailVerified => isEmailVerified.Value, value => new IsEmailVerified(value));

        builder.Property(user => user.IsMobileNumberVerified)
            .HasConversion(isMobileNumberVerified => isMobileNumberVerified.Value, value => new IsMobileNumberVerified(value));

        builder.Property(user => user.IsTermsAndCondition)
            .HasConversion(isTermAndCondition => isTermAndCondition.Value, value => new IsTermsAndCondition(value));

        builder.Property(user => user.IsSuspended)
            .HasConversion(isSuspended => isSuspended.Value, value => new IsSuspended(value));
        
        builder.HasIndex(user => user.Email).IsUnique();

        builder.HasIndex(user => user.MobileNumber).IsUnique();

        builder.HasIndex(user => user.IdentityId).IsUnique();
    }
}
