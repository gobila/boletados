using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class BoletadosContext : DbContext
    {
        public BoletadosContext(DbContextOptions<BoletadosContext> options): base(options){

        }

        public DbSet<Boletados> Boletados{get;set;}
        public DbSet<User> User{get;set;}
    }
}