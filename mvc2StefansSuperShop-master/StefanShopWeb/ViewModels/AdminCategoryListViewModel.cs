using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StefanShopWeb.ViewModels
{
    public class AdminCategoryListViewModel : AdminViewModel
    {
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public List<Category> Categories { get; set; }
    }
}
