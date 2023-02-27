namespace StrainBrainService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    public AuthenticationController(IUserRepository<AuthenticationRequest> userRepository)
    {
        _userRepository = userRepository;
    }

    private readonly IUserRepository<AuthenticationRequest> _userRepository;

    [HttpPost("AuthenticateUser")]
    public async Task<UserResponse?> AuthenticateUser([FromBody] AuthenticationRequest request)
    {
        return await _userRepository.AuthenticateUser(request);
    }
}
