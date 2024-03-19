using System.ComponentModel.DataAnnotations;

namespace Ticmanso.Data
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Cif { get; set; }

        public ICollection<User> Users { get; set; }
    }

}
