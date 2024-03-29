using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudG.Domain
{
    public  class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }
        [Required]
        [Key]
        public int QuesId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(100)]
        public string QuestionShape { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

    }
}
