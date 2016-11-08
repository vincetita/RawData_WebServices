using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/tags")]
    public class TagsController : BaseController
    {
        // GET: api/values
        public TagsController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get(int page=0, int pagesize=5) //config
        {
            int limit = pagesize;
            int offset = page*pagesize;
            var listOfTags = DataService.GetLinkToTags(limit, offset);
            return Ok(listOfTags);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}























    }
}
