using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Models.Order
{
    public class OrderOverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OrderValue { get; set; }
        public DateTime EstimatedDeliveryTime { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
