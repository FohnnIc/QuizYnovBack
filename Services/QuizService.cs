using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizYnov.Data;
using QuizYnovRendu.Interfaces;
using QuizYnovRendu.Models;
using static QuizYnovRendu.Dto.QuizDto;

namespace QuizYnovRendu.Services
{
    public class QuizService(DatabaseContext context, IMapper mapper) : IQuizRepository<QuizReadDto, QuizCreateDto, QuizUpdateDto>
    {
        private readonly DatabaseContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<QuizReadDto>> GetAllAsync()
        {
            var quizzes = await _context.Quizzes.Include(q => q.User).ToListAsync();
            return _mapper.Map<IEnumerable<QuizReadDto>>(quizzes);
        }

        public async Task<QuizReadDto> GetByIdAsync(int id)
        {
            var quiz = await _context.Quizzes.Include(q => q.User).FirstOrDefaultAsync(q => q.QuizId == id);
            return quiz == null ? null : _mapper.Map<QuizReadDto>(quiz);
        }

        public async Task<QuizReadDto> CreateAsync(QuizCreateDto dto)
        {
            var quiz = _mapper.Map<QuizModel>(dto);
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return _mapper.Map<QuizReadDto>(quiz);
        }

        public async Task<bool> UpdateAsync(int id, QuizUpdateDto dto)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null) return false;

            _mapper.Map(dto, quiz);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null) return false;

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
