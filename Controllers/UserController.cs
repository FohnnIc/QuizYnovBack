using Microsoft.AspNetCore.Mvc;
using QuizYnovRendu.Repositories;
using static QuizYnovRendu.Dtos.UserDto;

namespace QuizYnovRendu.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IUserRepository<Dtos.UserDto.UserReadDto, Dtos.UserDto.UserCreateDto, Dtos.UserDto.UserUpdateDto> service) : ControllerBase
    {
        private readonly IUserRepository<UserReadDto, UserCreateDto, UserUpdateDto> _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Create(UserCreateDto dto)
        {
            var user = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDto dto)
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
