using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="First Name is required...")]
        [MinLength(2, ErrorMessage="First Name is too short...")]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Last Name is required...")]
        [MinLength(2, ErrorMessage="Last Name is too short...")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}

        [Required(ErrorMessage="Email is required...")]
        [EmailAddress]
        public string Email {get;set;}

        [Required(ErrorMessage="Password is required...")]
        [MinLength(4, ErrorMessage="Password is too short...")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password does not Match...")]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Relationship
        // One User : Many Plans
        public List<Wedding> Weddings {get;set;}

        // Many User : Many Attend
        public List<Event> Attend {get;set;}
    }
}