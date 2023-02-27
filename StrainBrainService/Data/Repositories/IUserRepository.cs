namespace StrainBrainService.Data.Repositories;

public class IUserRepository
{
    Task<UserResponse> AuthenticateUser(string userName, string password);
}
