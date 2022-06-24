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
            var posts = _dbContext.Posts.ToList();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);
            //localhost://54329/Home/Post
            return View(post);
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

            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _dbContext.Posts.Update(post);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(this.Index));
        }

        public async Task<ActionResult> Remove(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();

           return RedirectToAction(nameof(this.Index));
        }
    }
}
