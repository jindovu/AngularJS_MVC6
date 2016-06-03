using System.ComponentModel.DataAnnotations;

namespace MyQuoteApp.models
{
    public class Quote
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Content must be required.!")]
        [MinLength(2, ErrorMessage ="Min length must be required 2 characters")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Author must be required.!")]
        public string Author { get; set; }
    }
}
