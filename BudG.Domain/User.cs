using System;
using System.ComponentModel.DataAnnotations;
using BudG.Domain.CustomAttribute;

namespace BudG.Domain
{
    public class User
    {
        [Required]
        [Key]
        public int UserId { get; set; }

      
        [StringLength(50)]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50)]
        [ExcludeChar("/.,!@#$%?&*()^-_+=", ErrorMessage = "The first name contains invalid letters.")]
        [RegularExpression("[^0-9]+", ErrorMessage = "Your first name must be only Alphabet.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(50)]
        [ExcludeChar("/.,!@#$%?&*()^-_+=", ErrorMessage = "The Last name contains invalid letters.")]
        [RegularExpression("[^0-9]+", ErrorMessage = "Your Last name must be only Alphabet.")]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Please Entar valid email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your UserName")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(100)]
        public string Password { get; set; }

        public byte[] ProfilePicture { get; set; }

        public Answer Answer { get; set; }



    }
}
