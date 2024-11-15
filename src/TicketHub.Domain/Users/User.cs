using TicketHub.Domain.Abstractions;
using TicketHub.Domain.Users.Events;

namespace TicketHub.Domain.Users;

public sealed class User : Entity<UserId>
{
    private readonly List<Role> _roles = [];

    private User(UserId id, FirstName firstName, LastName lastName, Email email, Bio bio, MobileNumber mobileNumber, ImageName imageName, IsEmailVerified isEmailVerified, IsMobileNumberVerified isMobileNumberVerified, IsTermsAndCondition isTermsAndCondition, IsSuspended isSuspended)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Bio = bio;
        MobileNumber = mobileNumber;
        ImageName = imageName;
        IsEmailVerified = isEmailVerified;
        IsMobileNumberVerified = isMobileNumberVerified;
        IsTermsAndCondition = isTermsAndCondition;
        IsSuspended = isSuspended;
    }

    private User()
    {
    }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }

    public Bio Bio { get; private set; }

    public MobileNumber MobileNumber { get; private set; }

    public ImageName ImageName { get; private set; }

    public IsEmailVerified IsEmailVerified { get; private set; }

    public IsMobileNumberVerified IsMobileNumberVerified { get; private set; }

    public IsTermsAndCondition IsTermsAndCondition { get; private set; }

    public IsSuspended IsSuspended { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public IReadOnlyCollection<Role> Roles => [.. _roles];

    public static User Create(FirstName firstName, LastName lastName, Email email, Bio bio, MobileNumber mobileNumber, ImageName imageName, IsEmailVerified isEmailVerified, IsMobileNumberVerified isMobileNumberVerified, IsTermsAndCondition isTermsAndCondition, IsSuspended isSuspended, Role role)
    {
        var user = new User(UserId.New(), firstName, lastName, email, bio, mobileNumber, imageName, isEmailVerified, isMobileNumberVerified, isTermsAndCondition, isSuspended);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        user._roles.Add(role);

        return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}
