using GraduationApp.Business.Engines.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationApp.Application.API.Controllers
{
    
    public class OrdersController : BaseController
    {
        private readonly IOrderEngine _orderEngine;

        public OrdersController(IOrderEngine orderEngine)
        {
            _orderEngine = orderEngine;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderEngine.GetAllOrderList();

            return Ok(orders);
        }

        [HttpGet("{orderId:int}", Name = "GetOrder")]
        public IActionResult GetOrder(int orderId)
        {
            var order = _orderEngine.GetOrder(orderId);

            return Ok(order);
        }
    }
}
