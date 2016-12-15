using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using WebServiceLayer.JsonModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/wordcloud")]
    public class WordcloudController : BaseController
    {

        public WordcloudController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.WordCloudRoute)]
        public IActionResult Get(string word, int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.Getwordcloud(word, page, pageSize)
           .Select(h => ModelFactory.Map(h, Url));

            var total = DataService.GetWordCloud(word);

            var result = new
            {
                Total = total,
                //Prev = GetPrevUrlWordCloud(Config.WordClouddRoute, Url, wordcloud, page, pageSize),
                //Next = GetNextUrlWordCloud(Config.WordCloudRoute, Url,WordCloud, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }
    }
}

