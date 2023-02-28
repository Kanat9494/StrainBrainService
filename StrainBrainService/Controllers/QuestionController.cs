namespace StrainBrainService.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    public QuestionController(IDataRepository<Question> questionRepository)
    {
        _questionRepository = questionRepository;
    }

    private readonly IDataRepository<Question> _questionRepository;

    [HttpGet("GetQuestions/{questionsCountToSkip}")]
    public async Task<IEnumerable<Question>> GetQuestions(int questionsCountToSkip)
    {
        return await _questionRepository.GetItemsAsync(questionsCountToSkip);
    }
}
