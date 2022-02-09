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
                .Property(r => r.Name)

                //Wymagana nazwa
                .IsRequired()

                //Maksymalna długość
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Dish>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

        //Konfiguracja połączenia do bazy danych
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
