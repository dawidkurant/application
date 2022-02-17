using Microsoft.EntityFrameworkCore;

namespace Papu.Entities
{
    //Klasa odpowiadająca bazie danych
    public class PapuDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=PapuDb;Trusted_Connection=True;";
        public DbSet<Product> Products { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Friday> Fridays { get; set; }
        public DbSet<Monday> Mondays { get; set; }
        public DbSet<Saturday> Saturdays { get; set; }
        public DbSet<Sunday> Sundays { get; set; }
        public DbSet<Thursday> Thursdays { get; set; }
        public DbSet<Tuesday> Tuesdays { get; set; }
        public DbSet<Wednesday> Wednesdays { get; set; }
        public DbSet<KindOf> KindsOf { get; set; }
        public DbSet<Type> Types { get; set; }


        //Dodatkowe właściwości które powinny zawiera kolumny w bazie danych
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(r => r.MenuName)

                //Wymagana nazwa
                .IsRequired()

                //Maksymalna długość
                .HasMaxLength(50);

            modelBuilder.Entity<Menu>()
                .Property(r => r.MenuDescription)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                .Property(r => r.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(r => r.Weight)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Dish>()
                .Property(r => r.DishName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Dish>()
                .Property(r => r.DishDescription)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Dish>()
                .Property(r => r.MethodOfPeparation)
                .IsRequired()
                .HasMaxLength(1300);

            modelBuilder.Entity<Dish>()
                .Property(r => r.PreparationTime)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Dish>()
                .Property(r => r.Portions)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Dish>()
                .Property(r => r.Size)
                .IsRequired()
                .HasMaxLength(3);
        }

        //Konfiguracja połączenia do bazy danych
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
