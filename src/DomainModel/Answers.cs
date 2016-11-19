using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Answers
    {
        [Key]
        public int AnswerId { get; set; }
        //[ForeignKey("Posts")]
        public int PostId { get; set; }
        public int ParentId { get; set; }
        [ForeignKey("PostsId")]
        public virtual Posts Posts { get; set; }

    }
}
