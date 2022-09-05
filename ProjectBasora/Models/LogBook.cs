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
        public ApplicationUser User { get; set; }
        [Key]
        public string UserId { get; set; }
    }
}
