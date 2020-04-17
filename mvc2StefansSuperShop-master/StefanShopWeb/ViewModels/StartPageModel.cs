﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StefanShopWeb.ViewModels
{
    public class StartPageModel
    {
        public class TrendingCategory
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public List<TrendingCategory> TrendingCategories { get; set; }
    }
}
