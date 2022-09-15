using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBasora.Models
{
    public class UserReview_userRelation
    {
        public int URURid { get; set; }
#pragma warning disable CS8618 // Proměnná vlastnost RatedId, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public string RatedId { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost RatedId, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        [ForeignKey("RatedId")]
#pragma warning disable CS8618 // Proměnná vlastnost Rated, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public ApplicationUser Rated { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost Rated, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        [Key]
#pragma warning disable CS8618 // Proměnná vlastnost UserId, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public string UserId { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost UserId, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        [ForeignKey("UserId")]
#pragma warning disable CS8618 // Proměnná vlastnost User, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public ApplicationUser User { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost User, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        [ForeignKey("UserReview_userId")]
#pragma warning disable CS8618 // Proměnná vlastnost UserReview_user, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public UserReview_user UserReview_user { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost UserReview_user, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        [Key]
        public int UserReview_userId { get; set; }
    }
}
