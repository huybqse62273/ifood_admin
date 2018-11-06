namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Data.Model;

    public partial class OtakuStore : DbContext
    {
        public OtakuStore()
            : base("name=OtakuStore")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BlogImage> BlogImages { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Manufactor> Manufactors { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<MessageSending> MessageSendings { get; set; }
        public virtual DbSet<WebsiteAttribute> WebsiteAttributes { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }

        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch
            {

            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);
        }
    }
}
