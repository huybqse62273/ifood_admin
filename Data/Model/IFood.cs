namespace Data.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IFood : DbContext
    {
        public IFood()
            : base("name=IFood")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Category_Dish> Category_Dish { get; set; }
        public virtual DbSet<CookBook> CookBooks { get; set; }
        public virtual DbSet<CookBook_Dish> CookBook_Dish { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Course_Dish> Course_Dish { get; set; }
        public virtual DbSet<DietaryPreference> DietaryPreferences { get; set; }
        public virtual DbSet<DietaryType> DietaryTypes { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Dish_Ingredient> Dish_Ingredient { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientType> IngredientTypes { get; set; }
        public virtual DbSet<IngredientType_Dietary> IngredientType_Dietary { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
        public virtual DbSet<StepByStep> StepBySteps { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Dietary> User_Dietary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category_Dish)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CookBook>()
                .HasMany(e => e.CookBook_Dish)
                .WithRequired(e => e.CookBook)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Course_Dish)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DietaryPreference>()
                .HasMany(e => e.IngredientType_Dietary)
                .WithRequired(e => e.DietaryPreference)
                .HasForeignKey(e => e.DietaryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DietaryPreference>()
                .HasMany(e => e.User_Dietary)
                .WithRequired(e => e.DietaryPreference)
                .HasForeignKey(e => e.DietaryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DietaryType>()
                .HasMany(e => e.DietaryPreferences)
                .WithOptional(e => e.DietaryType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.Category_Dish)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.CookBook_Dish)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.Course_Dish)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.Dish_Ingredient)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.ShoppingLists)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.StepBySteps)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.UnitId)
                .IsFixedLength();

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.Dish_Ingredient)
                .WithRequired(e => e.Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.ShoppingLists)
                .WithRequired(e => e.Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IngredientType>()
                .HasMany(e => e.Ingredients)
                .WithOptional(e => e.IngredientType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<IngredientType>()
                .HasMany(e => e.IngredientType_Dietary)
                .WithRequired(e => e.IngredientType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.ShoppingLists)
                .WithRequired(e => e.Transaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CookBooks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Dishes)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ShoppingLists)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User_Dietary)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
