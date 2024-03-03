using System.ComponentModel.DataAnnotations;

namespace Ticmano.Data
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
