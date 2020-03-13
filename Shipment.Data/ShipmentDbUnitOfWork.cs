using Shipment.Data.Base;
using Shipment.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data
{
    public class ShipmentDbUnitOfWork : BaseUnitOfWork<ShipmentDbContext>, IShipmentDbUnitOfWork
    {
        public ShipmentDbUnitOfWork(ShipmentDbContext dbContext) : base(dbContext)
        {

        }


    }
}
