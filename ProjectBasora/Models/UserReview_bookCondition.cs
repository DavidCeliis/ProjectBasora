using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_bookCondition
    {
        [Key]
        public int RConditionId { get; set; }
        //public Book Book { get; set; }
       
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
       
        //public virtual ApplicationUser Renter { get; set; }
        ////public int RenterId { get; set; }
       
        //public virtual ApplicationUser Reviewer { get; set; }
        ////public int ReviewerId { get; set; }
    }
}
