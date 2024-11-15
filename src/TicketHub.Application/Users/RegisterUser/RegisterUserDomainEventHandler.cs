using MediatR;
using TicketHub.Application.Abstractions.Mail;
using TicketHub.Domain.Users;
using TicketHub.Domain.Users.Events;

namespace TicketHub.Application.Users.RegisterUser;

internal sealed class RegisterUserDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
{
    private readonly IUserRepository _userRepository;

    private readonly IMailService _mailService;

    public RegisterUserDomainEventHandler(IUserRepository userRepository, IMailService mailService)
    {
        _userRepository = userRepository;
        _mailService = mailService;
    }

    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(notification.UserId, cancellationToken);

        await _mailService.SendMailAsync(user!, MailMetaData.Create(user!.Email.Value, "Welcome to Ticket Hub"), MailTemplatePathProvider.GetTemplatePath(MailTemplateFolder.MailTemplates, MailTemplate.Welcome), cancellationToken);
    }
}
