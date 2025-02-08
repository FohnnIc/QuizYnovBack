using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizYnov.Data;
using QuizYnovRendu.Models;
using QuizYnovRendu.Repositories;
using static QuizYnovRendu.Dtos.QuestionDto;

namespace QuizYnovRendu.Services
{
    public class QuestionService(DatabaseContext context, IMapper mapper) : IQuestionRepository<QuestionReadDto, QuestionCreateDto, QuestionUpdateDto>
    {
        private readonly DatabaseContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<QuestionReadDto>> GetAllAsync()
        {
            var questions = await _context.Questions.Include(q => q.Quiz).ToListAsync();
            return _mapper.Map<IEnumerable<QuestionReadDto>>(questions);
        }

        public async Task<QuestionReadDto> GetByIdAsync(int id)
        {
            var question = await _context.Questions.Include(q => q.Quiz).FirstOrDefaultAsync(q => q.QuizId == id);
            return question == null ? null : _mapper.Map<QuestionReadDto>(question);
        }

        public async Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto)
        {
            var question = _mapper.Map<QuestionModel>(dto);
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return _mapper.Map<QuestionReadDto>(question);
        }

        public async Task<bool> UpdateAsync(int id, QuestionUpdateDto dto)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return false;

            _mapper.Map(dto, question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
