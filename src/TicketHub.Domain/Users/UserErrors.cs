using TicketHub.Domain.Abstractions;

namespace TicketHub.Domain.Users;


public static class UserErrors
{
    public static readonly Error NotFound = new(
        "User.NotFound",
        "The user with the specified identifier was not found");

    public static readonly Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "The provided credentials were invalid");

    public static readonly Error EmailConflict = new(
        "User.EmailConflict",
        "The user with provided email already exists");

    public static readonly Error MobileNumberConflict = new(
        "User.MobileNumberConflict",
        "The user with provided mobile number already exists");

    public static readonly Error KeycloakServerError = new(
        "User.KeycloakServerError",
        "Keycloak server error occured while creating user");
}
