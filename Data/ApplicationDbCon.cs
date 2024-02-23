using WebProject.Models;
using Microsoft.EntityFrameworkCore;
    
    namespace WebProject.Data
{
    public class ApplicationDbCon : DbContext
    {
        public ApplicationDbCon(DbContextOptions<ApplicationDbCon> options):base(options)
        {
        
        }
        public DbSet<Series> Seriess { get; set; }
        public DbSet<WatchList> WatchList { get; set; }
    }
}
