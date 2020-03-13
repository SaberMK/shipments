using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Configurations
{
    public class OrderProductConfiguration : EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductConfiguration()
        {
            ToTable("TestOrderProducts");
            HasKey(x => x.Id);

            HasRequired(x => x.Product)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.OrderId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Order)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}
