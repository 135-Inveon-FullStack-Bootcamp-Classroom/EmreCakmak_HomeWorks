using AutoMapper;
using GraduationApp.Business.Engines.Interfaces;
using GraduationApp.Business.Engines.Models.Order;
using GraduationApp.Data.DAL.UnitOfWork;
using GraduationApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Business.Engines.Implementations
{
    public class OrderEngine : IOrderEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<OrderOverViewModel> GetAllOrderList()
        {
            var orderRepository = _unitOfWork.GetRepository<OrderEntity>();
            var orders = orderRepository.GetAll()
                .Select(order => _mapper.Map<OrderOverViewModel>(order)).ToList();
            return orders;
        }

        public OrderOverViewModel GetOrder(int orderId)
        {
            var orderRepository = _unitOfWork.GetRepository<OrderEntity>();
            var order = orderRepository.GetById(orderId);
            var orderDto = _mapper.Map<OrderOverViewModel>(order);

            return orderDto;
        }
    }
}
