using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class BooksAndLanguages
    {
        [Key]
        public int LanguageId { get; set; }
        public Languages Languages { get; set; }
        [Key]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
