namespace StrainBrainService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public QuestionController(IDataRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        private readonly IDataRepository<Question> _questionRepository;

        [HttpGet("GetQuestions")]
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _questionRepository.GetItemsAsync();
        }
    }
}
