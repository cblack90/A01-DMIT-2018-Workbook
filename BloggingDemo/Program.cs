﻿using BloggingDemo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    namespace Entities
    {
        public class Blog
        {
            //"Primary Key", by convention
            public int BlogID { get; set; }
            public string Name { get; set; }
            //Navigation Property
            public virtual ICollection<Post> Posts { get; set; }
        }

        public class Post
        {
            //"Primary Key", by convention
            public int PostID { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int BlogID { get; set; }
            //Navigation Property
            public virtual Blog Blog { get; set; }
        }//end of Post Class
    }//end of Entities NameSpace

    namespace DAL
    {
        public class BloggingContext : DbContext
        {
            public BloggingContext() : base("name=BlogDb")
            {

            }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
    }
}
