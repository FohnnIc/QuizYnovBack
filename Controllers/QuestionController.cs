using Microsoft.AspNetCore.Mvc;
using QuizYnovRendu.Repositories;
using static QuizYnovRendu.Dto.QuizDto;
using static QuizYnovRendu.Dtos.QuestionDto;

namespace QuizYnovRendu.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository<QuestionReadDto, QuestionCreateDto, QuestionUpdateDto> _service;

        public QuestionController(IQuestionRepository<QuestionReadDto, QuestionCreateDto, QuestionUpdateDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionReadDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionReadDto>> GetById(int id)
        {
            var question = await _service.GetByIdAsync(id);
            return question == null ? NotFound() : Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<QuestionReadDto>> Create(QuestionCreateDto dto)
        {
            var question = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = question.QuestionId }, question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QuestionUpdateDto dto)
        {
            return await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }

}
