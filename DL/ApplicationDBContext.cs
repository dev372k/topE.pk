using DL.Commons;
using DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Setting> Settings => Set<Setting>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<RolePermission> RolePermission => Set<RolePermission>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(_ => !_.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(_ => !_.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(_ => !_.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(_ => !_.IsDeleted);

            modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = 1, Name = PermissionConstants.USER },
            new Permission { Id = 2, Name = PermissionConstants.CATEGORY },
            new Permission { Id = 3, Name = PermissionConstants.PRODUCT },
            new Permission { Id = 4, Name = PermissionConstants.SETTING },
            new Permission { Id = 5, Name = PermissionConstants.ROLE }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Owner" }
            );

            modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission { Id = 1, RoleId = 1, PermissionId = 1, IsAllowed = true },
            new RolePermission { Id = 2, RoleId = 1, PermissionId = 2, IsAllowed = true },
            new RolePermission { Id = 3, RoleId = 1, PermissionId = 3, IsAllowed = true },
            new RolePermission { Id = 4, RoleId = 1, PermissionId = 4, IsAllowed = true },
            new RolePermission { Id = 5, RoleId = 1, PermissionId = 5, IsAllowed = true }
            );

            // Email : sa@mailinator.com
            //password : pass123
            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Name = "Owner", Email = "sa@mailinator.com", RoleId = 1, PasswordHash = "$2a$11$LF.jO5445FGwpoGW9PGgR.TKNymOmleYKS2vPhTcpqanjMM9stbIC" });
        }
    }
}
//d