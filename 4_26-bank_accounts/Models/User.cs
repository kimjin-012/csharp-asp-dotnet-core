using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Accounts.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="First Name is too short...")]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Last Name is too short...")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
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

        // Relationships
        // 1 user to Transactions Account
        public List<Transaction> Transactions {get;set;} 
    }
}