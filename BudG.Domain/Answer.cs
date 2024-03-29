using BudG.Domain.CustomAttribute;
using System.ComponentModel.DataAnnotations;

namespace BudG.Domain
{
    public class Answer
    {

        [Required]
        [Key]
        public int AnswerId { get; set; }

        
        [Required(ErrorMessage = "Please answer of the question.")]
        [StringLength(50)]
        [ExcludeChar("/.,!@#$%?&*()^-_+=", ErrorMessage = "The answer contains invalid letters.")]
        public string AnswerQuestion { get; set; }
        public int QuesId { get; set; }
        public Question Question { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
