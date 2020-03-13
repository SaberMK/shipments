using Shipment.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Services.Contract
{
    public interface IShipmentService
    {
        Task<IEnumerable<ShipmentDto>> GetShipments(IEnumerable<int> orderIds);
        Task<string> GetShipmentsBySP(IEnumerable<int> orderIds);
    }
}
