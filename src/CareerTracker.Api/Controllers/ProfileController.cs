using System.Security.Claims;
using CareerTracker.Application.Profiles.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;
    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId))
        {
            return Unauthorized();
        }
        var profile = await _profileService.GetProfileAsync(userId, CancellationToken.None);
        return Ok(profile);
    }

    [HttpPut]
    public async Task<IActionResult> UpsertProfile(ProfileDto profileDto)
    {
        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId))
        {
            return Unauthorized();
        }
        await _profileService.UpsertProfileAsync(userId, profileDto, CancellationToken.None);
        return NoContent();
    }
}