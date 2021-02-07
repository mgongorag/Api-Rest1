using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public class ReplyMessages
    {
        public int status { get; set; }
        public string message { get; set; }

        public ReplyMessages(int status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
