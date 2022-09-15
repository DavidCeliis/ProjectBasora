using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectBasora.Models
{
    public class Thumbnail
    {

        [ForeignKey("BookId")]
#pragma warning disable CS8618 // Proměnná vlastnost Book, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public Book Book { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost Book, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        [Key]
        public int BookId { get; set; }
        [Key]
        public ThumbnailType Type { get; set; }
#pragma warning disable CS8618 // Proměnná vlastnost Blob, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public byte[] Blob { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost Blob, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
    }
    public enum ThumbnailType
    {
        Square,
        SameAspectRatio,
    }
}

