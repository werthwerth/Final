using Microsoft.EntityFrameworkCore;
using Final.EFW.Entities;
using System.Xml.Linq;

namespace Final.EFW.Database
{
    public class Core
    {
        public class ApplicationContext : DbContext
        {
            // Объекты таблицы Users
            public DbSet<User> Users { get; set; }
            public DbSet<Session> Sessions { get; set; }

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
            }
        }
    }
}
