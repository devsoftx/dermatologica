using System.Net.Mail;
using System.Runtime.Serialization;
using Dermatologic.Domain.Contracts;

namespace Dermatologic.Services
{
    [DataContract]
    public class MailResponse : ResponseBase<MailMessage>
    {
        
    }
}