using AwesomeSocialMedia.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSocialMedia.Users.Infrastructure.Persistence
{
    public class UsersDbContext : DbContext {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.OwnsOne(u => u.Location,
                    builder =>
                    {
                        builder.Property(p => p.City).HasColumnName("City");
                        builder.Property(p => p.State).HasColumnName("State");
                        builder.Property(p => p.Country).HasColumnName("Country");
                    });

                e.OwnsOne(u => u.Contact,
                    builder =>
                    {
                        builder.Property(p => p.Email).HasColumnName("Email");
                        builder.Property(p => p.Website).HasColumnName("Website");
                        builder.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                    });

                e.Ignore(p => p.Events);
            });
        }
    }
}
