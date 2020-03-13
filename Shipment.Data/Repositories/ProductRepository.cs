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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShipmentDbContext dbContext) : base(dbContext)
        {
        }
    }
}
