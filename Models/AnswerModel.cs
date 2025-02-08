using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizYnovRendu.Models
{
    public class AnswerModel
    {
        [Key]
        public int AnswerId { get; set; }
        public required string Content { get; set; }

        public int? QuestionId { get; set; }
        public QuestionModel? Question { get; set; }
    }
}
