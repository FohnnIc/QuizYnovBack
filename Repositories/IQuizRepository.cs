using Microsoft.AspNetCore.Mvc;
using QuizYnov.Data;
using QuizYnovRendu.Models;

namespace QuizYnovRendu.Interfaces
{
    public interface IQuizRepository <QuizReadDto, QuizCreateDto, QuizUpdateDto>
    {
        Task<IEnumerable<QuizReadDto>> GetAllAsync();
        Task<QuizReadDto> GetByIdAsync(int id);
        Task<QuizReadDto> CreateAsync(QuizCreateDto dto);
        Task<bool> UpdateAsync(int id, QuizUpdateDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
