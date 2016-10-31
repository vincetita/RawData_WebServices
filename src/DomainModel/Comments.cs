using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Comments
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int CommentScore { get; set; }
        public string CommentText{ get; set; }
        public DateTime CommentCeated { get; set; }
        public int OwnerUserId { get; set; }
    }
}
