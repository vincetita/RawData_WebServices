using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;





namespace MySqlDatabase
{
    public class MarkedPost
    {
       using (var db = new StackOverflowContext())
            {
                var markedPosts = db.Posts
                    .Where(p => p.Mark == 1)
                    .OrderBy(mp => mp.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
                return markedPosts;
            }
        }
  
       public int GetNumberOfMarkedPosts()
         {
          using (var db = new StackOverflowContext())
    {
        return db.Posts
            .Where(mp => mp.Mark == 1)
            .Count();
    }
}

public bool UnMarkPost(int id)
{
    using (var database = new StackOverflowContext())
    {
        var markedPost = database.Posts.FirstOrDefault(p => p.Id == id);
        if (markedPost == null) return false;

        try
        {
            markedPost.Mark = 0;
            database.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}


