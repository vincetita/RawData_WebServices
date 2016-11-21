using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

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
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.GetCombinedUsers(page, pageSize)
                .Select(c => ModelFactory.Map(c, Url));
            var total = DataService.GetNumberOfUsers();

            var result = new
            {
                total = total,
                Prev = GetPrevUrl(Config.CombinedUsersRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.CombinedUsersRoute, Url, page, pageSize, total),
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

    }
}
