using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Entities
{
    public class ProiectContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
       UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<ItemShop> ItemShops { get; set; }


        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        /**protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer("Server=(localdb)\\ProjectsV13;Initial Catalog=Items;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }**/
        protected override void OnModelCreating(ModelBuilder builder)
        {

           base.OnModelCreating(builder);
           builder.Entity<Manager>()
                .HasOne(manager => manager.Shop)
                .WithOne(shop => shop.Manager);


            builder.Entity<Shop>()
                 .HasMany(shop => shop.Employees)
                 .WithOne(employees => employees.Shop);

            builder.Entity<ItemShop>().HasKey(itemshop => new {itemshop.ItemId,itemshop.ShopId });

            builder.Entity<ItemShop>()
                .HasOne(itemshop => itemshop.Item)
                .WithMany(a => a.ItemShops)
                .HasForeignKey(ac => ac.ItemId);

            builder.Entity<ItemShop>()
                .HasOne(itemshop => itemshop.Shop)
                .WithMany(a => a.ItemShops)
                .HasForeignKey(ac => ac.ShopId);

        }
    }
}
