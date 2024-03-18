using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ticmanso.Data
{
    public class Chat
    {
        [Key]
        public int id { get; set; }

        public string messages { get; set; }

        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public int user_id1 { get; set; }
        [ForeignKey("user_id1")]
        public User User1 { get; set; }
    }

}
