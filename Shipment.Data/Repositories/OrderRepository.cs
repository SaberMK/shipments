using Shipment.Data.Base;
using Shipment.Data.Contract.Repositories;
using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShipmentDbContext dbContext) : base(dbContext)
        {
        }
    }
}
