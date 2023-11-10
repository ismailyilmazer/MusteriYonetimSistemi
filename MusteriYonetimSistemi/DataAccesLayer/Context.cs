using Microsoft.EntityFrameworkCore;
using MusteriYonetimSistemi.Model;

namespace MusteriYonetimSistemi.DataAccesLayer
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
