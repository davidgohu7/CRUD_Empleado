using Microsoft.EntityFrameworkCore;

namespace CRUD_Empleado.Models
{
    public class Empdbcontext : DbContext
    {
        public Empdbcontext(DbContextOptions<Empdbcontext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}
