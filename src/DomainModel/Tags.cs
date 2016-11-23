using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Tags
    {        
        public int PostId { get; set; }        
        public string TagsDesc { get; set; }
    }
}
