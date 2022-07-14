using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppify.Models
{
    public interface IProductRepository: IRepository<Product>
    {
        public new IQueryable<Product> GetAll();
        public  Product GetById(long Id);
        public new void AddEntity(Product entity);
    }
}
