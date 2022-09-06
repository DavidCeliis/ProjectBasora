using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string? ContentType { get; set; } //(MIME type)
        public int NumberPages { get; set; }
        public int? Weight { get; set; }
        public string? BookBinding { get; set; }
        public ICollection<Thumbnail>? Thumbnails { get; set; }
        
        //public ICollection<UserReview_book>? UserReview_book { get; set; }
        //public Author Author { get; set; }
      
        //public Categories Category { get; set; }
        
        //public Languages Language { get; set; }
        public ICollection<BooksAndAuthors>? BooksAndAuthors { get; set; }
        public ICollection<BooksAndCategories>? BooksAndCategories { get; set; }
        public ICollection<BooksAndLanguages>? BooksAndLanguages { get; set; }
        //public ICollection<Borrowing>? Borrowing { get; set; }

        public ICollection<UserAndBorrow>? UserAndBorrow { get; set; }
        public ICollection<UserReview_bookConditionRelation>? UserReview_bookConditionRelation { get; set; }
        public ICollection<UserReview_bookRelation>? UserReview_bookRelation { get; set; }
        public ICollection<UserReview_userRelation>? UserReview_userRelation { get; set; }
        [ForeignKey("Author")]
        public Author? AuthorIncludeBooks { get; set; }
        public bool Public { get; set; } = true;
        public bool Borrowed { get; set; } = false;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
