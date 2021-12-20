using GraduationApp.Business.Engines.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Interfaces
{
    public interface IOrderEngine:IEngineBase
    {
        List<OrderOverViewModel> GetAllOrderList();
        OrderOverViewModel GetOrder(int orderId);
    }
}
