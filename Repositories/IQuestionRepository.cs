using QuizYnovRendu.Models;

namespace QuizYnovRendu.Repositories
{
    public interface IQuestionRepository <QuestionReadDto, QuestionCreateDto, QuestionUpdateDto>
    {
        Task<IEnumerable<QuestionReadDto>> GetAllAsync();
        Task<QuestionReadDto> GetByIdAsync(int id);
        Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto);
        Task<bool> UpdateAsync(int id, QuestionUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
