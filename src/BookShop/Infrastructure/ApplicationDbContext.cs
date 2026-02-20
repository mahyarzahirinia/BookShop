using BookShop.Infrastructure.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext(options)
    {
        public DbSet<BookData> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookData>().HasData(new BookData
            { Id = 1, Author = "Andrew Lock", Description = "", Name = "", Pages = 172, Year = 2029, Price = 20 });


            base.OnModelCreating(builder);
        }
    }


}
