using DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModels
{
    public class PostAnswerModel
    {
        //public string Url { get; set; }
        //public int PostTypeId { get; set; }
        //public DateTime creationDate { get; set; }
        //public int Score { get; set; }
        //public string Body { get; set; }
        //public int OwnerUserId { get; set; }
        public string Url { get; set; }
        
        public string Title { get; set; }
        public IList<string> Answers { get; set; }
        //public string UserName { get; set; }
        //[JsonIgnore]
        //public virtual IList<Answers> Answers { get; set; }

    }
}
