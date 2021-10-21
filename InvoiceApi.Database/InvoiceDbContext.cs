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
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Items)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);

            builder
                .Entity<User>()
                .HasOne(u => u.MyCompany)
                .WithOne(mc => mc.User);

            builder
                .Entity<MyCompany>()
                .HasMany(mc => mc.Addresses)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyId);

            builder
                .Entity<MyCompany>()
                .HasMany(mc => mc.BankAccounts)
                .WithOne(ba => ba.Company)
                .HasForeignKey(ba => ba.CompanyId);

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer("Server=.;Database=InvoiceDatabase;User Id=sa;Password=Micr0!nvest;Integrated Security=True;");
        }
    }
}