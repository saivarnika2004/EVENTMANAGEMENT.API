using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories;

public interface IRegistrationRepository
{
    Registration Add(Registration registration);
}
