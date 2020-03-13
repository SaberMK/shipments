using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("TestOrders");
            HasKey(x => x.Id);

            Property(x => x.FirstName)
                .HasMaxLength(255);

            Property(x => x.LastName)
                .HasMaxLength(255);

            Property(x => x.Address)
                .HasMaxLength(255);

            Property(x => x.City)
                .HasMaxLength(255);

            Property(x => x.FirstName)
                .HasMaxLength(255);

            Property(x => x.State)
                .HasMaxLength(255);

            Property(x => x.Country)
                .HasMaxLength(255);
        }
    }
}
