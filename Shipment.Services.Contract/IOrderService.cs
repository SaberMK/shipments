using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Services.Contract
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> LoadOrders();
    }
}
