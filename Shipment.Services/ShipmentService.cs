using Shipment.Data;
using Shipment.Data.Contract.Repositories;
using Shipment.Services.Contract;
using Shipment.Services.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using static Shipment.Services.Dto.ShipmentDto;

namespace Shipment.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IUnityContainer _container;
        public ShipmentService(IUnityContainer container)
        {
            _container = container;
        }
        public async Task<IEnumerable<ShipmentDto>> GetShipments(IEnumerable<int> orderIds)
        {
            var orderRepository = _container.Resolve<IOrderRepository>();
            
            var orders = await orderRepository.Table()
                .Include("Products")
                .Include("Products.Product")
                .Include("Products.Product.Categories")
                .Include("Products.Product.Categories.Category")
                .Where(x => orderIds.Contains(x.Id))
                .ToListAsync();
            
            var differentShipments = orders
                .GroupBy(x => new { x.State, x.Address, x.City, x.Country })
                .Select(x => x.Key)
                .ToList();

            var result = orders.Select(order => new ShipmentDto
            {
                Address = order.Address,
                City = order.City,
                Country = order.Country,
                FirstName = order.FirstName,
                LastName = order.LastName,
                State = order.State,
                ShipmentId = differentShipments
                    .FindIndex(x => x.City == order.City
                              && x.Address == order.Address
                              && x.Country == order.Country
                                && x.State == order.State
                                    ),
                Products = order.Products.Select(x => x.Product)
                                .GroupBy(x => x.Sku)
                                .SelectMany(x => x.Select(y => new ProductDto
                                {
                                    SKU = x.Key,
                                    Quantity = x.SelectMany(z => z.Orders).Sum(a => a.Quantity)
                                }))
                                .ToList()
            })
                .OrderBy(x => x.ShipmentId)
                .Where(x => x.Products.Count() > 0)
                .ToList();

            return result;
        }

        public async Task<string> GetShipmentsBySP(IEnumerable<int> orderIds)
        {
            var dbContext = _container.Resolve<ShipmentDbContext>();

            var parameter = new List<SqlParameter>()
            {
                new SqlParameter("@str", string.Join(",", orderIds))
            };

            var result = await dbContext.Database
                .SqlQuery<string>("dbo.Orders @str", parameter.ToArray())
                .FirstAsync();

            return result;
        }
    }


}
