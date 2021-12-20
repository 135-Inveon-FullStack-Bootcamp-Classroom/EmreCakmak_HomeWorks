using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Data.Entities
{
    [Table("Products")]
    public class ProductEntity:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public bool Bestseller { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
