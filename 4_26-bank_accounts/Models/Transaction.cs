using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Accounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransId {get;set;}

        [Required]
        public decimal Amount {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        //Relationships
        //User and Transaction
        public int UserId {get;set;}
        public User Owner {get;set;}
    }
}