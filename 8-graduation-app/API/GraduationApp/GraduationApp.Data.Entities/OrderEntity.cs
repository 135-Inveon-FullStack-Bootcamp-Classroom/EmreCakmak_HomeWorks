using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Data.Entities
{
    [Table("Orders")]
    public class OrderEntity:BaseEntity
    {
        public string Name { get; set; }
        public decimal OrderValue { get; set; }
        public DateTime EstimatedDeliveryTime { get; set; }
        public string DeliveryAddress { get; set; }

    }
}
