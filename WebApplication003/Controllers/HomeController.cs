using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication003.Data;
using WebApplication003.Models;

namespace WebApplication003.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //routing
            //localhost://54329/Home/Index
            //localhost://54329
            return View();
        }

        public IActionResult Post()
        {
            //localhost://54329/Home/Post
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(this.Post));
        }
    }
}
