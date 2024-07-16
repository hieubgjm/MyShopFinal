using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyShop.Model.Abstract;
using MyShop.Model.Models;

namespace MyShop.Data
{
    public class MyShopDbContext : DbContext
    {
        public MyShopDbContext()
        {
        }

        public MyShopDbContext(DbContextOptions<MyShopDbContext> options) : base(options)
        {
        }

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<PostTags> PostTags { get; set; }
        
        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
       
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        public override int SaveChanges()
        {
            UpdateTimeStamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken = default)
        {
            UpdateTimeStamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conf = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder
                    .UseSqlServer(conf.GetConnectionString("AppConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(r => r.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.ID, od.ProductID });
            modelBuilder.Entity<PostTags>()
                .HasKey(od => new { od.PostID, od.TagID });
            modelBuilder.Entity<ProductTag>()
                .HasKey(od => new { od.ProductID, od.TagID });
             


          
        }

        private void UpdateTimeStamps()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is Auditable entity)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(e => e.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }
        }
    }
}