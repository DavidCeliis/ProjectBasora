using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_book
    {
        [Key]
        public int RBookId { get; set; }
        //public Book Book { get; set; }
      
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        //public string UserId { get; set; }
    }
}
