namespace ProjectBasora.Models
{
    public class Country
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Proměnná vlastnost Name, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
        public string Name { get; set; }
#pragma warning restore CS8618 // Proměnná vlastnost Name, která nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat vlastnost jako proměnnou s možnou hodnotou null.
    }
}
