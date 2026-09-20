using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models.DTO
{
    public class UpdateAuthorDTO
    {
        [Required(ErrorMessage = "Author Name Is Required....")]
        public string Name { get; set; } = string.Empty;
    }
}
