using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectBasora.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expire { get; set; }
        public bool Expired { get; set; }
        public ICollection<UserAndBorrow> UserAndBorrow { get; set; }

        //public ApplicationUser BorrowingRenter { get; set; }
        //public int BorrowingRenterId { get; set; }

        //public ApplicationUser BorrowingReader { get; set; }
        //public int BorrowingReaderId { get; set; }



    }
}
