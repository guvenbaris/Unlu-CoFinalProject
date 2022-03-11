using System.Net.Mail;

namespace UnluCoProductCatalog.Application.Interfaces.Mail
{
    public interface ISmtpServer
    {
        SmtpClient GetSmtpClient();
    }
}
