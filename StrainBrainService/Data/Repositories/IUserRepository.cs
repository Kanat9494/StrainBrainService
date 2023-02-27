namespace StrainBrainService.Data.Repositories;

public interface IUserRepository
{
    Task<UserResponse> AuthenticateUser(string userName, string password);
}
