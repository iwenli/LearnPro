using EFCore.Core;
using System;
using System.Linq;
using System.Text.Json;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };


            Console.WriteLine("Hello World!");
            using var db = new BloggingContext();
            var blog = new Blog { Url = "https://baidu.com/id=" + Guid.NewGuid().ToString() };
            db.Add(blog);
            db.SaveChanges();
            Console.WriteLine("写入:" + JsonSerializer.Serialize(blog, options));

            var blog1 = db.Blogs.OrderBy(m => m.Id).FirstOrDefault();
            Console.WriteLine("读取:" + JsonSerializer.Serialize(blog1, options));

            blog1.Url = "https://baidu.com/id=update";
            blog1.Posts.Add(new Post
            {
                Title = "Hello world!",
                Content = "I wrote an app using EF Core!"
            });
            db.SaveChanges();
            Console.WriteLine("更新:" + JsonSerializer.Serialize(blog1, options));

            db.Remove(blog);
            db.SaveChanges();
        }
    }
}
