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
        //public ICollection<Borrowing>? BorrowingReaders { get; set; } = null;

        //public int? BorrowingRenterId { get; set; }
        //[ForeignKey("BorrowingRenterId")]
        //public ICollection<Borrowing>? BorrowingRenters { get; set; } = null;
        public ICollection<UserAndBorrow>? UserAndBorrowRenters { get; set; }
        public ICollection<UserAndBorrow>? UserAndBorrowUsers { get; set; }

        public ICollection<UserAndBorrowFinal>? UserAndBorrowRentersFinal { get; set; }
        public ICollection<UserAndBorrowFinal>? UserAndBorrowUsersFinal { get; set; }
        public ICollection<UserReview_bookRelation>? UserReview_bookRelationUsers { get; set; }

        public ICollection<UserReview_bookConditionRelation>? UserReview_bookConditionRelationRateds { get; set; }
        public ICollection<UserReview_bookConditionRelation>? UserReview_bookConditionRelationUsers { get; set; }

        public ICollection<UserReview_userRelation>? UserReview_userRelationRateds { get; set; }
        public ICollection<UserReview_userRelation>? UserReview_userRelationUsers { get; set; }

        [Display(Name = "username")]
        public string UserNick { get; set; }
       
        public string UserSurname { get; set; }
        
        public string UserLastname { get; set; }
       
        
        public string Street { get; set; }

        
        public string City { get; set; }

        public string State { get; set; }
        //public enum State { 
        //    Spain,
        //    Germany,
        //    Poland,
        //    USA,
        //    UK,
        //    Norway
        
        //}

        public int PostCode { get; set; }
      
        public bool? Vertification { get; set; } = false;
        public string? UserType { get; set; } 
        public string? IDtype { get; set; }
        public int? IDnumber { get; set; }
        public int? Limit { get; set; }  
        public int? AmmountOfdelayed { get; set; }
        public int? AmmountOfInTime { get; set; }
        public int? AmmountOfActions { get; set; }
        //public List<Borrowing> Renters { get; set; }
        //public List<Borrowing> Users { get; set; }
        //public ICollection<UserReview_user> UserReview_user { get; set; }
        //public ICollection<Borrowing>? Borrowings { get; set; } = null;
    }
}
