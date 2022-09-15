using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class LogBook
    {
        public int LogId { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime LogOutDate { get; set; }

        [ForeignKey("UserId")]
#pragma warning disable CS8618 // Proměnná vlastnost User, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public ApplicationUser User { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost User, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        [Key]
#pragma warning disable CS8618 // Proměnná vlastnost UserId, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public string UserId { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost UserId, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
    }
}
