namespace StrainBrainService.Data.Repositories;

public interface IUserRepository<TRequest>
{
    Task<UserResponse?> AuthenticateUser(TRequest request);
}
