using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserAndBorrow
    { 
        public int UBId { get; set; }
        
        public int UserAndBorrowId { get; set; }
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
        [ForeignKey("BorrowingId")]
        public Borrowing Borrowing { get; set; }
        [Key]
        public int BorrowingId { get; set; }
    }
}
