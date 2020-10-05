using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineStore.Models.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Availability)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Items");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.ImageURL).HasColumnName("ImageURL");
            this.Property(t => t.ItemDescription).HasColumnName("ItemDescription");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.DateAdded).HasColumnName("DateAdded");
            this.Property(t => t.Availability).HasColumnName("Availability");
        }
    }
}
