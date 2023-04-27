using ElectroLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectroLib.Connect
{

    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NOPMLSM\SQLEXPRESS;Database=ElectroLib;Trusted_Connection=True;Trust Server Certificate=true;");
        }
    }

}
