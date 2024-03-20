using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicmansoCrud.Shared
{
    public class CompanyDTO
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Address { get; set; } = null!;

        public long PostalCode { get; set; }

        public string City { get; set; } = null!;

        public string Cif { get; set; } = null!;
    }
}
