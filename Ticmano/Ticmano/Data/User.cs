using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Ticmano.Data
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(30)]
        public string name { get; set; }

        [MaxLength(50)]
        public string surnames { get; set; }

        [Required]
        [MaxLength(75)]
        public string mail { get; set; }

        [Required]
        [MaxLength(40)]
        public string password { get; set; }

        [Required]
        public int company_id { get; set; }
        [ForeignKey("company_id")] // Indica la relación  
        public Company Company { get; set; }

        [Required]
        public int role_id { get; set; }
        [ForeignKey("role_id")]
        public Role Role { get; set; }
    }
}
