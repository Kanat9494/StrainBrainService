namespace StrainBrainService.Controllers;

//[Authorize]
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

    [HttpPost("GetImage")]
    public async Task<IActionResult> UploadImage([FromBody] TestModel testModel)
    {
        try
        {
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var filePath = Path.Combine("C:\\Users\\kkudaibergenov\\Desktop\\projects\\drafts", fileName);

            await System.IO.File.WriteAllBytesAsync(filePath, testModel.ImageData);

            return Ok(new {message = "Фотография успешно загружена!"});
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
