using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StefanShopWeb.Data;

namespace StefanShopWeb.Controllers
{
    public class GeneralController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public GeneralController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult GetCategoryImage(int id)
        {
            var offset = 78;
            var imageData = dbContext.Categories.Find(id).Picture;
            var bytes = new byte[imageData.Length - offset];

            Array.Copy(imageData, offset, bytes, 0, bytes.Length);
            return File(bytes, "image/png");
        }
    }
}