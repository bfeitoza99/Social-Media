using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entity;
using SocialMedia.Infrastructure.Mappings;

namespace SocialMedia.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<RepostHistory> RepostHistories { get; set; }
        public DbSet<UserDailyPostLimit> UserDailyPostLimits { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new RepostHistoryMap());
            modelBuilder.ApplyConfiguration(new UserDailyPostLimitMap());


            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     Name = "Alice Johnson",
                     ProfileImageUrl = "https://example.com/profiles/alice.jpg"
                 },
                 new User
                 {
                     Id = 2,
                     Name = "Bob Smith",
                     ProfileImageUrl = "https://example.com/profiles/bob.jpg"
                 },
                 new User
                 {
                     Id = 3,
                     Name = "Charlie Brown",
                     ProfileImageUrl = "https://example.com/profiles/charlie.jpg"
                 },
                 new User
                 {
                     Id = 4,
                     Name = "Diana Prince",
                     ProfileImageUrl = "https://example.com/profiles/diana.jpg"
                 }
             );

            base.OnModelCreating(modelBuilder);
        }
    }
}


