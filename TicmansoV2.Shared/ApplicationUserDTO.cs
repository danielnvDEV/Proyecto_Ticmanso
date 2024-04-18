using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicmansoV2.Shared
{
    public class ApplicationUserDTO : IdentityUser
    {

        public int? CompanyId { get; set; }
        public string Name { get; set; }
    }
}
