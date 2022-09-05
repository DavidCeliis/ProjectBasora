using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_bookConditionRelation
    {
        public int URBCRId { get; set; }

        [Key]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [Key]
        public string RatedId { get; set; }
        [ForeignKey("RatedId")]
        public ApplicationUser Rated { get; set; }
        [Key]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [ForeignKey("UserReview_bookConditionId")]
        public UserReview_bookCondition UserReview_bookCondition { get; set; }
        [Key]
        public int UserReview_bookConditionId { get; set; }

    }
}
