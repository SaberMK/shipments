using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Configurations
{
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            ToTable("TestProductCategories");
            HasKey(x => new { x.CategoryId, x.ProductId });

            HasRequired(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Product)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}
