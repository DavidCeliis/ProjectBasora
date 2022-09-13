using System.ComponentModel.DataAnnotations;

namespace ProjectBasora.Models
{
    public class Searching
    {
        [Key]
        public int SearchId { get; set; }
        public string Result { get; set; }
        public bool? Find { get; set; }

    }
}
