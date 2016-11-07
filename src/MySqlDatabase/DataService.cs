﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using DataAccessLayer;

namespace MySqlDatabase
{
    public class DataService : IDataService
    {
        // LinkPost
        public IList<LinkPosts> GetLinkToPost(int limit, int offset)
        {
            using (var db = new MySqlDBContext())
            {
                return db.LinkPost
                    .OrderBy(c => c.PostId)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        //Marked post
        public IList<MarkedPosts> GetAllMakedPosts(int limit, int offset)
        {
            throw new NotImplementedException();
        }

       

        public int GetNumberOfMarkedPosts()
        {
            throw new NotImplementedException();
        }


        public bool UnMarkPost(int id)
        {
            using (var db = new MySqlDBContext())
            {
               
                MarkedPosts markedPost  = db.MarkPost.FirstOrDefault(p=>p.PostId == id);
                if (markedPost != null)
                {
                    try
                    {
                        db.MarkPost.Remove(markedPost);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return false;

            }
        }
    }
}
