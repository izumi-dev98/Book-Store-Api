using BookStoreAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options  )
        {
            
        }


        public DbSet<Authors> Authors { get; set; }

        public DbSet<Books> Books { get; set; }
    }
}
