using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebServiceLayer.JsonModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/users")]
    public class CombinedUsersController : BaseController
    {
        public CombinedUsersController(IDataService dataService) : base(dataService)
        {
        }

        //// GET api/values
        [HttpGet(Name = Config.CombinedUsersRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetCombinedUserses(page, pagesize)
                .Select(c => ModelFactory.Map(c, Url));
            var total = DataService.GetNumberOfUsers();

            var result = new
            {
                total = total,
                prev = GetPrevUrl(Url, page, pagesize),
                netx = GetNextUrl(Url, page, pagesize, total),
                data = data
            };

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = Config.CombinedUserRoute)]
        public IActionResult Get(int id)
        {
            var user = DataService.GetCombinedUserById(id);
            if (user == null) return NotFound();
            return Ok(ModelFactory.Map(user, Url));
        }


        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
