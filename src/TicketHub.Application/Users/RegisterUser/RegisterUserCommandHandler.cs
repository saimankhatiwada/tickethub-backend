using TicketHub.Application.Abstractions.Authentication;
using TicketHub.Application.Abstractions.Messaging;
using TicketHub.Domain.Abstractions;
using TicketHub.Domain.Users;

namespace TicketHub.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IAuthenticationService authenticationService,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _authenticationService = authenticationService;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email),
            new Bio("N/A"),
            new MobileNumber(request.MobileNumber),
            new ImageUrl("default/default-image.png"),
            new IsEmailVerified(false),
            new IsMobileNumberVerified(false),
            new IsTermsAndCondition(request.IsTermsAndConditions),
            new IsSuspended(false),
            Role.FormRole(request.Role));

        if(await _userRepository.DoesMobileNumberExists(user.MobileNumber, cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.MobileNumberConflict);
        }

        Result<string> identityId = await _authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);

        if(identityId.IsFailure)
        {
            return Result.Failure<Guid>(identityId.Error);
        }

        user.SetIdentityId(identityId.Value);

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id.Value;
    }
}
