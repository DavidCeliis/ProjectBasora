using System.ComponentModel.DataAnnotations;

namespace ProjectBasora.Models
{
    public class Searching
    {
        [Key]
        public int SearchId { get; set; }
        public string FailedS { get; set; }
        public string SuccesedS { get; set; }
    }
}
