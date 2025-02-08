using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Context.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasMaxLength(50);

            builder.Property(u => u.ProfileImageUrl)
                .HasMaxLength(256);

            builder.HasMany<Post>()
                .WithOne()
                .HasForeignKey(p => p.AuthorUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<UserDailyPostLimit>()
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
