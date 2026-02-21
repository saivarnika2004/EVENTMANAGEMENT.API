using EventManagement.Api.Models;
using EventManagement.Api.Repositories;

namespace EventManagement.Api.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IRegistrationRepository _registrationRepository;

    public RegistrationService(IRegistrationRepository registrationRepository)
    {
        _registrationRepository = registrationRepository;
    }

    public Registration RegisterUser(Guid eventId, Guid userId)
    {
        var registration = new Registration
        {
            Id = Guid.NewGuid(),
            EventId = eventId,
            UserId = userId,
            RegisteredAt = DateTime.UtcNow,
            Status = "Registered"
        };

        return _registrationRepository.Add(registration);
    }
}
