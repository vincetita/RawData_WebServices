using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    public class BaseController : Controller
    {
        public IDataService DataService { get; }

        public BaseController(IDataService dataService)
        {
            DataService = dataService; 
        }      
        protected string GetPrevUrl(string route, IUrlHelper url, int page, int pageSize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(route, new { page = page - 1, pageSize });

        }

        protected string GetNextUrl(string route, IUrlHelper url, int page, int pageSize, int total)
        {
            if (IsLastPage(page, pageSize, total)) return null;
            return url.Link(route , new { page = page + 1, pageSize });

        }

        protected string GetPrevUrlRankWord(string route, IUrlHelper url, string rankword, int page, int pageSize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(route, new { rankword, page = page - 1, pageSize });

        }

        protected string GetNextUrlRankWord(string route, IUrlHelper url, string rankword, int page, int pageSize, int total)
        {
            if (IsLastPage(page, pageSize, total)) return null;
            return url.Link(route, new { rankword, page = page + 1, pageSize });

        }
        protected static bool IsFirstPage(int page)
        {
            return page == 0;
        }

        protected bool IsLastPage(int page, int pageSize, int total)
        {
            if (total - page * pageSize > 0)
            {
                return false;
            }
            return true;
        }
    }
}
