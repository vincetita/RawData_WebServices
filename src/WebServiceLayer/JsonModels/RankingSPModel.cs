using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class RankingSPModel
    {        
        public string Url { get; set; }               
        public decimal? Rank { get; set; }        
        public string body { get; set; }
    }
}
