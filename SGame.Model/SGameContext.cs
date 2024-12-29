using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGame.Model.Core;
using SGame.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model
{
    public class SGameContext : IdentityDbContext<AppUser, AppRole, Guid, AppClaim, AppUserRole, AppLogin, AppRoleClaim, AppUserToken>
    {
        public SGameContext(DbContextOptions<SGameContext> options) : base(options) { 
        
        
        }
        
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<RoleOperation> RoleOperations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<AppUserRole>().ToTable("AppUserRole");
            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.ToTable("AppRole");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<AppClaim>(entity =>
            {
                entity.ToTable("AppClaim");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<AppLogin>().ToTable("AppLogin");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditable
                && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in modifiedEntries)
            {
                IAuditable entity = entry.Entity as IAuditable;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal?.Identity?.Name;

                    var userId = this.Users.Where(t => t.UserName == identityName).Select(t => t.Id).FirstOrDefault();
                    DateTime now = DateTime.Now;
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                        entity.CreatedID = userId;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }
                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                    entity.UpdatedID = userId;
                }
            }

            return base.SaveChanges();
        }


    }
}
