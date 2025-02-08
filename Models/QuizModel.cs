using QuizYnovRendu.Dto;
using QuizYnovRendu.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizYnovRendu.Models
{
    public class QuizModel 
    {
        [Key]
        public int QuizId { get; set; }

        public required string Text { get; set; } 

        public string? Difficulty { get; set; }

        public int UserId { get; set; }
        public UserModel? User { get; set; }

        public ICollection<QuestionModel>? Questions { get; set; }

    }
}
