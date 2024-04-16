using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicmansoWebAPI.Models;

namespace TicmansoCrud.Shared
{
    public class ChatMessageDTO
    {
        public long Id { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual UserDTO FromUser { get; set; }
        public virtual UserDTO ToUser { get; set; }
    }
}
