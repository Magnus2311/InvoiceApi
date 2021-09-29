using InvoiceApi.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database
{
    public class InvoiceDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer("Server=.;Database=InvoiceDatabase;User Id=sa;Password=Micr0!nvest;Integrated Security=True;");
        }
    }
}