using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/events/{eventId}/registrations")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;
    private readonly IEventService _eventService;
    private readonly IUserService _userService;

    public RegistrationsController(
        IRegistrationService registrationService, 
        IEventService eventService, 
        IUserService userService)
    {
        _registrationService = registrationService;
        _eventService = eventService;
        _userService = userService;
    }

    [HttpPost]
    public ActionResult<Registration> Create(Guid eventId, [FromBody] Registration input)
    {
        if (input.UserId == Guid.Empty)
        {
            return BadRequest("UserId is required.");
        }

        var ev = _eventService.GetEventById(eventId);
        if (ev is null)
        {
            return NotFound("Event not found.");
        }

        var user = _userService.GetUserById(input.UserId);
        if (user is null)
        {
            return NotFound("User not found.");
        }
        
        var created = _registrationService.RegisterUser(eventId, input.UserId);
        return StatusCode(201, created);
    }
}
