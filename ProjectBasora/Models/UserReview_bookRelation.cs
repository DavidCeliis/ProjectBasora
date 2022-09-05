using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_bookRelation
    {
        public int URBRId { get; set; }

        
        [Key]
        public int BookISBN { get; set; }
        [ForeignKey("BookISBN")]
        public Book Book { get; set; }
        [Key]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [ForeignKey("UserReview_bookId")]
        public UserReview_book UserReview_book { get; set; }
        [Key]
        public int UserReview_bookId { get; set; }

    }
}
