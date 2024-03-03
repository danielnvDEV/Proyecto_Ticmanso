using System.ComponentModel.DataAnnotations;

namespace Ticmano.Data
{
    public class Status
    {
        [Key]  // Indica que es la llave primaria
        public int id { get; set; }

        [MaxLength(20)] // Longitud máxima
        public string name { get; set; }
    }
}
