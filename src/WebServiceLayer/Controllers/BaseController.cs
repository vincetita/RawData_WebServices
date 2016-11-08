using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;

namespace WebServiceLayer.Controllers
{
    public class BaseController:Controller
    {
        public IDataService DataService { get; }

        public BaseController(IDataService dataService)
        {
            DataService = dataService;
        }

    }
}
