using Microsoft.EntityFrameworkCore;
using Ornek_Ders.Controllers.Models;

namespace Ornek_Ders.Data
{
    public class ContacDbApiContext : DbContext
    {
        public ContacDbApiContext(DbContextOptions options) : base(options)
        { 

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
