using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineStore.Models.Mapping
{
    public class AdminUserMap : EntityTypeConfiguration<AdminUser>
    {
        public AdminUserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("AdminUsers");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.password).HasColumnName("password");
        }
    }
}
