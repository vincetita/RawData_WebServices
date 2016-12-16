using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class OwnCommentModel
    {
        public string Url { get; set; }
        public int PostId { get; set; }
        public int CommentScore { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentCreated { get; set; }
        public string PostUrl { get; set; }
    }
}
