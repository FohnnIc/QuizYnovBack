using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizYnovRendu.Models
{
    public class QuestionModel
    {
        [Key]
        public int QuestionId { get; set; }
        public required string Text { get; set; }
        public required string Difficulty { get; set; }

        public required int CorrectAnswerId { get; set; }

        public int? QuizId { get; set; }
        public QuizModel? Quiz { get; set; }

        public ICollection<AnswerModel>? Answers { get; set; }

    }
}
