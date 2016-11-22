using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    
        [Route("api/tags")]
        public class TagsController : BaseController
        {

            public TagsController(IDataService dataService) : base(dataService)
            {
            }

            //// GET api/values
            [HttpGet(Name = Config.TagsRoute)]
            public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
            {
                var data = DataService.GetTags(page, pagesize)
                    .Select(c => ModelFactory.Map(c, Url));
                var total = DataService.GetNumberOfTags();

                var result = new
                {
                    total = total,
                    prev = GetPrevUrl(Config.TagsRoute, Url, page, pagesize),
                    netx = GetNextUrl(Config.TagsRoute, Url, page, pagesize, total),
                    data = data
                };

                return Ok(result);
            }

            // GET api/values/5
            [HttpGet("{id}", Name = Config.TagRoute)]
            //[HttpGet("{id:int}/tags", Name = Config.TagsRoute)]
            public IActionResult Get(int id)
            {
                var tags = DataService.GetTagsById(id)
                .Select(c => ModelFactory.Map(c, Url));
            
                if (tags == null) return NotFound();
                return Ok(tags);
            }
        }
}

