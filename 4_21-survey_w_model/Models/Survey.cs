using System;
using System.ComponentModel.DataAnnotations;

namespace survey_w_model.Models
{
    public class Survey
    {
        [Required(ErrorMessage="Name is Required...")]
        [MinLength(2, ErrorMessage="Name should be atleast 2 character...")]
        public string Name {get;set;}

        [Required(ErrorMessage="Location required...")]
        public string Location {get;set;}

        [Required(ErrorMessage="Language required...")]
        public string Language {get;set;}

        [MaxLength(20, ErrorMessage="Comment can't be no more than 20 character...")]
        public string Comment {get;set;}
    }
}