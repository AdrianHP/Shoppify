using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Shoppify.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();             
            context.Database.Migrate();
            /*if (context.Users.Any())
            {
                var rows = from o in context.Users select o;
                foreach (var r in rows)
                {
                    context.Users.Remove(r);
                }
            }
            if (context.Products.Any())
            {
                var products1 = from o in context.Products select o;
                foreach (var r in products1)
                {
                    context.Products.Remove(r);
                }
                context.SaveChanges();
            }*/
            
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Pepe",
                    LastName = "Perez",
                    Info = "Salesman",
                    UserName = "PPerez",
                    Password = "NoPassword"
                });
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                List<Product> products = new List<Product>();
                Product p = new Product
                {
                    Image1 = "/images/product01.jpg",
                    Title = "Kayak",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product {
                    Image1 = "/images/product06.jpg",
                    Title = "Lifejacket",
                    Description = "Protective and fashionable",
                    Category = "Watersports",
                    Price = 48 };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product {
                    Image1 = "/images/product07.jpg",
                    Title = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    Category = "Soccer",
                    Price = 19 };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product {
                    Image1 = "/images/product05.jpg",
                    Title = "Corner Flags",
                    Description = "Give your playing field a professional touch",
                    Category = "Soccer",
                    Price = 39 };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product {
                    Image1 = "/images/product04.jpg",
                    Title = "Stadium",
                    Description = "Flat-packed 35,000-seat stadium",
                    Category = "Soccer",
                    Price = 79500 };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product {
                    Image1 = "/images/product03.jpg",
                    Title = "Thinking Cap",
                    Description = "Improve brain efficiency by 75%",
                    Category = "Chess",
                    Price = 16 };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product {
                    Image1 = "/images/product08.jpg",
                    Title = "Unsteady Chair",
                    Description = "Secretly give your opponent a disadvantage",
                    Category = "Chess",
                    Price = 30 };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product
                {
                    Image1 = "/images/product02.jpg",
                    Title = "Human Chess Board",
                    Description = "A fun game for the family",
                    Category = "Chess",
                    Price = 75
                };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                p = new Product
                {
                    Image1 = "/images/product06.jpg",
                    Title = "Bling-Bling King",
                    Description = "Gold-plated, diamond-studded King",
                    Category = "Chess",
                    Price = 1200
                };
                p.User = context.Users.FirstOrDefault();
                products.Add(p);
                context.AddRange(products);
                context.SaveChanges();
            }
        }
        /*public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            context.Users.Add(new User
            {
                Name = "Pepe",
                LastName = "Perez",
                Info = "Salesman",
                UserName = "PPerez",
                Password = "NoPassword"

            });
            context.SaveChanges();
            Product p = new Product
            {
                Image1 = "/images/product01.jpg",
                Title = "Kayak",
                Description = "A boat for one person",
                Category = "Watersports",
                Price = 275
            };
            p.User = context.Users.FirstOrDefault(u => u.Id == 1);
            context.Products.Add(p);
            context.SaveChanges();

        }*/
    }
}
