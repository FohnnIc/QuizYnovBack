using static QuizYnovRendu.Dtos.QuestionDto;

namespace QuizYnovRendu.Dtos
{
    public class AnswerDto
    {
        public class AnswerReadDto
        {
            public int AnswerId { get; set; }
            public string Content { get; set; }
            public QuestionReadDto Question { get; set; }
        }

        public class AnswerCreateDto
        {
            public string Content { get; set; }
            public int QuestionId { get; set; }
        }

        public class AnswerUpdateDto
        {
            public string Content { get; set; }
        }

    }
}
