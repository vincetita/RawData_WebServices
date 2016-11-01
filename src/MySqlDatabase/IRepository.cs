using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using DomainModel;
using MySqlDatabase.data.MySqlClient;

namespace MySqlDatabase
{
    interface IRepository
    {

        //Posts 
        public IEnumerable<Posts> GetPosts(int limit, int offset)

        {
            using (var dbPost = new stackOverFlowContext())
            { 

}
