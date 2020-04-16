using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SQLMVC.Models;

namespace SQLMVC.Models
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions options) : base(options) {}
        
        public DbSet<User> Users {get;set;}
    }
}