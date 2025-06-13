using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace Spovest.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(string fullname, string toEmail, string subject, string message);
        public Task<bool> SendMessage(MimeMessage message);

    }
}
