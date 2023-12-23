using BookLibarary.Data_Context;
using BookLibarary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibarary.Helpers
{
    public static class DbIntializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            DB_Context context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DB_Context>();

            if (!context.Categories.Any())
            {
                List<Category> categories = new List<Category>
                {
                    new Category { Id = 1, Name = "Biography", Description="A biography is simply the story of a real person's life." },
                    new Category { Id = 2, Name = "Fiction", Description="A type of novel that has a more mainstream, populist appeal than literary fiction." },
                    new Category { Id = 3, Name = "Computers & Tech", Description="The books in this genre are designed to help people learn and understand the function and operation of a computer." }
                };
                context.Categories.AddRange(categories);
                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories OFF;");
                context.Database.CloseConnection();
            }

            if (!context.Books.Any())
            {
                var books = new List<Book>()
                {
                    new Book{Id=1, Name="Steve Jobs", ISBN="ISBN1", Price=18M, IsOfTheMonth=true, CoverPhoto="/images/covers/Steve_jobs.jpg",
                        CategoryId=1, Category=context.Categories.Find(1)},

                    new Book{Id=2, Name="The Great Gatsby", ISBN="ISBN2", Price=8.99M, IsOfTheMonth=false, CoverPhoto="/images/covers/The_great_gatsby.jpg",
                        CategoryId=2, Category=context.Categories.Find(2)},

                    new Book{Id=3, Name="Pro C# 10 with .NET 6", ISBN="ISBN3", Price=45.49M, IsOfTheMonth=true, CoverPhoto="/images/covers/C_Sharp10.jpg",
                        CategoryId=3, Category = context.Categories.Find(3)},
                };
                context.Books.AddRange(books);
                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Book ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Book OFF;");
                context.Database.CloseConnection();
            }
        }
    }
 }

