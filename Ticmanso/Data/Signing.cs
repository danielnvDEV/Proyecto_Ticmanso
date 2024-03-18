using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ticmanso.Data
{
    public class Signing
    {
        [Key]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan entry_time { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan departure_time { get; set; }

        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
    }

}
