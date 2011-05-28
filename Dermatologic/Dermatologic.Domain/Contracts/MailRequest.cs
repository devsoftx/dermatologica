using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Domain.Contracts
{
    [DataContract]
    public class MailRequest
    {
        [DataMember]
        public string Subject{ set; get; }

        [DataMember]
        public string Body { set; get; }

        [DataMember]
        public bool IsHtmlBody { set; get; }

        [DataMember]
        public string Host { set; get; }

        [DataMember]
        public bool EnableSSL { set; get; }

        [DataMember]
        public int Port { set; get; }

        [DataMember]
        public List<string> To { set; get; }
    }
}