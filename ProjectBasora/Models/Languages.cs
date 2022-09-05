using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class Languages
    {
        [Key]
        public int LanguageId {get;set;}
        public string LanguageName {get;set;}
        //public Book Book {get;set;}
        public ICollection<BooksAndLanguages> BooksAndLanguages {get;set;}

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public string? UserId { get; set; }
    }
}
