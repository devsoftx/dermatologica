using Dermatologic.Domain.Contracts;

namespace Dermatologic.Services
{
    public interface IMailerService
    {
        MailResponse SendEmail(MailRequest mailRequest);
    }
}