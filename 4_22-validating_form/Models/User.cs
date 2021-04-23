using System;
using System.ComponentModel.DataAnnotations;

namespace Validating_Form.Models
{
    public class User
    {
        [Required(ErrorMessage ="First Name is required...")]
        [MinLength(2, ErrorMessage="Too short...")]
        [MaxLength(20, ErrorMessage="No one has a name that long...")]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Last Name is required...")]
        [MinLength(2, ErrorMessage="Too short...")]
        [MaxLength(20, ErrorMessage="No one has last name that long...")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}

        [Required(ErrorMessage="Your age?...")]
        [Range(18, 100, ErrorMessage="Really? thats your age...?")]
        public int Age {get;set;}
        
        [Required(ErrorMessage="Your email? we promise we wont reach you...")]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string Email {get;set;}
        
        [Required(ErrorMessage="You need a password")]
        [MinLength(2, ErrorMessage="Password too short...")]
        public string Password {get;set;}
    }
}