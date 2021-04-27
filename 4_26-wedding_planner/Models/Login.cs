using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    [NotMapped]
    public class Login
    {
        [Required(ErrorMessage="Email must be provided...")]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string LoginEmail {get;set;}

        [Required]
        [MinLength(6, ErrorMessage="Password is too short...")]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string LoginPassword {get;set;}
    }
}