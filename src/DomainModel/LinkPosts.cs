using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class LinkPosts
    {
        //[Key]
        public int PostId { get; set; }
        public int LinkPostId { get; set; }
        public virtual Posts Post { get; set; }
    }
}
