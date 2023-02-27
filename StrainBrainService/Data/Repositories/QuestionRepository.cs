namespace StrainBrainService.Data.Repositories;

public class QuestionRepository : IDataRepository<Question>
{
    public QuestionRepository(StrainBrainContext context)
    {
        _context = context;
    }

    private readonly StrainBrainContext _context;
    public async Task<IEnumerable<Question>> GetItemsAsync(int questionsCountToSkip)
    {
        return await _context.Questions.Skip(questionsCountToSkip).Take(100).ToListAsync();
    }
}
