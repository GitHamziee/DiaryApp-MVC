using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {

         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) :base(options) 
        {

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry
                {
                    ID = 1,
                    Title = "MVC ",
                    Content = "learning MVC on youtube",
                    Created = DateTime.Now
                },
                 new DiaryEntry
                 {
                     ID = 2,
                     Title = ".Net ",
                     Content = "Entity Framework",
                     Created = DateTime.Now
                 },
                 new DiaryEntry
                 {
                     ID = 3,
                     Title = "Angular",
                     Content = "Angular With Joe",
                     Created = DateTime.Now
                 }
                );  
        }
    }
}
