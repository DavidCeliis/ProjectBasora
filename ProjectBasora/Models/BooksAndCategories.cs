using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class BooksAndCategories
    {
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
