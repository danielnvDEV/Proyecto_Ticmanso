using System.ComponentModel.DataAnnotations;

namespace Ticmanso.Data
{
    public class Role
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(25)]
        public string name { get; set; }
    }
}
