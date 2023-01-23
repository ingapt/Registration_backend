using Microsoft.EntityFrameworkCore;
using Registration_backend.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Registration_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne<UserInfo>(s => s.UserInfo).WithOne(ad => ad.User).HasForeignKey<UserInfo>(ad => ad.UserInfoOfUserId);

            modelBuilder.Entity<UserInfo>().HasOne<Address>(s => s.Address).WithOne(ad => ad.UserInfo).HasForeignKey<Address>(ad => ad.AddressOfUserInfoId);            
        }

    }
}
