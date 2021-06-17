using AspProject.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AspProject.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("nikolamilica91@gmail.com", "nikola98milica93")
            };

            var message = new MailMessage("nikolamilica91@gmail.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Subject;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
