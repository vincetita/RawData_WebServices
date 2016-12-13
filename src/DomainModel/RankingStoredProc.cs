using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class RankingStoredProc
    {
        [Key]
        [Column("id")]
        public int postsid { get; set; }
        [Column("rank")]
        public double? Rank { get; set; }
        [Column("body")]
        public string body { get; set; }
        [Column("title")]
        public string title { get; set; }
        
    }
}
