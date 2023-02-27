namespace StrainBrainService.Data.Repositories;

public interface IUserRepository<TRequest>
{
    Task<string?> AuthenticateUser(TRequest request);
}
