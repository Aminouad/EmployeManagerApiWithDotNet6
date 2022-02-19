using Microsoft.EntityFrameworkCore;

namespace MyFirstCRUDapi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<employe> Employe { get; set; }
        }
    }

