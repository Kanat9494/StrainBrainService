namespace StrainBrainService.Data.Repositories;

public class QuestionRepository : IDataRepository<Question>
{
    public QuestionRepository(QuestionContext context)
    {
        _context = context;
    }

    private readonly QuestionContext _context;
    public async Task<IEnumerable<Question>> GetItemsAsync(int questionsCountToSkip)
    {
        return await _context.Questions.Skip(questionsCountToSkip).Take(100).ToListAsync();
    }
}
