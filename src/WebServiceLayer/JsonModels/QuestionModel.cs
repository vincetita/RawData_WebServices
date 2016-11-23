using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class QuestionModel
    {
        public string Url { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
