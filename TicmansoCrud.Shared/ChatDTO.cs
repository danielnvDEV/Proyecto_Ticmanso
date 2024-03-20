using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicmansoCrud.Shared
{
    public class ChatDTO
    {
        public int Id { get; set; }

        public string? Messages { get; set; }

        public long UserId { get; set; }

        public long UserId1 { get; set; }
    }
}
