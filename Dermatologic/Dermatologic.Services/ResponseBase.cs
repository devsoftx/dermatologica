using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Services
{
    [DataContract]
    public class ResponseBase<T> where T : new()
    {
        private IList<T> _list;
        private T _entity;

        public ResponseBase()
        {
            _list = new List<T>();   
            _entity = new T();
        }

        [DataMember]
        public IList<T> Results
        {
            get { return _list; }
            set { _list = value; }
        }

        [DataMember]
        public T Entity
        {
            get { return _entity; }
            set { _entity = value; }
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

        [DataMember]
        public PagingParameters PagingParameters
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

    [DataContract]
    public class PagingParameters
    {
        [DataMember]
        public int PageIndex { set; get; }

        [DataMember]
        public int PageSize { set; get; }

        [DataMember]
        public int VirtualCount { set; get; }
    }
}
