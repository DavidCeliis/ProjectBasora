using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class Categories
    {
        [Key]    
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public Book Book { get; set; }
        public ICollection<BooksAndCategories> BooksAndCategories { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("Book")]
        public Book? BookInclude { get; set; }
    }
}
