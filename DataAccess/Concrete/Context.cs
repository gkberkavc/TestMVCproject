using Microsoft.EntityFrameworkCore;
using TESTPROJE_1_MVC.Entities.Concrete;

namespace TESTPROJE_1_MVC.DataAccess.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=GOKBERK;database=TestWordDB;integrated security = true;");

         
        }
        public DbSet<Words> Kelime { get; set; }
    }
}
