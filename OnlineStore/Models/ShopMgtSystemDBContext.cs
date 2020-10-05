using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OnlineStore.Models.Mapping;

namespace OnlineStore.Models
{
    public partial class ShopMgtSystemDBContext : DbContext
    {
        static ShopMgtSystemDBContext()
        {
            Database.SetInitializer<ShopMgtSystemDBContext>(null);
        }

        public ShopMgtSystemDBContext()
            : base("Name=ShopMgtSystemDBContext")
        {
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ItemMap());
        }
    }
}
