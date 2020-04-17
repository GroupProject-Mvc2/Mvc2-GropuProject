using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using StefanShopWeb.Data;
using StefanShopWeb.ViewModels;

namespace StefanShopWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        List<MenuItem> SetupMenu(string activeAction)
        {
            var list = new List<MenuItem>();
            list.Add( new MenuItem { Text = "Products", Action = "Products", Controller="Admin", IsActive = activeAction == "Products"  } );
            list.Add(new MenuItem { Text = "Categories", Action = "Categories", Controller = "Admin", IsActive = activeAction == "Categories" });
            return list;
        }
        public IActionResult Index()
        {
            var model = new AdminViewModel();
            model.MenuItems = SetupMenu("");
            return View(model);
        }
        public IActionResult Products()
        {
            var model = new AdminProductListViewModel();
            model.MenuItems = SetupMenu("Products");
            model.Products = dbContext.Products.Include(p => p.Category).
                Select(p => new AdminProductListViewModel.Product {
                    Id = p.ProductId,
                    CategoryName = p.Category.CategoryName,
                    Name = p.ProductName,
                    Price = p.UnitPrice.Value
                }).ToList();
            return View(model);
        }

        public IActionResult EditProduct(int id)
        {
            var model = new AdminEditProductViewModel();
            model.MenuItems = SetupMenu("Products");
            var prod = dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            model.ProductId = prod.ProductId;
            model.ProductName = prod.ProductName;
            model.SupplierId = prod.SupplierId.Value;
            model.UnitPrice = prod.UnitPrice.Value;
            model.CategoryId = prod.CategoryId;
            model.Discontinued = prod.Discontinued;
            model.UnitsInStock = prod.UnitsInStock.Value;

            return View(model);
        }


        public IActionResult Categories()
        {
            var model = new AdminCategoryListViewModel();
            model.MenuItems = SetupMenu("Categories");
            model.Categories = dbContext.Categories.Select(c =>
                new AdminCategoryListViewModel.Category { Id = c.CategoryId, Name = c.CategoryName }).ToList();
            return View(model);
        }

    }
}