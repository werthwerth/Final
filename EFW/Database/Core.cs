using Microsoft.EntityFrameworkCore;
using Final.EFW.Entities;
using System.Xml.Linq;
using static Final.EFW.Database.Core;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Final.EFW.Database.EntityActions;
using System.Runtime.CompilerServices;
using Final.Static;

namespace Final.EFW.Database
{
    public class Core
    {
        public class ApplicationContext : DbContext
        {
            // Объекты таблицы Users
            public DbSet<User> Users { get; set; }
            public DbSet<Session> Sessions { get; set; }
            public DbSet<Role> Roles { get; set; }

            public ApplicationContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=Final.db");
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>(eb =>
                {
                    eb.HasKey(x => x.Id);
                    eb.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid().ToString());
                    eb.Property(x => x.CreateDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
                });
                modelBuilder.Entity<Session>(eb =>
                {
                    eb.HasKey(x => x.Id);
                    eb.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid().ToString());
                    eb.Property(x => x.CreateDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
                });
                modelBuilder.Entity<Role>(eb =>
                {
                    eb.HasKey(x => x.Id);
                    eb.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid().ToString());
                    eb.Property(x => x.CreateDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
                });
            }
        }
        public class DB
        {
            protected internal ApplicationContext context;
            protected internal DB()
            {
                context = new ApplicationContext();
                context.Database.EnsureCreated();
                context.Users.Load();
                context.Sessions.Load();
                context.Roles.Load();
            }
        }

        public static void CheckDBStaticValues(DB _db)
        {
            
            List<string> _names = new List<string>() { "Пользователи", "Модераторы", "Администраторы" };
            foreach (string _name in _names)
            {
                RoleEntity.Add(_name, _db);
            }

            List<string> _userTypes = new List<List<string>>() { "Regular","" "Moderator", "Admin" };
            foreach (string _type in _userTypes)
            {
                if (!UserEntity.Check($"{_type}User", _db))
                {
                    Role? _regularRole = _db.context.Roles.FirstOrDefault(x => x.Name == "Пользователи") ?? null;
                    UserEntity.Register("RegularUser", _db, SHA512Hash.Calculate("RegularPassword"), "Regular", "User", "RegularUser@mail.ru", _regularRole);
                }
            }

            
            Role? _moderatorRole = _db.context.Roles.FirstOrDefault(x => x.Name == "Модераторы") ?? null;
            Role? _adminRole = _db.context.Roles.FirstOrDefault(x => x.Name == "Администраторы") ?? null;
            
            UserEntity.Register("ModeratorUser", _db, SHA512Hash.Calculate("ModeratorPassword"), "Moderator", "User", "ModeratorUser@mail.ru", _moderatorRole);
            UserEntity.Register("AdminUser", _db, SHA512Hash.Calculate("AdminPassword"), "Admin", "User", "AdminUser@mail.ru", _adminRole);
        }
    }
}
