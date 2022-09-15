using System.ComponentModel.DataAnnotations;

namespace ProjectBasora.Models
{
    public class Searching
    {
        [Key]
        public int SearchId { get; set; }
#pragma warning disable CS8618 // Proměnná vlastnost Result, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public string Result { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost Result, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public bool? Find { get; set; }

    }
}
