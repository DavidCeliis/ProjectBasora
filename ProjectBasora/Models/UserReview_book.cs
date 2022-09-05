using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_book
    {
        [Key]
        public int RBookId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Created { get; set; }
        public ICollection<UserReview_bookRelation>? UserReview_bookRelation { get; set; }
 
    }
}
