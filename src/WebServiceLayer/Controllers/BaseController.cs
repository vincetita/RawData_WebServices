using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// ReSharper disable once RedundantUsingDirective
//using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceLayer.Controllers
{
    public class BaseController:Controller
    {
        public BaseController(IDataService dataService)
        {
            DataService = dataService;
        }

        public IDataService DataService { get; }

    }
}
