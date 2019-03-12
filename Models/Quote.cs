using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models {
    public class QuoteModel {

        [Required(ErrorMessage = "Your name is required.")]
        [MinLength(2, ErrorMessage = "Your name must be at least 2 characters.")]
        [Display(Name = "Your Name:")] 
        public string Name {get;set;}

        [Required(ErrorMessage = "A quote is required.")]
        [MinLength(20, ErrorMessage = "A quote must be at least 20 characters.")]
        [Display(Name = "A Quote:")] 
        public string QuoteBody {get;set;}
    }
}