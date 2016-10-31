using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Questions
    {
        public int QuestionId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public int AcceptedAnswerId { get; set; }
        public DateTime ClosedDate { get; set; }
        
    }
}
