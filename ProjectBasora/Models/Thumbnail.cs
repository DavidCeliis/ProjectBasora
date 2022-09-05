using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectBasora.Models
{
    public class Thumbnail
    {

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [Key]
        public int BookId { get; set; }
        [Key]
        public ThumbnailType Type { get; set; }
        public byte[] Blob { get; set; }
    }
    public enum ThumbnailType
    {
        Square,
        SameAspectRatio,
    }
}

