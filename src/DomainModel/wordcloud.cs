using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class wordcloud
    {
        [Key]
        public String word  { get; set; }
        public double? wordrank { get; set; }
        
    }
}



    

