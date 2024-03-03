using System.ComponentModel.DataAnnotations;

namespace Ticmano.Data
{
    public class Company
    {
        [Key]
        public int id { get; set; }

        [Required] // Propiedad obligatoria
        [MaxLength(50)]
        public string name { get; set; }

        [Required]
        [MaxLength(50)]
        public string country { get; set; }

        [Required]
        [MaxLength(200)]
        public string address { get; set; }

        [Required]
        public int postalCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string city { get; set; }

        [Required]
        [MaxLength(9)]
        public string cif { get; set; }
    }
}
