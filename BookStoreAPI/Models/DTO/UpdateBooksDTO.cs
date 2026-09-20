using BookStoreAPI.Models.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models.DTO
{
    public class UpdateBooksDTO
    {
        
      

        [Required(ErrorMessage = "Book Title is Required....")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book Description is Required....")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Book Image  is Required....")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Book Price is Required....")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Book Author Name  is Required....")]
        public int AuthorId { get; set; }

        
        
    }
}
