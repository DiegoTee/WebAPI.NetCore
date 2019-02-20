using Microsoft.EntityFrameworkCore;
using SolsticeAPI.Model;

namespace SolsticeAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
