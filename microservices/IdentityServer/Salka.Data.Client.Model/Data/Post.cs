using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Clients.Model.Data
{
    public partial class Post : BaseEntity
    {
        public Post()
        {
            Addresses = new HashSet<Address>();
        }

        //public int PostId { get; set; }
        public string PostalCode { get; set; }

        public Post(string postalCode) : this()
        {
            PostalCode = postalCode;
        }

        public Post(int postId, string postalCode) : this(postalCode)
        {
            Id = postId;
        }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
