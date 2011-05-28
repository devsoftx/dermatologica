using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Services
{
    [DataContract]
    public class ResponseBase<T>
    {
        private IList<T> _list;

        public ResponseBase()
        {
            _list = new List<T>();       
        }

        [DataMember]
        public IList<T> Results
        {
            get { return _list; }
            set { _list = value; }
        }

        [DataMember]
        public OperationResult OperationResult
        { 
            get;
            set; 
        }

        [DataMember]
        public string Message
        { 
            get; 
            set;
        }
    }

    [DataContract]
    public enum OperationResult
    {
        [DataMember]
        Success,
        [DataMember]
        Failed,
        [DataMember]
        SuccessWithWarning
    }
}
