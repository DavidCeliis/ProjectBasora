using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_userRelation
    {
        public int URURid { get; set; }
        public string RatedId { get; set; }
        [ForeignKey("RatedId")]
        public ApplicationUser Rated { get; set; }
        [Key]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [ForeignKey("UserReview_userId")]
        public UserReview_user UserReview_user { get; set; }
        [Key]
        public int UserReview_userId { get; set; }
    }
}
