using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission7Final.Models;
using Mission7Final.Models.ViewModels;

namespace Mission7Final.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;

        public HomeController(IBookRepository context)
        {
            repo = context;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;
            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Books.Count(),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }

    }
}
