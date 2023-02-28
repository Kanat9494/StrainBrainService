namespace StrainBrainService.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    public AuthenticationController(IUserRepository<AuthenticationRequest> userRepository)
    {
        _userRepository = userRepository;
    }

    private readonly IUserRepository<AuthenticationRequest> _userRepository;

    [AllowAnonymous]
    [HttpPost("AuthenticateUser")]
    public async Task<UserResponse?> AuthenticateUser([FromBody] AuthenticationRequest request)
    {
        return await _userRepository.AuthenticateUser(request);
    }

    [HttpGet("TestRequest")]
    public async Task<IActionResult> TestRequest()
    {
        return Ok("It is cool");
    }
}
