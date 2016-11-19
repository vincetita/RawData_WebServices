using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Tags
    {
        [Key]
        public int PostId { get; set; }
        public string TagsDesc { get; set; }
    }
}
