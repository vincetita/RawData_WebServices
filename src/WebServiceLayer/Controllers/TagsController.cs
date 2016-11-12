﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using WebServiceLayer.JsonModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/tags")]
    public class TagsController : BaseController
    {

        public TagsController(IDataService dataService) : base(dataService)
        {
        }

        //// GET api/values
        [HttpGet(Name = Config.TagsesRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetTagses(page, pagesize)
                .Select(c => ModelFactory.Map(c, Url));
            var total = DataService.GetNumberOfTags();

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
       // [HttpGet("{id}", Name = Config.TagsRoute)]
        [HttpGet("{id:int}/tags", Name = Config.TagsRoute)]
        public IActionResult Get(int id)
        {
            var tags = DataService.GetTagsById(id);
            if (tags == null) return NotFound();
            return Ok(ModelFactory.Map(tags, Url));
        }



        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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
