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
        public DbSet<Monday> Mondays { get; set; }
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

            /*modelBuilder.Entity<Breakfast>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Breakfast)
                .HasForeignKey<Monday>(c => c.MondayId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SecondBreakfast>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.SecondBreakfast)
                .HasForeignKey<Monday>(c => c.MondayId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lunch>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Lunch)
                .HasForeignKey<Monday>(c => c.MondayId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Snack>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Snack)
                .HasForeignKey<Monday>(c => c.MondayId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dinner>()
                .HasOne(p => p.Monday)
                .WithOne(c => c.Dinner)
                .HasForeignKey<Monday>(c => c.MondayId)
                .OnDelete(DeleteBehavior.Restrict);*/

            /*            modelBuilder.Entity<Menu>()
                            .HasOne(m => m.Monday)
                            .WithOne(b => b.Menu)
                            .HasForeignKey<Monday>(b => b.MenuRef)
                            .OnDelete(DeleteBehavior.SetNull);*//*
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Tuesday)
                .WithOne(b => b.Menu)
                .HasForeignKey<Tuesday>(b => b.MenuRef)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Wednesday)
                .WithOne(b => b.Menu)
                .HasForeignKey<Wednesday>(b => b.MenuRef)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Thursday)
                .WithOne(b => b.Menu)
                .HasForeignKey<Thursday>(b => b.MenuRef)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Friday)
                .WithOne(b => b.Menu)
                .HasForeignKey<Friday>(b => b.MenuRef)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Saturday)
                .WithOne(b => b.Menu)
                .HasForeignKey<Saturday>(b => b.MenuRef)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Sunday)
                .WithOne(b => b.Menu)
                .HasForeignKey<Sunday>(b => b.MenuRef)
                .OnDelete(DeleteBehavior.SetNull);

*//*            modelBuilder.Entity<DishMonday>()
                .HasKey(dm => new { dm.MondayId, dm.DishId });
            modelBuilder.Entity<DishMonday>()
                .HasOne(bc => bc.Monday)
                .WithMany(b => b.MondayDishes)
                .HasForeignKey(bc => bc.MondayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishMonday>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.MondayDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);*//*

            modelBuilder.Entity<DishTuesday>()
                .HasKey(dm => new { dm.TuesdayId, dm.DishId });
            modelBuilder.Entity<DishTuesday>()
                .HasOne(bc => bc.Tuesday)
                .WithMany(b => b.TuesdayDishes)
                .HasForeignKey(bc => bc.TuesdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishTuesday>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.TuesdayDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishWednesday>()
                .HasKey(dm => new { dm.WednesdayId, dm.DishId });
            modelBuilder.Entity<DishWednesday>()
                .HasOne(bc => bc.Wednesday)
                .WithMany(b => b.WednesdayDishes)
                .HasForeignKey(bc => bc.WednesdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishWednesday>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.WednesdayDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishThursday>()
                .HasKey(dm => new { dm.ThursdayId, dm.DishId });
            modelBuilder.Entity<DishThursday>()
                .HasOne(bc => bc.Thursday)
                .WithMany(b => b.ThursdayDishes)
                .HasForeignKey(bc => bc.ThursdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishThursday>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.ThursdayDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishFriday>()
                .HasKey(dm => new { dm.FridayId, dm.DishId });
            modelBuilder.Entity<DishFriday>()
                .HasOne(bc => bc.Friday)
                .WithMany(b => b.FridayDishes)
                .HasForeignKey(bc => bc.FridayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishFriday>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.FridayDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishSaturday>()
                .HasKey(dm => new { dm.SaturdayId, dm.DishId });
            modelBuilder.Entity<DishSaturday>()
                .HasOne(bc => bc.Saturday)
                .WithMany(b => b.SaturdayDishes)
                .HasForeignKey(bc => bc.SaturdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishSaturday>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.SaturdayDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishSunday>()
                .HasKey(dm => new { dm.SundayId, dm.DishId });
            modelBuilder.Entity<DishSunday>()
                .HasOne(bc => bc.Sunday)
                .WithMany(b => b.SundayDishes)
                .HasForeignKey(bc => bc.SundayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishSunday>()
                .HasOne(bc => bc.Dish)
                .WithMany(c => c.SundayDishes)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);*/

            /*            modelBuilder.Entity<ProductMonday>()
                            .HasKey(dm => new { dm.MondayId, dm.ProductId });
                        modelBuilder.Entity<ProductMonday>()
                            .HasOne(bc => bc.Monday)
                            .WithMany(b => b.MondayProducts)
                            .HasForeignKey(bc => bc.MondayId)
                            .OnDelete(DeleteBehavior.Cascade);
                        modelBuilder.Entity<ProductMonday>()
                            .HasOne(bc => bc.Product)
                            .WithMany(c => c.MondayProducts)
                            .HasForeignKey(bc => bc.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);*/

            /*modelBuilder.Entity<ProductTuesday>()
                .HasKey(dm => new { dm.TuesdayId, dm.ProductId });
            modelBuilder.Entity<ProductTuesday>()
                .HasOne(bc => bc.Tuesday)
                .WithMany(b => b.TuesdayProducts)
                .HasForeignKey(bc => bc.TuesdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductTuesday>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.TuesdayProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductWednesday>()
                .HasKey(dm => new { dm.WednesdayId, dm.ProductId });
            modelBuilder.Entity<ProductWednesday>()
                .HasOne(bc => bc.Wednesday)
                .WithMany(b => b.WednesdayProducts)
                .HasForeignKey(bc => bc.WednesdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductWednesday>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.WednesdayProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductThursday>()
                .HasKey(dm => new { dm.ThursdayId, dm.ProductId });
            modelBuilder.Entity<ProductThursday>()
                .HasOne(bc => bc.Thursday)
                .WithMany(b => b.ThursdayProducts)
                .HasForeignKey(bc => bc.ThursdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductThursday>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.ThursdayProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductFriday>()
                .HasKey(dm => new { dm.FridayId, dm.ProductId });
            modelBuilder.Entity<ProductFriday>()
                .HasOne(bc => bc.Friday)
                .WithMany(b => b.FridayProducts)
                .HasForeignKey(bc => bc.FridayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductFriday>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.FridayProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSaturday>()
               .HasKey(dm => new { dm.SaturdayId, dm.ProductId });
            modelBuilder.Entity<ProductSaturday>()
                .HasOne(bc => bc.Saturday)
                .WithMany(b => b.SaturdayProducts)
                .HasForeignKey(bc => bc.SaturdayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductSaturday>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.SaturdayProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSunday>()
               .HasKey(dm => new { dm.SundayId, dm.ProductId });
            modelBuilder.Entity<ProductSunday>()
                .HasOne(bc => bc.Sunday)
                .WithMany(b => b.SundayProducts)
                .HasForeignKey(bc => bc.SundayId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductSunday>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.SundayProducts)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);*/

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
