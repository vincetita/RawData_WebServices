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
    [Route("api/comments")]
    public class CommentsController : BaseController
    {
        //private IMapper _mapper { get; set; }
        //Comments comment = new Comments();
        
        public CommentsController(IDataService dataService) : base(dataService)     // , IMapper mapper Did nt understand the logic : base 
        {
            //mapper = _mapper;
        }   

        // GET api/values
        [HttpGet(Name = Config.CommentsRoute)]
        public IActionResult Get(int page = 0, int pageSize= Config.DefaultPageSize)
        {

            //Url.Link(Config.CategoryRoute, new { id = 5 });

            var data = DataService.GetComments(page, pageSize)
                .Select(c => ModelFactory.Map(c, Url));


            //var data = DataService.GetComments(page, pageSize)
            //    .Select(_mapper.Map<CommentsModel>(comment.Comments));

            var total = DataService.GetTotalComments();

            var result = new
            {
                Total = total,
                Prev = GetPrevUrl(Config.CommentsRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.CommentsRoute, Url, page, pageSize, total),
                data = data
            };

            return Ok(result);

        }

       

        // GET api/values/5
        [HttpGet("{id}", Name = Config.CommentRoute)]
        //[Route("{id}")]           // We can use route for routing also
        public IActionResult Get(int id)
        {
            var comments = DataService.GetComment(id);
            if (comments == null) return NotFound();
            return Ok(ModelFactory.Map(comments, Url)); 
        } 
        
    }
}
