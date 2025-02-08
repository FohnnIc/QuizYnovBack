using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizYnov.Data;
using QuizYnovRendu.Models;
using QuizYnovRendu.Repositories;
using static QuizYnovRendu.Dtos.UserDto;

namespace QuizYnovRendu.Services
{
    public class UserService(DatabaseContext context, IMapper mapper) : IUserRepository<UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly DatabaseContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? null : _mapper.Map<UserReadDto>(user);
        }

        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<UserModel>(dto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _mapper.Map(dto, user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

      
    }
}
