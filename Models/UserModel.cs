using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizYnovRendu.Models
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; } 
        public string? PasswordHash { get; set; }
        public ICollection<QuizModel>? Quizzes { get; set; }
    }
}
