using Microsoft.AspNetCore.Mvc;
using QuizYnovRendu.Repositories;
using static QuizYnovRendu.Dto.QuizDto;
using static QuizYnovRendu.Dtos.AnswerDto;

namespace QuizYnovRendu.Controllers
{
    [Route("api/answers")]
    [ApiController]
    public class AnswerController(IAnswerRepository<Dtos.AnswerDto.AnswerReadDto, Dtos.AnswerDto.AnswerCreateDto, Dtos.AnswerDto.AnswerUpdateDto> service) : ControllerBase
    {
        private readonly IAnswerRepository<AnswerReadDto, AnswerCreateDto, AnswerUpdateDto> _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerReadDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerReadDto>> GetById(int id)
        {
            var answer = await _service.GetByIdAsync(id);
            return answer == null ? NotFound() : Ok(answer);
        }

        [HttpPost]
        public async Task<ActionResult<AnswerReadDto>> Create(AnswerCreateDto dto)
        {
            var answer = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = answer.AnswerId }, answer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AnswerUpdateDto dto)
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
