using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppify.Models
{
    public class ProductRepository : IProductRepository
    {

        private ApplicationDbContext context;
        public DbSet<Product> products;
        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
            products = context.Products;
        }
        public void AddEntity(Product entity)
        {
            context.Products.Add(entity);
            context.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
            return products.AsQueryable();
        }

        public Product GetById(object Id)
        {
            return context.Products.Find(Id);
        }

        public Product GetById(long Id)
        {
            return products.Find(Id);
        }
    }
}
