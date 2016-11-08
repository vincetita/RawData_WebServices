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
    //[Route("api/posts")]
    //public class PostsController : BaseController
    //{
        //public PostsController(IDataService dataService) : base(dataService)
        //{

        //}

        //[HttpGet(Name = Config.PostsRoute)]
        //public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        //{
        //    var data = DataService.GetPosts(page, pageSize)
        //        .Select(p => ModelFactory.Map(p, Url));

        //    var total = dataservice.GetTotalPosts();

        //    var result = new
        //    {
        //        Total = total,
        //        Prev = GetPrevUrl(Url, page, pageSize),
        //        Next = GetNextUrl(Url, page, pageSize, total),
        //        data = data
        //    };

        //    return Ok(result);
        //}

        //[HttpGet("{id}", Name = Config.PostRoute)]
        ////[Route("{id}")]           // We can use route for routing also
        //public IActionResult Get(int id)
        //{
        //    var posts = DataService.GetPost(id);
        //    if (posts == null) return NotFound();
        //    return Ok(ModelFactory.Map(posts, Url));
        //}
    //}
}
