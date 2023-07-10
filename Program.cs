using Blog.Data;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            //var user = new User
            //{
            //    Name = "Lucas Oliveira",
            //    Slug = "lucasso",
            //    Email = "lucasi.outlook.com",
            //    Bio = "Desenvolvedor Full stack",
            //    Image = "hrrps: //",
            //    PasswordHash = "12352560"
            //};

            //var category = new Category 
            //{
            //    Name = "Full stack",
            //    Slug = "full stack"
            //};

            //var post = new Post
            //{
            //    Author = user,
            //    Category = category,
            //    Body = "<p>Hello world<p>",
            //    Slug = "comecando-com-ef-core",
            //    Summary = "Neste artigo vamos aprender EF core",
            //    Title = "Começando com EF",
            //    CreateDate = DateTime.Now,
            //    LastUpdateDate = DateTime.Now,
            //};

            //context.Posts.Add(post);
            //context.SaveChanges();

            //var posts = context
            //    .Posts
            //    .AsNoTracking()
            //    .Include(x => x.Author)
            //    .Include(x => x.Category)
            //    .OrderByDescending(x => x.LastUpdateDate)
            //    .ToList();

            //foreach (var post in posts) 
            //    Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");

            var post = context
                .Posts
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault();

            post.Author.Name = "Leticia Albuquerque";

            context.Posts.Update(post);
            context.SaveChanges();
        }
    }
}