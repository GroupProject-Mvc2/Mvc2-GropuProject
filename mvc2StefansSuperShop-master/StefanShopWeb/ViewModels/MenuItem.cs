using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StefanShopWeb.ViewModels
{
    public class MenuItem
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Text { get; set; }
        
        public bool IsActive { get; set; }
    }
}
