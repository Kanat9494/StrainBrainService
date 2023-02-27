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

            UserResponse userResponse = new UserResponse();
            userResponse.UserId = user.UserId;
            userResponse.UserName = user.UserName;
            userResponse.UserBalance = user.UserBalance;
            userResponse.UserScore = user.UserScore;

            return userResponse;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
