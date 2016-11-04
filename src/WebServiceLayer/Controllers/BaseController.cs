using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    public class BaseController : Controller
    {

        public IDataService DataService { get; }

        public BaseController(IDataService dataService)
        {
            DataService = dataService;
        }


    }
}
