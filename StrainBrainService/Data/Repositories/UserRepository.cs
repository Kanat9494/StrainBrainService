namespace StrainBrainService.Data.Repositories;

public class UserRepository : IUserRepository<AuthenticationRequest>
{
    public UserRepository(StrainBrainContext context)
    {
        _context = context;
    }

    private readonly StrainBrainContext _context;

    public async Task<UserResponse?> AuthenticateUser(AuthenticationRequest request)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user == null)
                return null;

            var token = GenerateJwtToken(user);

            var authenticatedUser = new UserResponse();
            authenticatedUser.UserName = user.UserName;
            authenticatedUser.AccessToken = token;
            authenticatedUser.UserBalance = user.UserBalance;
            authenticatedUser.UserScore = user.UserScore;

            return authenticatedUser;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    private string GenerateJwtToken(User user)
    {
        var securityKey = AuthOptions.GetSymmetricSecurityKey();
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            new Claim("UserBalance", user.UserBalance?.ToString() ?? ""),
            new Claim("UserId", user.UserId.ToString()),
            new Claim("UserScore", user.UserScore?.ToString() ?? "")
        };

        var token = new JwtSecurityToken(AuthOptions.ISSUER, AuthOptions.AUDIENCE, claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
