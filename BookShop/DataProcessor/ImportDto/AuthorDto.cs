namespace BookShop.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using BookShop.Data.Models;

    public class AuthorDto
    {
        [Required]
        [StringLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public AuthorBooksDto[] Books { get; set; }
    }
}
