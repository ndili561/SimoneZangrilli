using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimoneZangrilli.SMTP
{
     public interface IEmailSender 
    {
        Task<Task> SendEmailAsync(string email, string message, string firstname,string lastname);
    }
}
