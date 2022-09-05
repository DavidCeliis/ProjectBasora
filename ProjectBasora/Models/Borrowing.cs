using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectBasora.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        //public Book Book { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expire { get; set; }
        public bool Expired { get; set; }

        //public ICollection<ApplicationUser> BorrowingReaders { get; set; }
        //public ICollection<ApplicationUser> BorrowingRenters { get; set; }

    }
}
