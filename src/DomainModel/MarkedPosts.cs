using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class MarkedPosts
    {
        public int MarkedId { get; set; }
        [ForeignKey("Posts")]
        public int PostId { get; set; }
        [ForeignKey("Postid")]
        public virtual Posts Post { get; set; }
    }
}
