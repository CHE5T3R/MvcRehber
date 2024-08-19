using MvcRehber2.Models;
using Rehber.Models.Entities;
using System.Data.Entity;

namespace Rehber.Models.Context
{
    public class dbContext : DbContext
    {
        public dbContext():base("Server=.;Database=RehberDB;Trusted_Connection=true")
        {
               
        }
        public DbSet<rehber> rehbers { get; set; }

        public DbSet<user> users { get; set; }

        public DbSet<sehir> sehirs { get; set; }


    }
}
