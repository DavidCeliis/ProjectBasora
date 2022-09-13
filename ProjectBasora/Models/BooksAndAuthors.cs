using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class BooksAndAuthors
    {
        [Key]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Key]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public string? UserId { get; set; }
    }
}
