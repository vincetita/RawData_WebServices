using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class HistoryModel
    {
        public string Url { get; set; }
        public string Keyword { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
