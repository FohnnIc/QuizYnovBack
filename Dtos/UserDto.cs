namespace QuizYnovRendu.Dtos
{
    public class UserDto
    {
        public class UserReadDto
        {
            public int UserId { get; set; }
            public string? Name { get; set; }
        }

        public class UserCreateDto
        {
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? Role { get; set; }
            public string? PasswordHash { get; set; }
        }

        public class UserUpdateDto
        {
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? Role { get; set; }
        }
    }
}
