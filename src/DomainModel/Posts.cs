using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Posts
    {
        public int PostsId { get; set; }
        public int PostTypeId { get; set; }
        public DateTime creationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int OwnerUserId { get; set; }
        
    }
}
