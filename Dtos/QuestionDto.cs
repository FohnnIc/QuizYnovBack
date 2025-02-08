using static QuizYnovRendu.Dto.QuizDto;

namespace QuizYnovRendu.Dtos
{
    public class QuestionDto
    {
        public class QuestionReadDto
        {
            public int QuestionId { get; set; }
            public string Content { get; set; }
            public QuizReadDto Quiz { get; set; }
        }

        public class QuestionCreateDto
        {
            public string Content { get; set; }
            public int QuizId { get; set; }
        }

        public class QuestionUpdateDto
        {
            public string Content { get; set; }
        }

    }
}
