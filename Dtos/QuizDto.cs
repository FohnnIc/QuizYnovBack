using QuizYnovRendu.Enums;
using QuizYnovRendu.Models;
using static QuizYnovRendu.Dtos.UserDto;

namespace QuizYnovRendu.Dto
{
    public class QuizDto
    {
        public class QuizReadDto
        {
            public int QuizId { get; set; }
            public string Text { get; set; }
            public string Difficulty { get; set; }
            public UserReadDto User { get; set; }
        }

        public class QuizCreateDto
        {

            public string Text { get; set; }

            public int UserId { get; set; }
            public string Difficulty { get; set; }

        }

        public class QuizUpdateDto
        {
            public string Title { get; set; }
            public string Difficulty { get; set; }

        }

    }
}
