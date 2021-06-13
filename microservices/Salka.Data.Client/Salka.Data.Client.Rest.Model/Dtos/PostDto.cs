using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string PostalCode { get; set; }
        public PostDto()
        {

        }

        public PostDto(string postalCode) : this()
        {
            PostalCode = postalCode;
        }

        public PostDto(int postId, string postalCode) : this(postalCode)
        {
            PostId = postId;
        }
    }
}
