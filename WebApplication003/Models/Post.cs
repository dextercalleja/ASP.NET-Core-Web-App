using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication003.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Post()
        {
            Title = string.Empty;
            Content = string.Empty;
            Id = 0;
        }
    }
}
