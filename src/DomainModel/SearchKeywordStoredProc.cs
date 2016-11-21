using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class SearchKeywordStoredProc
    {
        [Key] 
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("body")]
        public string body { get; set; }
        [Column("score")]
        public int? Score { get; set; }
        [Column("commenttext")]
        public string CommentText { get; set; }
        [Column("parentid")]
        public int ParentId { get; set; }
    }
}
