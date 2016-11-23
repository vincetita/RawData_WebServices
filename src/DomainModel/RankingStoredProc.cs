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
        [Column("posts.id")]
        public int postsid { get; set; }
        [Column("Rank")]
        public decimal? Rank { get; set; }
        [Column("body")]
        public string body { get; set; }
        
    }
}
