using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public class ReplyMessages
    {
        public int code { get; set; }
        public string message { get; set; }

        public ReplyMessages(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
