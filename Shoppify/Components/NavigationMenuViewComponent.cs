using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoppify.Models;

namespace Shoppify.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ProductRepository repository;

        public NavigationMenuViewComponent(ProductRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p));
        }
    }
}
