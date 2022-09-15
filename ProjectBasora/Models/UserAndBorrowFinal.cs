using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserAndBorrowFinal
    {
        [Key]
        public int UserAndBorrowFinalId { get; set; }
        [Key]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [Key]
        public string RenterId { get; set; }
        [ForeignKey("RenterId")]
        public ApplicationUser Renter { get; set; }
        [Key]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        //[ForeignKey("BorrowingId")]
        //public Borrowing? Borrowing { get; set; }
        //[Key]
        //public int? BorrowingId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expire { get; set; }
        public bool Expired { get; set; }
        public bool Return { get; set; }
    }
}
