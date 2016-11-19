using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class MarkedPosts
    {
        [Key]
        public int MarkedId { get; set; }
        public int PostId { get; set; }
    }
}
