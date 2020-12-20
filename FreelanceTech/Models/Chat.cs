using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Models
{
    public class Chat
    {
        public string chatId { get; set; }
        public string firstUser { get; set; }
        public string secondUser { get; set; }
        public byte[] chatItself { get; set; }
    }
}
