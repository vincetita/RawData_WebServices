using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class WordCloudModel
    {
        public String text { get; set; }
        public double? weight { get; set; }
    }
}
