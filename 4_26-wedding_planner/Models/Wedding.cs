using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required(ErrorMessage="Who is getting Married?...")]
        [MinLength(2, ErrorMessage="Name can't be that short...")]
        [Display(Name="Wedder One")]
        public string WedderOne {get;set;}

        [Required(ErrorMessage="Who is getting Married?...")]
        [MinLength(2, ErrorMessage="Name can't be that short...")]
        [Display(Name="Wedder Two")]
        public string WedderTwo {get;set;}

        [Required(ErrorMessage="Date must be provided")]
        [BirthDay]
        [DataType(DataType.Date)]
        public DateTime? Date {get;set;}

        [Required(ErrorMessage="Address must be provided")]
        public string Address {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Relationship
        // One User with Wedding
        public int UserId {get;set;}
        public User Planner {get;set;}

        // Many User : Many Wedding
        public List<Event> Assign {get;set;}
    }
}