using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class SearchKeywordSPModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
       
        public string body { get; set; }
        
        public int? Score { get; set; }
        
        public string CommentText { get; set; }
        
        public int ParentId { get; set; }
    }
}
