using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("TestCategories");
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
