using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class Event
    {
        [Key]
        public int EventId {get;set;}

        public int UserId {get;set;}
        public User User {get;set;}

        public int WeddingId {get;set;}
        public Wedding Wedding {get;set;}
    }
}