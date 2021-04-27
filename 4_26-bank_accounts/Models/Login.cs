using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Accounts.Models
{
    [NotMapped]
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string LoginEmail {get;set;}

        [Required]
        [MinLength(4, ErrorMessage="Password is too short...")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string LoginPassword {get;set;}
    }
}