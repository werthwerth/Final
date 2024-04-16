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
            public DbSet<Article> Articles { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<ArticleTag> ArticleTags { get; set; }


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
                modelBuilder.Entity<Article>(eb =>
                {
                    eb.HasKey(x => x.Id);
                    eb.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid().ToString());
                    eb.Property(x => x.CreateDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
                });
                modelBuilder.Entity<Tag>(eb =>
                {
                    eb.HasKey(x => x.Id);
                    eb.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid().ToString());
                    eb.Property(x => x.CreateDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
                });
                modelBuilder.Entity<Comment>(eb =>
                {
                    eb.HasKey(x => x.Id);
                    eb.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid().ToString());
                    eb.Property(x => x.CreateDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
                });
                modelBuilder.Entity<ArticleTag>(eb =>
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
                context.Articles.Load();
                context.Tags.Load();
                context.Comments.Load();
                context.ArticleTags.Load();
            }
        }

        public class StaticUserRole
        {
            public StaticUserRole(string _type, string _name)
            {
                type = _type;
                name = _name;
            }

            public string type { get; set; }
            public string name { get; set; }
        }
        public static void CheckDBStaticValues(DB _db)
        {

            List<string> _names = new List<string>() { "Пользователи", "Модераторы", "Администраторы" };
            foreach (string _name in _names)
            {
                RoleEntity.Add(_name, _db);
            }

            List<StaticUserRole> _userTypes = new List<StaticUserRole> { new StaticUserRole("Regular", "Пользователи"), new StaticUserRole("Moderator", "Модераторы"), new StaticUserRole("Admin", "Администраторы") };
            foreach (StaticUserRole _StaticUserRole in _userTypes)
            {
                if (!UserEntity.Check($"{_StaticUserRole.type}User", _db))
                {
                    Role? _role = _db.context.Roles.FirstOrDefault(x => x.Name == _StaticUserRole.name) ?? null;
                    UserEntity.Register($"{_StaticUserRole.type}User", _db, SHA512Hash.Calculate($"{_StaticUserRole.type}Password"), _StaticUserRole.type, "User", $"{_StaticUserRole.type}User@mail.ru", _role);
                }
            }
        }
    }
}

