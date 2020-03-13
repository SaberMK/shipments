using Shipment.Data.Contract.Repositories;
using Shipment.Models;
using Shipment.Services.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Shipment.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnityContainer _container;
        public OrderService(IUnityContainer container)
        {
            _container = container;
        }

        public async Task<IEnumerable<Order>> LoadOrders()
        {
            var orderRepository = _container.Resolve<IOrderRepository>();

            return await orderRepository.Query()
                .ToListAsync();                
        }
    }
}
