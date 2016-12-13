using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlDatabase;
using DataAccessLayer;
using WebServiceLayer.JsonModels;
using AutoMapper;
using DomainModel;

namespace WebServiceLayer.Controllers
{
    [Route("api/posts")]
    public class PostsController : BaseController
    {
        public PostsController (IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.PostsRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.GetPosts(page, pageSize)
                .Select(p => ModelFactory.Map(p, Url));

            var total = DataService.GetTotalPosts();

            var result = new
            {
                Total = total,
                Url = Url.Link(Config.PostsRoute, new { page, pageSize }),
               
                Prev = GetPrevUrl(Config.PostsRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.PostsRoute, Url, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }

        [HttpGet("{id}", Name = Config.PostRoute)]
        
        public IActionResult Get(int id)
        {
            var posts = DataService.GetAnswersForSpecificPost(id)
                .Select(p => ModelFactory.Map(p, Url));
            if (posts == null) return NotFound();
            return Ok(posts);
        }
    }
}
