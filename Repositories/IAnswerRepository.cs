namespace QuizYnovRendu.Repositories
{
    public interface IAnswerRepository<AnswerReadDto, AnswerCreateDto, AnswerUpdateDto>
    {
        Task<IEnumerable<AnswerReadDto>> GetAllAsync();
        Task<AnswerReadDto> GetByIdAsync(int id);
        Task<AnswerReadDto> CreateAsync(AnswerCreateDto dto);
        Task<bool> UpdateAsync(int id, AnswerUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
