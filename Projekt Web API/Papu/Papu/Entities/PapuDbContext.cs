using Microsoft.EntityFrameworkCore;

namespace Papu.Entities
{
    // Klasa odpowiadająca bazie danych
    public class PapuDbContext : DbContext
    {
        public PapuDbContext(DbContextOptions<PapuDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
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
        public DbSet<Meal> Meals { get; set; }
        public DbSet<DishMeal> DishMeals { get; set; }
        public DbSet<ProductMeal> ProductMeals { get; set; }
        public DbSet<DayMenu> DaysMenu { get; set; }
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

            modelBuilder.Entity<Product>()
                .Property(r => r.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(r => r.Weight)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.Iron)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.VitaminB12)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.Folate)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.VitaminD)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.Calcium)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.Magnesium)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.Fiber)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.Protein)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.Fat)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.AssimilableCarbohydrates)
                .HasMaxLength(8)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Product>()
                .Property(r => r.CarbohydrateReplacement)
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

            modelBuilder.Entity<ProductMeal>()
                .HasKey(bc => new { bc.ProductId, bc.MealId });
            modelBuilder.Entity<ProductMeal>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductMeals)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductMeal>()
                .HasOne(bc => bc.Meal)
                .WithMany(c => c.ProductMeals)
                .HasForeignKey(bc => bc.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishMeal>()
                .HasKey(bc => new { bc.DishId, bc.MealId });
            modelBuilder.Entity<DishMeal>()
                .HasOne(bc => bc.Dish)
                .WithMany(b => b.DishMeals)
                .HasForeignKey(bc => bc.DishId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishMeal>()
                .HasOne(bc => bc.Meal)
                .WithMany(c => c.DishMeals)
                .HasForeignKey(bc => bc.MealId)
                .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity<Meal>()
                .Property(r => r.MealType)
                .IsRequired();

            modelBuilder.Entity<DayMenu>()
                .Property(r => r.DayOfWeek)
                .IsRequired();

            modelBuilder.Entity<DayMenu>()
                .HasMany(c => c.Meals)
                .WithOne(p => p.DayMenu);
            modelBuilder.Entity<Meal>()
                .HasOne(p => p.DayMenu)
                .WithMany(c => c.Meals)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
