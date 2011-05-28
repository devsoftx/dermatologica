using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class ItemTable : IEquatable<ItemTable>
    {
        private Table _table;

        public ItemTable()
        {
            _table = new Table();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Name { set; get; }

        [DataMember]
        public virtual string Value1 { set; get; }

        [DataMember]
        public virtual string Value2 { set; get; }

        [DataMember]
        public virtual bool IsActive { set; get; }

        [DataMember]
        public virtual DateTime? CreationDate { set; get; }

        [DataMember]
        public virtual DateTime? LastModified { set; get; }

        [DataMember]
        public virtual Guid? CreatedBy { set; get; }

        [DataMember]
        public virtual Guid? ModifiedBy { set; get; }

        [DataMember]
        public virtual Table Table
        {
            get { return _table; }
            set { _table = value; }
        }

        public virtual bool Equals(ItemTable other)
        {
            return Id.Equals(other.Id);
        }
    }
}