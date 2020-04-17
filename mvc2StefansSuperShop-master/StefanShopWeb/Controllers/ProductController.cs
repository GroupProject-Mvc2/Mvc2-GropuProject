using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StefanShopWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Category(int id)
        {

            return View();
        }

    }
}