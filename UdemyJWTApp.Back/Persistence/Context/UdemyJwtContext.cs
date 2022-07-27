using Microsoft.EntityFrameworkCore;
using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistence.Configurations;

namespace UdemyJWTApp.Back.Persistence.Context
{
    public class UdemyJwtContext :DbContext
    {
        public UdemyJwtContext(DbContextOptions<UdemyJwtContext> options): base(options)
        {

        }

        public DbSet<Product> Products => this.Set<Product>();
    
        public DbSet<Category> Categories => this.Set<Category>();
    
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
    
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }



    }
}
