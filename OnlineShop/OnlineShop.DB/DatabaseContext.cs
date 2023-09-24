using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShop.db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData( new List<Product>(){
                new Product(Guid.NewGuid(), "Обломов", "И.А. Гончаров", "Роман, Художественный вымысел, Сатира", 255.14m, "Книга о лежибоке, который смог" ),
                new Product( Guid.NewGuid(), "Памятник", "А.С. Пушкин", "Ода", 50.18m, "В книге представлено стихотворение величайшего поэта" ),
                new Product( Guid.NewGuid(), "Евгений Онегин", "А.С. Пушкин", "Роман", 300.98m, "Книга о том, как все в один момент может пойти..." ),
                new Product( Guid.NewGuid(), "Горе от ума", "А.С. Грибоедов", "Комедия", 400.00m, "Круто говоришь Чатский, только всем все равно" )
            });
        }
public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
