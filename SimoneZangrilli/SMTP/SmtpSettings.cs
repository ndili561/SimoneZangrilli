using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimoneZangrilli.SMTP
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string FromAddress { get; set; }

        public string Password { get; set; }
        public string ToAddress { get; set; }
    }
}
