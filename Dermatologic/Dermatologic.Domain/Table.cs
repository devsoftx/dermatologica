using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Table : IEquatable<Table>
    {
        private IList<ItemTable> _itemTables;

        public Table()
        {
            _itemTables = new List<ItemTable>();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Name { set; get; }

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
        public virtual IList<ItemTable> ItemTables
        {
            get { return _itemTables; }
            set { _itemTables = value; }
        }

        public virtual bool Equals(Table other)
        {
            return Id.Equals(other.Id);
        }
    }
}