using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class PostsModel
    {
        public string Url { get; set; }
        public int PostTypeId { get; set; }
        public DateTime creationDate { get; set; }
        public int? Score { get; set; }
        public string Body { get; set; }
        public int OwnerUserId { get; set; }
        //public virtual Questions Question { get; set; }
    }
}
