
using Domain.Entites;
using Domain.Entites.Config;
using Domain.Helper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Rols { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        #endregion


        #region Config
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "محمد", LastName = "ضرابی", Password = SecurityHelper.PasswordToSHA256("Mm@123456"), MobileNumber = "09120198177" });
            modelBuilder.Entity<Role>().HasData(new Role() { Id = 1, IsActive = true, RoleName = "SuperAdmin" });
            modelBuilder.Entity<UserRole>().HasData(new UserRole() { Id = 1, RoleId = 1, UserId = 1 });

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict; // یا NoAction
            }

            //modelBuilder.Entity<UserRole>().Navigation(e=>e.Role).AutoInclude();
            //modelBuilder.Entity<UserRole>().Navigation(e=>e.user).AutoInclude();
        }
        #endregion


    }
}
