using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class ApplicationUser : IdentityUser
    {
     
        //public int ReviewerIdBookCon { get; set; }
        //[ForeignKey("ReviewerIdBookCon")]
        //public UserReview_bookCondition userReview_BookCondition { get; set; }

        //public int RenterIdBookCon { get; set; }
        //[ForeignKey("RenterIdBookCon")]
        //public UserReview_bookCondition userRenter_BookCondition { get; set; }

        //public int? BorrowingReaderId { get; set; } 
        //[ForeignKey("BorrowingReaderId")]
        //public Borrowing? BorrowingReader { get; set; } = null;

        //public int? BorrowingRenterId { get; set; }
        //[ForeignKey("BorrowingRenterId")]
        //public Borrowing? BorrowingRenter { get; set; } = null;
        
        [Display(Name = "username")]
        public string UserNick { get; set; }
       
        public string UserSurname { get; set; }
        
        public string UserLastname { get; set; }
       
        
        public string Street { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
       
        public int PostCode { get; set; }
      
        public bool Vertification { get; set; } = false;
        public string UserType { get; set; } 
        public string IDtype { get; set; }
        public int IDnumber { get; set; }
        public int Limit { get; set; }  
        //public ICollection<UserReview_user> UserReview_user { get; set; }
        //public ICollection<Borrowing>? Borrowings { get; set; } = null;
    }
}
