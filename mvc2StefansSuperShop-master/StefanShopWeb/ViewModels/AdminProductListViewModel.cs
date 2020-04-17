using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StefanShopWeb.ViewModels
{
    public class AdminProductListViewModel : AdminViewModel
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string CategoryName { get; set; }
            public decimal Price { get; set; }
        }

        public List<Product> Products { get; set; }
    }
}
