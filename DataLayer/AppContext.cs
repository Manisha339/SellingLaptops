using Microsoft.EntityFrameworkCore;
using Models;
namespace DataLayer
{
    public class AppContext: DbContext
    {
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public AppContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<LaptopModel> LaptopModel { get; set; }
        public DbSet<RegisterModel> RegisterModel { get; set; }
        public DbSet<LoginModel> LoginModel { get; set; }



    }
}
