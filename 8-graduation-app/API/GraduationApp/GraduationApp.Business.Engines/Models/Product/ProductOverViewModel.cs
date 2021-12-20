using GraduationApp.Business.Engines.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Models.Product
{
    public class ProductOverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public bool Bestseller { get; set; }
        public CategoryOverViewModel Category { get; set; }
    }
}
