using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineStore.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CategoryName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
        }
    }
}
