using Microsoft.EntityFrameworkCore;


namespace Desafios_academy.Model
{
    public class ReflectionContext : DbContext
    {
        public ReflectionContext(DbContextOptions<ReflectionContext> options) :base (options)
        {

        }
        
        public DbSet<Reflection> ReflectionsItems { get; set; }
        public DbSet<User> UserItems {get; set; }
    }
}
