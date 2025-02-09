using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;
using SocialMedia.Infrastructure.Context.Mappings;

namespace SocialMedia.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<RepostHistory> RepostHistories { get; set; }
        public DbSet<UserDailyPostCount> UserDailyPostCounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new RepostHistoryMap());
            modelBuilder.ApplyConfiguration(new UserDailyPostCountMap());


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Alice Johnson",
                    Nickname = "@AliceJohnson",
                    ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Alice"
                },
                new User
                {
                    Id = 2,
                    Name = "Bob Smith",
                    Nickname = "@BobSmith",
                    ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Bob"
                },
                new User
                {
                    Id = 3,
                    Name = "Charlie Brown",
                    Nickname = "@CharlieBrown",
                    ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Charlie"
                },
                new User
                {
                    Id = 4,
                    Name = "Diana Prince",
                    Nickname = "@DianaPrince",
                    ProfileImageUrl = "https://api.dicebear.com/7.x/adventurer/svg?seed=Diana"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}


