using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizYnov.Data;
using QuizYnovRendu.Dto;
using QuizYnovRendu.Interfaces;
using QuizYnovRendu.Models;
using static QuizYnovRendu.Dto.QuizDto;

namespace QuizYnovRendu.Controllers
{
    [Route("api/quizzes")]
    [ApiController]
    public class QuizController(IQuizRepository<QuizDto.QuizReadDto, QuizDto.QuizCreateDto, QuizDto.QuizUpdateDto> service) : ControllerBase
    {
        private readonly IQuizRepository<QuizReadDto, QuizCreateDto, QuizUpdateDto> _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizReadDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizReadDto>> GetById(int id)
        {
            var quiz = await _service.GetByIdAsync(id);
            return quiz == null ? NotFound() : Ok(quiz);
        }

        [HttpPost]
        public async Task<ActionResult<QuizReadDto>> Create(QuizCreateDto dto)
        {
            var quiz = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = quiz.QuizId }, quiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QuizUpdateDto dto)
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