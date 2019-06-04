using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serviser.Web.Areas.Admin.Models
{
    public class BreadCrumb
    {
        public class Item
        {
            public string Name { get; set; }
            public string Url { get; set; } = "";
            public bool IsActive { get; set; } = false;
        }

        public List<Item> Trail { get; set; }
    }
}