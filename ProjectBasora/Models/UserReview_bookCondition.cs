using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_bookCondition
    {
        [Key]
        public int RConditionId { get; set; }
       
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Created { get; set; }
        public ICollection<UserReview_bookConditionRelation>? UserReview_bookConditionRelation { get; set; }
      
    }
}
