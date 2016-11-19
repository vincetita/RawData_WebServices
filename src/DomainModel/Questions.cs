using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }

        [ForeignKey("Posts")]
        public int PostId { get; set; }
        public string Title { get; set; }
        public int AcceptedAnswerId { get; set; }
        public DateTime ClosedDate { get; set; }
        
    }
}
