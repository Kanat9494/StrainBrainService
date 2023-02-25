namespace StrainBrainService.Data.Repositories;

public interface IDataRepository<TResponse>
{
    Task<IEnumerable<TResponse>> GetItemsAsync(int questionsCountToSkip);
}
