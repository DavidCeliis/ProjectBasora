using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_user
    {
       [Key]
        public int RUserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser RatedUser { get; set; }
        //public string RatedUserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser Reviewer { get; set; }
        //public string ReviewerId { get; set; }
    }
}
