using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models.Domains
{
    public class Books
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl  { get; set; }

        public decimal Price { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Authors Authors { get; set; }
    }
}
