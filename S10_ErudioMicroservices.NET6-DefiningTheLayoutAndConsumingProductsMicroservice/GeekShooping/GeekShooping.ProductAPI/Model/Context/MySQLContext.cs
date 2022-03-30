using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Blusa",
                Price = 69.9,
                Description = "Blusa",
                ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true",
                CategoryName = "T-Shirt",
            });
        }
    }
}
