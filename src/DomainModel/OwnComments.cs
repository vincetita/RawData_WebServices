using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class OwnComments
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int CommentScore { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentCreated { get; set; }
        
    }
}
