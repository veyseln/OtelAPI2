using Microsoft.EntityFrameworkCore;
using Ornek_Ders.Controllers.Models;
using Ornek_Ders.Models;

namespace Ornek_Ders.Data
{
    public class ContacDbApiContext : DbContext
    {
        public ContacDbApiContext(DbContextOptions options) : base(options)
        { 

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
