using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Services.Dto
{
    public class ShipmentDto
    {
        public int ShipmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public class ProductDto
        {
            public string SKU { get; set; }
            public int Quantity { get; set; }
        }
    }
}
