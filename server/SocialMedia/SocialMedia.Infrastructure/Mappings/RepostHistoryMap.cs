﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entity;

namespace SocialMedia.Infrastructure.Mappings
{
    public class RepostHistoryMap : IEntityTypeConfiguration<RepostHistory>
    {
        public void Configure(EntityTypeBuilder<RepostHistory> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();


            builder.Property(p => p.RepostDate)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p=> p.PostId)
                .IsRequired();

            builder.HasOne<User>()
                .WithOne();

            builder.HasOne<Post>()
                .WithOne();

        }
    }

}
