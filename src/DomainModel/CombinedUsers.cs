using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class CombinedUsers
    {
        public int CombineUserId { get; set; }
        public string UserName { get; set; }
        public DateTime UserCreationDate { get; set; }
        public string UserLocation { get; set; }
        public int UserAge { get; set; }
    }
}
