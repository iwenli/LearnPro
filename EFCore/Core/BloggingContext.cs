using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Core
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=192.168.1.29;Initial Catalog=Blogging;User Id=sa;Password=Pa@@wordSAGerberDev;Max Pool Size=512;Min Pool Size=5;");
            //base.OnConfiguring(optionsBuilder);
        }
    }

    public class Blog {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Blog Blog { get; set; }
    }
}
