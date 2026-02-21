using EventManagement.Api.Models;

namespace EventManagement.Api.Services;

public interface IRegistrationService
{
    Registration RegisterUser(Guid eventId, Guid userId);
}
