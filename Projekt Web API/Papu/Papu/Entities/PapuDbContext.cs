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
        public DbSet<ProductDish> DishProducts { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<KindOf> KindsOf { get; set; }
        public DbSet<DishKindOf> DishKindsOf { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Breakfast> Breakfasts { get; set; }
        public DbSet<BreakfastProduct> ProductBreakfasts { get; set; }
        public DbSet<BreakfastDish> DishBreakfasts { get; set; }
        public DbSet<SecondBreakfast> SecondBreakfasts { get; set; }
        public DbSet<SecondBreakfastProduct> ProductSecondBreakfasts { get; set; }
        public DbSet<SecondBreakfastDish> DishSecondBreakfasts { get; set; }
        public DbSet<Lunch> Lunches { get; set; }
        public DbSet<LunchProduct> LunchProducts { get; set; }
        public DbSet<LunchDish> LunchDishes { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<SnackProduct> SnackProducts { get; set; }
        public DbSet<SnackDish> SnackDishes { get; set; }
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<DinnerProduct> DinnerProducts { get; set; }
        public DbSet<DinnerDish> DinnerDishes { get; set; }
        public DbSet<Monday> Mondays { get; set; }
        public DbSet<Tuesday> Tuesdays { get; set; }
        public DbSet<Wednesday> Wednesdays { get; set; }
        public DbSet<Thursday> Thursdays { get; set; }
        public DbSet<Friday> Fridays { get; set; }
        public DbSet<Saturday> Saturdays { get; set; }
        public DbSet<Sunday> Sundays { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        //Dodatkowe właściwości które powinny zawiera kolumny w bazie danych
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();

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

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Unit>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Unit);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Unit)
                .WithMany(u => u.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductGroup>()
                .HasKey(pg => new { pg.ProductId, pg.GroupId });
            modelBuilder.Entity<ProductGroup>()
                .HasOne(pg => pg.Product)
                .WithMany(p => p.ProductGroups)
                .HasForeignKey(pg => pg.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductGroup>()
                .HasOne(pg => pg.Group)
                .WithMany(g => g.ProductGroups)
                .HasForeignKey(pg => pg.GroupId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<DishKindOf>()
                .HasKey(bc => new { bc.DishId, bc.KindOfId });
            modelBuilder.Entity<DishKindOf>()
                .HasOne(bc => bc.Dish)
                .WithMany(b => b.DishKindsOf)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishKindOf>()
                .HasOne(bc => bc.KindOf)
                .WithMany(c => c.DishKindsOf)
                .HasForeignKey(bc => bc.KindOfId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishType>()
                .HasKey(bc => new { bc.DishId, bc.TypeId });
            modelBuilder.Entity<DishType>()
                .HasOne(bc => bc.Dish)
                .WithMany(b => b.DishTypes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishType>()
                .HasOne(bc => bc.Type)
                .WithMany(c => c.DishTypes)
                .HasForeignKey(bc => bc.TypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductDish>()
                .HasKey(bc => new { bc.ProductId, bc.DishId });
            modelBuilder.Entity<ProductDish>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.DishProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductDish>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.DishProducts)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BreakfastProduct>()
                .HasKey(bc => new { bc.BreakfastId, bc.ProductId });
            modelBuilder.Entity<BreakfastProduct>()
                .HasOne(bc => bc.Breakfast)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.BreakfastId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BreakfastProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.BreakfastProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BreakfastDish>()
                .HasKey(bc => new { bc.BreakfastId, bc.DishId });
            modelBuilder.Entity<BreakfastDish>()
                .HasOne(bc => bc.Breakfast)
                .WithMany(b => b.Dishes)
                .HasForeignKey(bc => bc.BreakfastId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BreakfastDish>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.BreakfastDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SecondBreakfastProduct>()
                .HasKey(bc => new { bc.SecondBreakfastId, bc.ProductId });
            modelBuilder.Entity<SecondBreakfastProduct>()
                .HasOne(bc => bc.SecondBreakfast)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SecondBreakfastProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.SecondBreakfastProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SecondBreakfastDish>()
                .HasKey(bc => new { bc.SecondBreakfastId, bc.DishId });
            modelBuilder.Entity<SecondBreakfastDish>()
                .HasOne(bc => bc.SecondBreakfast)
                .WithMany(b => b.Dishes)
                .HasForeignKey(bc => bc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SecondBreakfastDish>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.SecondBreakfastDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LunchProduct>()
                .HasKey(bc => new { bc.LunchId, bc.ProductId });
            modelBuilder.Entity<LunchProduct>()
                .HasOne(bc => bc.Lunch)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.LunchId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LunchProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.LunchProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LunchDish>()
                .HasKey(bc => new { bc.LunchId, bc.DishId });
            modelBuilder.Entity<LunchDish>()
                .HasOne(bc => bc.Lunch)
                .WithMany(b => b.Dishes)
                .HasForeignKey(bc => bc.LunchId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LunchDish>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.LunchDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SnackProduct>()
                .HasKey(bc => new { bc.SnackId, bc.ProductId });
            modelBuilder.Entity<SnackProduct>()
                .HasOne(bc => bc.Snack)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.SnackId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SnackProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.SnackProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SnackDish>()
                .HasKey(bc => new { bc.SnackId, bc.DishId });
            modelBuilder.Entity<SnackDish>()
                .HasOne(bc => bc.Snack)
                .WithMany(b => b.Dishes)
                .HasForeignKey(bc => bc.SnackId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SnackDish>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.SnackDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DinnerProduct>()
                .HasKey(bc => new { bc.DinnerId, bc.ProductId });
            modelBuilder.Entity<DinnerProduct>()
                .HasOne(bc => bc.Dinner)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.DinnerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DinnerProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.DinnerProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DinnerDish>()
                .HasKey(bc => new { bc.DinnerId, bc.DishId });
            modelBuilder.Entity<DinnerDish>()
                .HasOne(bc => bc.Dinner)
                .WithMany(b => b.Dishes)
                .HasForeignKey(bc => bc.DinnerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DinnerDish>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.DinnerDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Breakfast>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Breakfast)
                .HasForeignKey<Monday>(pc => pc.BreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SecondBreakfast>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.SecondBreakfast)
                .HasForeignKey<Monday>(pc => pc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Lunch>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Lunch)
                .HasForeignKey<Monday>(pc => pc.LunchId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Snack>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Snack)
                .HasForeignKey<Monday>(pc => pc.SnackId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Dinner>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Dinner)
                .HasForeignKey<Monday>(pc => pc.DinnerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Breakfast>()
                .HasOne(p => p.Tuesday)
                .WithOne(c => c.Breakfast)
                .HasForeignKey<Tuesday>(pc => pc.BreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SecondBreakfast>()
                .HasOne(p => p.Tuesday)
                .WithOne(c => c.SecondBreakfast)
                .HasForeignKey<Tuesday>(pc => pc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Lunch>()
                .HasOne(p => p.Tuesday)
                .WithOne(c => c.Lunch)
                .HasForeignKey<Tuesday>(pc => pc.LunchId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Snack>()
                .HasOne(p => p.Tuesday)
                .WithOne(c => c.Snack)
                .HasForeignKey<Tuesday>(pc => pc.SnackId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Dinner>()
                .HasOne(p => p.Tuesday)
                .WithOne(c => c.Dinner)
                .HasForeignKey<Tuesday>(pc => pc.DinnerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Breakfast>()
                .HasOne(p => p.Wednesday)
                .WithOne(c => c.Breakfast)
                .HasForeignKey<Wednesday>(pc => pc.BreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SecondBreakfast>()
                .HasOne(p => p.Wednesday)
                .WithOne(c => c.SecondBreakfast)
                .HasForeignKey<Wednesday>(pc => pc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Lunch>()
                .HasOne(p => p.Wednesday)
                .WithOne(c => c.Lunch)
                .HasForeignKey<Wednesday>(pc => pc.LunchId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Snack>()
                .HasOne(p => p.Wednesday)
                .WithOne(c => c.Snack)
                .HasForeignKey<Wednesday>(pc => pc.SnackId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Dinner>()
                .HasOne(p => p.Wednesday)
                .WithOne(c => c.Dinner)
                .HasForeignKey<Wednesday>(pc => pc.DinnerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Breakfast>()
                .HasOne(p => p.Thursday)
                .WithOne(c => c.Breakfast)
                .HasForeignKey<Thursday>(pc => pc.BreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SecondBreakfast>()
                .HasOne(p => p.Thursday)
                .WithOne(c => c.SecondBreakfast)
                .HasForeignKey<Thursday>(pc => pc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Lunch>()
                .HasOne(p => p.Thursday)
                .WithOne(c => c.Lunch)
                .HasForeignKey<Thursday>(pc => pc.LunchId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Snack>()
                .HasOne(p => p.Thursday)
                .WithOne(c => c.Snack)
                .HasForeignKey<Thursday>(pc => pc.SnackId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Dinner>()
                .HasOne(p => p.Thursday)
                .WithOne(c => c.Dinner)
                .HasForeignKey<Thursday>(pc => pc.DinnerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Breakfast>()
                .HasOne(p => p.Friday)
                .WithOne(c => c.Breakfast)
                .HasForeignKey<Friday>(pc => pc.BreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SecondBreakfast>()
                .HasOne(p => p.Friday)
                .WithOne(c => c.SecondBreakfast)
                .HasForeignKey<Friday>(pc => pc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Lunch>()
                .HasOne(p => p.Friday)
                .WithOne(c => c.Lunch)
                .HasForeignKey<Friday>(pc => pc.LunchId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Snack>()
                .HasOne(p => p.Friday)
                .WithOne(c => c.Snack)
                .HasForeignKey<Friday>(pc => pc.SnackId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Dinner>()
                .HasOne(p => p.Friday)
                .WithOne(c => c.Dinner)
                .HasForeignKey<Friday>(pc => pc.DinnerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Breakfast>()
                .HasOne(p => p.Saturday)
                .WithOne(c => c.Breakfast)
                .HasForeignKey<Saturday>(pc => pc.BreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SecondBreakfast>()
                .HasOne(p => p.Saturday)
                .WithOne(c => c.SecondBreakfast)
                .HasForeignKey<Saturday>(pc => pc.SecondBreakfastId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Lunch>()
                .HasOne(p => p.Saturday)
                .WithOne(c => c.Lunch)
                .HasForeignKey<Saturday>(pc => pc.LunchId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Snack>()
                .HasOne(p => p.Saturday)
                .WithOne(c => c.Snack)
                .HasForeignKey<Saturday>(pc => pc.SnackId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Dinner>()
                .HasOne(p => p.Saturday)
                .WithOne(c => c.Dinner)
                .HasForeignKey<Saturday>(pc => pc.DinnerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Monday>()
                .HasOne(p => p.Menu)
                .WithOne(c => c.Monday)
                .HasForeignKey<Menu>(pc => pc.MondayId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Tuesday>()
                .HasOne(p => p.Menu)
                .WithOne(c => c.Tuesday)
                .HasForeignKey<Menu>(pc => pc.TuesdayId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Wednesday>()
                .HasOne(p => p.Menu)
                .WithOne(c => c.Wednesday)
                .HasForeignKey<Menu>(pc => pc.WednesdayId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Thursday>()
                .HasOne(p => p.Menu)
                .WithOne(c => c.Thursday)
                .HasForeignKey<Menu>(pc => pc.ThursdayId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Friday>()
                .HasOne(p => p.Menu)
                .WithOne(c => c.Friday)
                .HasForeignKey<Menu>(pc => pc.FridayId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Saturday>()
                .HasOne(p => p.Menu)
                .WithOne(c => c.Saturday)
                .HasForeignKey<Menu>(pc => pc.SaturdayId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Sunday>()
                .HasOne(p => p.Menu)
                .WithOne(c => c.Sunday)
                .HasForeignKey<Menu>(pc => pc.SundayId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Dish>()
                .Property(r => r.DishName)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Dish>()
                .Property(r => r.DishDescription)
                .IsRequired()
                .HasMaxLength(1300);

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
