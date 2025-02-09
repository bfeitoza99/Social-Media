﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;


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
               .HasMaxLength(100);

            builder.Property(u => u.Nickname)                
                .HasMaxLength(50);

            builder.HasIndex(u => u.Nickname) 
                .IsUnique();

            builder.Property(u => u.ProfileImageUrl)
                .HasMaxLength(256);

            builder.HasMany<Post>()
                .WithOne()
                .HasForeignKey(p => p.AuthorUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<UserDailyPostCount>()
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
