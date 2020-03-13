using Shipment.Data.Contract.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Contract
{
    public interface IShipmentDbUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
