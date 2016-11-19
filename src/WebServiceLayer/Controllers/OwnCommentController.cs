using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    [Route("api/owncomments")]
    public class OwnCommentController : BaseController
    {
      public OwnCommentController (IDataService dataService) : base(dataService)     
            {
               
            }
            
            [HttpGet(Name = Config.OwnCommentsRoute)]
            public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
            {

                var data = DataService.GetOwnComments(page, pageSize)
                    .Select(c => ModelFactory.Map(c, Url));


                var total = DataService.GetTotalOwnComments();

                var result = new
                {
                    Total = total,
                    Prev = GetPrevUrl(Config.OwnCommentsRoute, Url, page, pageSize),
                    Next = GetNextUrl(Config.OwnCommentsRoute, Url, page, pageSize, total),
                    data = data
                };

                return Ok(result);

            }
        
            [HttpGet("{id}", Name = Config.OwnCommentRoute)]
            public IActionResult Get(int id)
            {
                var comments = DataService.GetOwnCommentbyID(id);
                if (comments == null) return NotFound();
                return Ok(ModelFactory.Map(comments, Url));
            }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]OwnCommentModel model)
        {
            var owncomment = ModelFactory.Map(model);
            DataService.AddOwnComment(owncomment);
            return Ok(ModelFactory.Map(owncomment, Url));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OwnCommentModel model)
        {
            var own = ModelFactory.Map(model);
            own.CommentId = id;
            if (!DataService.UpdateOwnComment(own))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeleteOwnComment(id))
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

