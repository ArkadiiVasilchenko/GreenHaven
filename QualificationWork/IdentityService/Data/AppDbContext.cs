using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ModelLibrary;

namespace IdentityService.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
            .HasOne(e => e.Post).WithMany().HasForeignKey(e => e.IdPost).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(e => e.User).WithMany().HasForeignKey(e => e.IdUser).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>()
                .HasOne(e => e.User).WithMany().HasForeignKey(e => e.IdUser).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}