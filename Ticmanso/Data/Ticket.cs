using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Ticmanso.Data
{
    public class Ticket
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public DateTime creation_date { get; set; }

        public DateTime? changed_date { get; set; }

        public DateTime? close_date { get; set; }

        [Required]
        public int chat_id { get; set; }
        [ForeignKey("chat_id")]
        public Chat Chat { get; set; }

        [Required]
        public int creation_user_id { get; set; }
        [ForeignKey("creation_user_id")]
        public User CreationUser { get; set; }

        public int? sopport_user_id { get; set; }
        [ForeignKey("sopport_user_id")]
        public User SopportUser { get; set; }

        [Required]
        public int priority_id { get; set; }
        [ForeignKey("priority_id")]
        public Priority Priority { get; set; }

        [Required]
        public int status_id { get; set; }
        [ForeignKey("status_id")]
        public Status Status { get; set; }
    }

}
