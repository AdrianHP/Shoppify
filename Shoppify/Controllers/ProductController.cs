using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppify.Models;
using Shoppify.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shoppify.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository repository;
        public int PageSize = 6;
        public int ItemsPerRow = 3;
        public ProductController(ProductRepository repository)
        {
            this.repository = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllProducts(string category = null, int page = 1)
        {
            if (category != null)
            {
                return View(new AllProductsViewModel
                {
                    Products = repository.products
                               .Where(p => p.Category == category)
                               .OrderBy(p => p.Id)
                               .Skip((page - 1) * PageSize)
                               .Take(PageSize)
                               .ToList(),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        ItemsPerRow = this.ItemsPerRow,
                        TotalItems = repository.products.Where(p => p.Category == category).Count()
                    },
                    Category = category
                });
            }
            return View(new AllProductsViewModel
            {
                Products = repository.products                
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    ItemsPerRow = this.ItemsPerRow,
                    TotalItems = repository.products.Count()
                },
                Category = category
            });
        }        

        public IActionResult Product(long Id)
        {
            return View(repository.GetById(Id));
        }
    }
}
