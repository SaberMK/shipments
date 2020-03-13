using Shipment.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sku { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrderProduct> Orders { get; set; }

        public virtual ICollection<ProductCategory> Categories { get; set; }
    }
}
