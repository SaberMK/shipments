using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("TestProducts");
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(255);

            Property(x => x.Sku)
                .HasMaxLength(255);

            Property(x => x.Description)
                .HasMaxLength(255);
        }
    }
}
