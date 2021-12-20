using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Models.Product
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public bool Bestseller { get; set; }
        public int CategoryId { get; set; }
    }
}
