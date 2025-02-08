using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizYnov.Data;
using QuizYnovRendu.Models;
using QuizYnovRendu.Repositories;
using static QuizYnovRendu.Dtos.AnswerDto;

namespace QuizYnovRendu.Services
{
    public class AnswerService(DatabaseContext context, IMapper mapper) : IAnswerRepository<AnswerReadDto, AnswerCreateDto, AnswerUpdateDto>
    {
        private readonly DatabaseContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<AnswerReadDto>> GetAllAsync()
        {
            var answers = await _context.Answers.Include(q => q.Question).ToListAsync();
            return _mapper.Map<IEnumerable<AnswerReadDto>>(answers);
        }

        public async Task<AnswerReadDto> GetByIdAsync(int id)
        {
            var answer = await _context.Answers.Include(q => q.Question).FirstOrDefaultAsync(q => q.AnswerId == id);
            return answer == null ? null : _mapper.Map<AnswerReadDto>(answer);
        }

        public async Task<AnswerReadDto> CreateAsync(AnswerCreateDto dto)
        {
            var answer = _mapper.Map<AnswerModel>(dto);
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return _mapper.Map<AnswerReadDto>(answer);
        }

        public async Task<bool> UpdateAsync(int id, AnswerUpdateDto dto)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return false;

            _mapper.Map(dto, answer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return false;

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

