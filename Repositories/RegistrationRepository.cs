using EventManagement.Api.Data;
using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories;

public class RegistrationRepository : IRegistrationRepository
{
    private readonly ApplicationDbContext _context;

    public RegistrationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Registration Add(Registration registration)
    {
        _context.Registrations.Add(registration);
        _context.SaveChanges();
        return registration;
    }
}
