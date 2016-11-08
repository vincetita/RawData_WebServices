using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class History
    {
        public int HistoryId { get; set; }
        public int Keyword { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
